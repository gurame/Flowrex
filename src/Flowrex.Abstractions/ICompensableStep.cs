using Flowrex.Results;

namespace Flowrex.Abstractions;

/// <summary>
/// Represents a workflow step that supports compensation logic for rollback scenarios.
/// </summary>
public interface ICompensableStep
{
    /// <summary>
    /// Executes compensation logic to undo effects of a previously executed step.
    /// </summary>
    /// <param name="context">The workflow context at the time of compensation.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>A StepResult indicating the outcome of the compensation step.</returns>
    Task<StepResult> CompensateAsync(IWorkflowContext context, CancellationToken cancellationToken);
}