namespace Flowrex.Abstractions;

/// <summary>
/// Represents a workflow step and its optional compensation step.
/// </summary>
public sealed class WorkflowStepDefinition
{
    /// <summary>
    /// Gets the main step to execute.
    /// </summary>
    public Type StepType { get; }

    /// <summary>
    /// Gets the optional compensating step to execute if the main step fails.
    /// </summary>
    public Type? CompensationStepType { get; }

    public WorkflowStepDefinition(Type stepType, Type? compensationStepType = null)
    {
        ArgumentNullException.ThrowIfNull(stepType);

        if (!typeof(IWorkflowStep).IsAssignableFrom(stepType))
        {
            throw new ArgumentException(
                $"Type '{stepType.FullName}' must implement IWorkflowStep.",
                nameof(stepType));
        }

        if (stepType.IsAbstract || stepType.IsInterface)
        {
            throw new ArgumentException(
                $"Type '{stepType.FullName}' cannot be abstract or an interface.",
                nameof(stepType));
        }

        if (compensationStepType is not null)
        {
            if (!typeof(ICompensableStep).IsAssignableFrom(compensationStepType))
            {
                throw new ArgumentException(
                    $"Type '{compensationStepType.FullName}' must implement ICompensableStep.",
                    nameof(compensationStepType));
            }

            if (compensationStepType.IsAbstract || compensationStepType.IsInterface)
            {
                throw new ArgumentException(
                    $"Type '{compensationStepType.FullName}' cannot be abstract or an interface.",
                    nameof(compensationStepType));
            }
        }

        StepType = stepType;
        CompensationStepType = compensationStepType;
    }
}
