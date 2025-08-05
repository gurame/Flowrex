namespace Flowrex.Abstractions;

/// <summary>
/// Defines how to compensate a sequence of executed steps after a failure.
/// </summary>
public interface ICompensationStrategy
{
    Task CompensateAsync(
        IWorkflow workflow,
        IReadOnlyList<WorkflowStepDefinition> executedSteps,
        IWorkflowContext context,
        IServiceProvider serviceProvider,
        CancellationToken cancellationToken);
}