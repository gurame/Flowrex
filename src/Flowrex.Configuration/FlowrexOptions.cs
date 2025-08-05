using System.Reflection;
using Flowrex.Abstractions;
using Flowrex.Core;
using Flowrex.Persistence.InMemory;

namespace Flowrex.Configuration;

public sealed class FlowrexOptions
{
    internal Type? WorkflowStoreType { get; private set; } = typeof(InMemoryWorkflowStore);
    internal Type? CompensationStrategyType { get; private set; } = typeof(DefaultCompensationStrategy);

    public void UseWorkflowStore<T>() where T : class, IWorkflowStore
        => WorkflowStoreType = typeof(T);

    public void UseCompensationStrategy<T>() where T : class, ICompensationStrategy
        => CompensationStrategyType = typeof(T);
    internal Assembly? AssemblyToScan { get; set; }
}