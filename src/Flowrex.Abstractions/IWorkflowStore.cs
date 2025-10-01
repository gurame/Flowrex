namespace Flowrex.Abstractions;

/// <summary>
/// Defines a contract for persisting and retrieving workflow executions.
/// </summary>
public interface IWorkflowStore
{
    /// <summary>
    /// Persists the state of a workflow execution.
    /// </summary>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    Task SaveExecutionAsync(IWorkflowExecution execution, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a previously stored workflow execution by its ID.
    /// </summary>
    /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
    Task<IWorkflowExecution?> GetExecutionAsync(Guid executionId, CancellationToken cancellationToken);
}
