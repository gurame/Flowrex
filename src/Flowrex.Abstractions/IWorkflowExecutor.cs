using Flowrex.Results;

namespace Flowrex.Abstractions;

/// <summary>
/// Executes a fully built workflow instance, resolving steps and coordinating execution.
/// </summary>
public interface IWorkflowExecutor
{
    /// <summary>
    /// Executes a workflow with the given context and cancellation support.
    /// </summary>
    /// <param name="workflow">The workflow to execute.</param>
    /// <param name="context">The context shared across steps.</param>
    /// <param name="cancellationToken">Cancellation support.</param>
    /// <returns>The final status of the workflow.</returns>
    Task<WorkflowStatus> ExecuteAsync(
        IWorkflow workflow,
        IWorkflowContext context,
        CancellationToken cancellationToken);

    Task<WorkflowStatus> ExecuteAsync<TWorkflowDefinition>(
        CancellationToken cancellationToken = default)
        where TWorkflowDefinition : IWorkflowDefinition;
}
