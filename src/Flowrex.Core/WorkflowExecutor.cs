using System.Diagnostics;
using Flowrex.Abstractions;
using Flowrex.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Flowrex.Core;

public sealed class WorkflowExecutor(
    IServiceScopeFactory scopeFactory,
    IWorkflowStore workflowStore,
    ICompensationStrategy compensationStrategy,
    ILogger<WorkflowExecutor> logger)
    : IWorkflowExecutor
{
    
    public async Task<WorkflowStatus> ExecuteAsync(
        IWorkflow workflow,
        IWorkflowContext context,
        CancellationToken cancellationToken)
    {
        // Create a scope for this workflow execution
        using var scope = scopeFactory.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        List<WorkflowStepDefinition> executedSteps = [];

        using var activity = Activity.Current?.Source.StartActivity("Workflow.Execute");
        activity?.SetTag("workflow.name", workflow.Name);
        activity?.SetTag("execution.id", context.ExecutionId);
        
        logger.LogInformation(
            "Starting workflow {WorkflowName} with execution ID {ExecutionId}",
            workflow.Name, context.ExecutionId);

        var execution = WorkflowExecution.StartNew(workflow.Name);
        execution.MarkStepExecuted("Start");

        await workflowStore.SaveExecutionAsync(execution, cancellationToken);
        foreach (var stepDef in workflow.Steps)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                execution.Cancel();
                await workflowStore.SaveExecutionAsync(execution, CancellationToken.None);
                
                 await compensationStrategy.CompensateAsync(
                        workflow, executedSteps, context, serviceProvider, CancellationToken.None);
    
                return WorkflowStatus.Canceled;
            }

            try
            {
                var step = (IWorkflowStep)serviceProvider.GetRequiredService(stepDef.StepType);
                var result = await step.ExecuteAsync(context, cancellationToken);

                executedSteps.Add(stepDef);
                execution.MarkStepExecuted(stepDef.StepType.Name);

                if (result.IsFailure)
                {
                    execution.Fail();
                    await workflowStore.SaveExecutionAsync(execution, cancellationToken);

                    await compensationStrategy.CompensateAsync(
                        workflow, executedSteps, context, serviceProvider, cancellationToken);

                    return WorkflowStatus.Failed;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error executing step {StepType} in workflow {WorkflowName}",
                    stepDef.StepType.Name, workflow.Name);
                    
                execution.Fail();
                await workflowStore.SaveExecutionAsync(execution, cancellationToken);

                await compensationStrategy.CompensateAsync(
                    workflow, executedSteps, context, serviceProvider, cancellationToken);

                throw;
            }
        }

        execution.Succeed();
        await workflowStore.SaveExecutionAsync(execution, cancellationToken);

        return WorkflowStatus.Succeeded;
    }

    public async Task<WorkflowStatus> ExecuteAsync<TWorkflowDefinition>(
        CancellationToken cancellationToken = default)
        where TWorkflowDefinition : IWorkflowDefinition
    {
        using var scope = scopeFactory.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        
        var workflowDefinition = serviceProvider.GetRequiredService<TWorkflowDefinition>();

        var builder = new WorkflowBuilder(workflowDefinition.GetType().Name);

        var workflow = workflowDefinition.Build(builder);

        var context = new WorkflowContext(serviceProvider);

        return await ExecuteAsync(workflow, context, cancellationToken);
    }
}
