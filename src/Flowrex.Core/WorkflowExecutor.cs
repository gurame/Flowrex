using Flowrex.Abstractions;
using Flowrex.Results;
using Microsoft.Extensions.DependencyInjection;

namespace Flowrex.Core;

public sealed class WorkflowExecutor(
    IServiceProvider serviceProvider,
    IWorkflowStore workflowStore,
    ICompensationStrategy compensationStrategy)
    : IWorkflowExecutor
{
    private readonly List<WorkflowStepDefinition> _executedSteps = [];

    public async Task<WorkflowStatus> ExecuteAsync(
        IWorkflow workflow,
        IWorkflowContext context,
        CancellationToken cancellationToken)
    {
        var execution = WorkflowExecution.StartNew(workflow.Name);

        foreach (var stepDef in workflow.Steps)
        {
            if (cancellationToken.IsCancellationRequested)
                return WorkflowStatus.Canceled;

            try
            {
                var step = (IWorkflowStep)serviceProvider.GetRequiredService(stepDef.StepType);
                var result = await step.ExecuteAsync(context, cancellationToken);

                _executedSteps.Add(stepDef);
                execution.MarkStepExecuted(stepDef.StepType.Name);

                if (result.IsFailure)
                {
                    execution.MarkCompleted(WorkflowStatus.Failed);
                    await workflowStore.SaveExecutionAsync(execution, cancellationToken);

                    await compensationStrategy.CompensateAsync(
                        workflow, _executedSteps, context, serviceProvider, cancellationToken);

                    return WorkflowStatus.Failed;
                }
            }
            catch (Exception)
            {
                execution.MarkCompleted(WorkflowStatus.Failed);
                await workflowStore.SaveExecutionAsync(execution, cancellationToken);

                await compensationStrategy.CompensateAsync(
                    workflow, _executedSteps, context, serviceProvider, cancellationToken);

                throw;
            }
        }

        execution.MarkCompleted(WorkflowStatus.Completed);
        await workflowStore.SaveExecutionAsync(execution, cancellationToken);

        return WorkflowStatus.Completed;
    }
}
