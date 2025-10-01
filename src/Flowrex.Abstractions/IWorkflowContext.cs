namespace Flowrex.Abstractions;

/// <summary>
/// Provides contextual information and scoped service access during the execution of a workflow step.
/// </summary>
public interface IWorkflowContext
{
    /// <summary>
    /// Gets the unique execution ID of the workflow instance.
    /// </summary>
    Guid ExecutionId { get; }

    /// <summary>
    /// Retrieves a service from the workflow's scoped service provider.
    /// </summary>
    /// <typeparam name="TService">The type of the service to retrieve.</typeparam>
    /// <returns>An instance of the requested service.</returns>
    TService GetService<TService>()
        where TService : notnull;

    /// <summary>
    /// Sets the output for the currently executing step.
    /// </summary>
    /// <param name="stepName">The name of the step.</param>
    /// <param name="output">The output object to store.</param>
    void SetOutput(string stepName, object? output);

    /// <summary>
    /// Gets the output of a previously executed step by its name.
    /// </summary>
    /// <typeparam name="T">The expected type of the output.</typeparam>
    /// <param name="stepName">The name of the step whose output is being retrieved.</param>
    /// <returns>The output cast to type <typeparamref name="T"/>.</returns>
    T? GetOutput<T>(string stepName);
}
