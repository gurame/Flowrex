using Flowrex.Results;

namespace Flowrex.Abstractions;

/// <summary>
/// Represents a lightweight, serializable snapshot of a workflow's execution state.
/// </summary>
public interface IWorkflowExecution
{
    Guid Id { get; }

    string WorkflowName { get; }

    WorkflowStatus Status { get; }

    DateTime StartedAtUtc { get; }

    DateTime? CompletedAtUtc { get; }

    IReadOnlyList<string> ExecutedSteps { get; }
}
