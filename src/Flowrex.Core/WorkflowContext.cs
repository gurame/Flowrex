using Flowrex.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Flowrex.Core;

/// <summary>
/// Default implementation of IWorkflowContext. Used to store typed values, step outputs and resolve services.
/// </summary>
public sealed class WorkflowContext(IServiceProvider serviceProvider) : IWorkflowContext
{
    private readonly Dictionary<Type, object> typedData = [];
    private readonly Dictionary<string, object?> namedOutputs = [];
    public Guid ExecutionId { get; } = Guid.NewGuid();

    /// <summary>
    /// Sets a typed value that can be shared across steps.
    /// </summary>
    public void Set<T>(T value)
        where T : notnull
    {
        typedData[typeof(T)] = value!;
    }

    /// <summary>
    /// Gets a typed value that was previously stored.
    /// </summary>
    public T? Get<T>()
        where T : notnull
    {
        return typedData.TryGetValue(typeof(T), out var value)
            ? (T)value
            : default;
    }

    /// <summary>
    /// Checks if a typed value is present.
    /// </summary>
    public bool Contains<T>()
        where T : notnull
    {
        return typedData.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Gets a service from the DI container.
    /// </summary>
    public TService GetService<TService>() where TService : notnull
    {
        return serviceProvider.GetRequiredService<TService>();
    }

    /// <summary>
    /// Stores the output of a step using a string key.
    /// </summary>
    public void SetOutput(string key, object? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        namedOutputs[key] = value;
    }

    /// <summary>
    /// Gets a previously stored output by key and casts it to the expected type.
    /// </summary>
    /// <exception cref="InvalidCastException">Thrown when the stored value cannot be cast to type T.</exception>
    public T? GetOutput<T>(string key)
    {
        if (!namedOutputs.TryGetValue(key, out var value))
        {
            return default;
        }

        if (value is null)
        {
            return default;
        }

        if (value is T typedValue)
        {
            return typedValue;
        }

        throw new InvalidCastException(
            $"Cannot cast output value for key '{key}' from type '{value.GetType().FullName}' to type '{typeof(T).FullName}'.");
    }
}
