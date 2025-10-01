using Flowrex.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Flowrex.Core;

/// <summary>
/// Default compensation strategy: executes compensations in reverse order of execution.
/// </summary>
public sealed class DefaultCompensationStrategy(ILogger<DefaultCompensationStrategy> logger) : ICompensationStrategy
{
    public async Task CompensateAsync(
        IWorkflow workflow,
        IReadOnlyList<WorkflowStepDefinition> executedSteps,
        IWorkflowContext context,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
    {
        logger.LogWarning(
            "Starting compensation for workflow {WorkflowName}. Will attempt to compensate {StepCount} steps",
            workflow.Name, executedSteps.Count);

        var compensationErrors = 0;

        foreach (var stepDef in executedSteps.Reverse())
        {
            if (stepDef.CompensationStepType is null)
            {
                logger.LogDebug(
                    "Step {StepType} has no compensation step defined, skipping",
                    stepDef.StepType.Name);
                continue;
            }

            var compensator = (ICompensableStep)serviceProvider.GetRequiredService(stepDef.CompensationStepType);

            try
            {
                logger.LogInformation(
                    "Executing compensation step {CompensationType} for step {StepType}",
                    stepDef.CompensationStepType.Name, stepDef.StepType.Name);

                await compensator.CompensateAsync(context, cancellationToken);

                logger.LogInformation(
                    "Successfully completed compensation step {CompensationType}",
                    stepDef.CompensationStepType.Name);
            }
            catch (Exception ex)
            {
                compensationErrors++;
                logger.LogError(ex,
                    "Compensation step {CompensationType} failed for step {StepType}. Continuing with remaining compensations",
                    stepDef.CompensationStepType.Name, stepDef.StepType.Name);

                // Compensation failures are logged but don't stop the compensation chain
            }
        }

        if (compensationErrors > 0)
        {
            logger.LogWarning(
                "Compensation completed with {ErrorCount} error(s) for workflow {WorkflowName}",
                compensationErrors, workflow.Name);
        }
        else
        {
            logger.LogInformation(
                "All compensation steps completed successfully for workflow {WorkflowName}",
                workflow.Name);
        }
    }
}
