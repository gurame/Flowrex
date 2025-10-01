namespace Flowrex.Results;

/// <summary>
/// Represents the result of a workflow step execution, including output or error.
/// </summary>
public sealed class StepResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StepResult"/> class.
    /// </summary>
    /// <param name="output">The output of the step.</param>
    /// <param name="error">The error message if the step failed.</param>
    private StepResult(object? output, string? error)
    {
        Output = output;
        Error = error;
    }

    /// <summary>
    /// Gets a value indicating whether the step completed successfully.
    /// </summary>
    public bool IsSuccess => Error is null;

    /// <summary>
    /// Gets a value indicating whether the step failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets optional output of the step. May be null.
    /// </summary>
    public object? Output { get; }

    /// <summary>
    /// Gets optional error message, populated only if the step failed.
    /// </summary>
    public string? Error { get; }

    /// <summary>
    /// Creates a successful result, optionally containing output.
    /// </summary>
    /// <param name="output">Optional output data from the step.</param>
    /// <returns>A successful StepResult.</returns>
    public static StepResult Success(object? output = null) => new(output, null);

    /// <summary>
    /// Creates a failed result with an error message.
    /// </summary>
    /// <param name="error">The error message describing the failure.</param>
    /// <returns>A failed StepResult.</returns>
    public static StepResult Failure(string error) => new(null, error);
}
