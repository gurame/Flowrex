using System.Collections.Concurrent;
using Flowrex.Abstractions;

namespace Flowrex.Persistence.InMemory;

/// <summary>
/// In-memory implementation of IWorkflowStore for development and testing.
/// </summary>
public sealed class InMemoryWorkflowStore : IWorkflowStore
{
    private readonly ConcurrentDictionary<Guid, IWorkflowExecution> store = new();

    public Task SaveExecutionAsync(IWorkflowExecution execution, CancellationToken cancellationToken)
    {
        store[execution.Id] = execution;
        return Task.CompletedTask;
    }

    public Task<IWorkflowExecution?> GetExecutionAsync(Guid executionId, CancellationToken cancellationToken)
    {
        store.TryGetValue(executionId, out var execution);
        return Task.FromResult(execution);
    }
}
