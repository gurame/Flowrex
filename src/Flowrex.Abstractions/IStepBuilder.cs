namespace Flowrex.Abstractions;

/// <summary>
/// Intermediate builder stage returned after AddStep.
/// Allows chaining WithCompensation or continuing with AddStep.
/// </summary>
public interface IStepBuilder
{
    /// <summary>
    /// Associates a compensating step with the previously added step.
    /// </summary>
    IStepBuilder WithCompensation<TCompensation>()
        where TCompensation : class, ICompensableStep;

    /// <summary>
    /// Adds the next step in the workflow.
    /// </summary>
    IStepBuilder AddStep<TStep>()
        where TStep : class, IWorkflowStep;

    /// <summary>
    /// Finalizes the workflow.
    /// </summary>
    IWorkflow Build();
}
