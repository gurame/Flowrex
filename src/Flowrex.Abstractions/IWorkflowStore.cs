namespace Flowrex.Abstractions;

/// <summary>
/// Defines a contract for persisting and retrieving workflow executions.
/// </summary>
public interface IWorkflowStore
{
    /// <summary>
    /// Persists the state of a workflow execution.
    /// </summary>
    Task SaveExecutionAsync(IWorkflowExecution execution, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a previously stored workflow execution by its ID.
    /// </summary>
    Task<IWorkflowExecution?> GetExecutionAsync(Guid executionId, CancellationToken cancellationToken);
}