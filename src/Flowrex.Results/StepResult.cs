namespace Flowrex.Results;

/// <summary>
/// Represents the result of a workflow step execution, including output or error.
/// </summary>
public sealed class StepResult
{
    /// <summary>
    /// Indicates whether the step completed successfully.
    /// </summary>
    public bool IsSuccess => Error is null;
    
    /// <summary>
    /// Indicates whether the step failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;
    /// <summary>
    /// Optional output of the step. May be null.
    /// </summary>
    public object? Output { get; }

    /// <summary>
    /// Optional error message, populated only if the step failed.
    /// </summary>
    public string? Error { get; }

    private StepResult(object? output, string? error)
    {
        Output = output;
        Error = error;
    }

    /// <summary>
    /// Creates a successful result, optionally containing output.
    /// </summary>
    public static StepResult Success(object? output = null) => new(output, null);

    /// <summary>
    /// Creates a failed result with an error message.
    /// </summary>
    public static StepResult Failure(string error) => new(null, error);
}