namespace Flowrex.Abstractions;

/// <summary>
/// Represents a workflow definition. Workflows should implement this interface
/// to define their steps using the IWorkflowBuilder.
/// </summary>
public interface IWorkflow
{
    /// <summary>
    /// Gets the name of the workflow.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the ordered list of step types that make up the workflow.
    /// </summary>
    IReadOnlyList<WorkflowStepDefinition> Steps { get; }
}
