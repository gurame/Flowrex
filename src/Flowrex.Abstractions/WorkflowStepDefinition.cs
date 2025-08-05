namespace Flowrex.Abstractions;

/// <summary>
/// Represents a workflow step and its optional compensation step.
/// </summary>
public sealed class WorkflowStepDefinition(Type stepType, Type? compensationStepType = null)
{
    /// <summary>
    /// The main step to execute.
    /// </summary>
    public Type StepType { get; } = stepType ?? throw new ArgumentNullException(nameof(stepType));

    /// <summary>
    /// The optional compensating step to execute if the main step fails.
    /// </summary>
    public Type? CompensationStepType { get; } = compensationStepType;
}