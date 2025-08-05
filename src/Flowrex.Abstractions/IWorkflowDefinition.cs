namespace Flowrex.Abstractions;

/// <summary>
/// Represents a declarative definition of a workflow. Used to register steps using the builder pattern.
/// </summary>
public interface IWorkflowDefinition
{
    /// <summary>
    /// The name of the workflow. Used as a unique identifier.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Registers the steps of the workflow using the builder.
    /// </summary>
    void Build(IWorkflowBuilder builder);
}
