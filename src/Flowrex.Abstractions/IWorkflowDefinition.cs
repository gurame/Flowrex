namespace Flowrex.Abstractions;

/// <summary>
/// Represents a declarative definition of a workflow. Used to register steps using the builder pattern.
/// </summary>
public interface IWorkflowDefinition
{
    /// <summary>
    /// Registers the steps of the workflow using the builder.
    /// </summary>
    IWorkflow Build(IWorkflowBuilder builder);
}
