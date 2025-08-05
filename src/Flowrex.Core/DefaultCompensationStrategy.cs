using Flowrex.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Flowrex.Core;

/// <summary>
/// Default compensation strategy: executes compensations in reverse order of execution.
/// </summary>
public sealed class DefaultCompensationStrategy : ICompensationStrategy
{
    public async Task CompensateAsync(
        IWorkflow workflow,
        IReadOnlyList<WorkflowStepDefinition> executedSteps,
        IWorkflowContext context,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken)
    {
        foreach (var stepDef in executedSteps.Reverse())
        {
            if (stepDef.CompensationStepType is null)
                continue;

            var compensator = (ICompensableStep)serviceProvider.GetRequiredService(stepDef.CompensationStepType);

            try
            {
                await compensator.CompensateAsync(context, cancellationToken);
                // Optional: log success
            }
            catch (Exception ex)
            {
                
                // Optional: log failure
            }
        }
    }
}