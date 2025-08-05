using Flowrex.Abstractions;
using Flowrex.Results;

namespace Flowrex.Core;

/// <summary>
/// Abstract base class for workflow steps, providing common execution structure.
/// </summary>
public abstract class WorkflowStep : IWorkflowStep
{
    /// <summary>
    /// Executes the step logic within the given context.
    /// This method must be implemented by derived classes.
    /// </summary>
    protected abstract Task<StepResult> RunAsync(IWorkflowContext context, CancellationToken cancellationToken);

    /// <summary>
    /// Template method that wraps the step execution with standard handling.
    /// </summary>
    public async Task<StepResult> ExecuteAsync(IWorkflowContext context, CancellationToken cancellationToken)
    {
        try
        {
            return await RunAsync(context, cancellationToken);
        }
        catch (Exception ex)
        {
            // You could optionally add logging hooks here.
            return StepResult.Failure($"Exception in step {GetType().Name}: {ex.Message}");
        }
    }
}