namespace Flowrex.Abstractions;

/// <summary>
/// Entry point for defining a workflow. First step must be added.
/// </summary>
public interface IWorkflowBuilder
{
    /// <summary>
    /// Adds the first step in the workflow.
    /// </summary>
    IStepBuilder AddStep<TStep>() where TStep : class, IWorkflowStep;
}