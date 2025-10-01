using Flowrex.Abstractions;

namespace Flowrex.Core;

/// <summary>
/// Default implementation of IWorkflow. Represents an executable workflow definition with ordered steps.
/// </summary>
public sealed class Workflow : IWorkflow
{
    public string Name { get; }
    public IReadOnlyList<WorkflowStepDefinition> Steps { get; }

    public Workflow(string name, IReadOnlyList<WorkflowStepDefinition> steps)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Workflow name cannot be null or empty.", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(steps);  
        if (steps.Count == 0)
        {
            throw new ArgumentException("Workflow must have at least one step.", nameof(steps));
        }

        Name = name;
        Steps = steps.ToList().AsReadOnly();
    }
}
