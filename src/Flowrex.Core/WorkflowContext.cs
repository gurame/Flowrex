using Flowrex.Abstractions;

namespace Flowrex.Core;

/// <summary>
/// Default implementation of IWorkflowContext. Used to store typed values, step outputs and resolve services.
/// </summary>
public sealed class WorkflowContext(IServiceProvider serviceProvider) : IWorkflowContext
{
    private readonly Dictionary<Type, object> _typedData = new();
    private readonly Dictionary<string, object?> _namedOutputs = new();

    public Guid ExecutionId { get; } = Guid.NewGuid();

    /// <summary>
    /// Sets a typed value that can be shared across steps.
    /// </summary>
    public void Set<T>(T value) where T : notnull
    {
        _typedData[typeof(T)] = value!;
    }

    /// <summary>
    /// Gets a typed value that was previously stored.
    /// </summary>
    public T? Get<T>() where T : notnull
    {
        return _typedData.TryGetValue(typeof(T), out var value)
            ? (T)value
            : default;
    }

    /// <summary>
    /// Checks if a typed value is present.
    /// </summary>
    public bool Contains<T>() where T : notnull
    {
        return _typedData.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Gets a service from the DI container.
    /// </summary>
    public TService GetService<TService>() where TService : notnull
    {
        return (TService)serviceProvider.GetService(typeof(TService))!
            ?? throw new InvalidOperationException($"Service of type {typeof(TService).Name} not found.");
    }

    /// <summary>
    /// Stores the output of a step using a string key.
    /// </summary>
    public void SetOutput(string key, object? value)
    {
        _namedOutputs[key] = value;
    }

    /// <summary>
    /// Gets a previously stored output by key and casts it to the expected type.
    /// </summary>
    public T? GetOutput<T>(string key)
    {
        return _namedOutputs.TryGetValue(key, out var value) ? (T?)value : default;
    }
}
