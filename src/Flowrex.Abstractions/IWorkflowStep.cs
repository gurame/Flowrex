using Flowrex.Results;

namespace Flowrex.Abstractions;

/// <summary>
/// Represents a unit of work within a workflow.
/// </summary>
public interface IWorkflowStep
{
    /// <summary>
    /// Executes the step asynchronously within the given workflow context.
    /// </summary>
    /// <param name="context">The current workflow context.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>A StepResult indicating the outcome of the step.</returns>
    Task<StepResult> ExecuteAsync(IWorkflowContext context, CancellationToken cancellationToken);
}