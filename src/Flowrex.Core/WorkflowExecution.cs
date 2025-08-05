using Flowrex.Abstractions;
using Flowrex.Results;

namespace Flowrex.Core;

/// <summary>
/// Represents the execution state of a workflow, including lifecycle metadata and step trace.
/// </summary>
public sealed class WorkflowExecution : IWorkflowExecution
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string WorkflowName { get; private set; } = null!;

    public WorkflowStatus Status { get; private set; } = WorkflowStatus.Pending;

    public DateTime StartedAtUtc { get; private set; } = DateTime.UtcNow;

    public DateTime? CompletedAtUtc { get; private set; }

    public IReadOnlyList<string> ExecutedSteps => _executedSteps.AsReadOnly();
    private readonly List<string> _executedSteps = [];

    private WorkflowExecution() { }
    private WorkflowExecution(string workflowName)
    {
        WorkflowName = workflowName;
    }

    public void MarkStepExecuted(string stepName)
    {
        if (!_executedSteps.Contains(stepName))
        {
            _executedSteps.Add(stepName);
        }
    }

    public void MarkCompleted(WorkflowStatus finalStatus)
    {
        Status = finalStatus;
        CompletedAtUtc = DateTime.UtcNow;
    }

    public static WorkflowExecution StartNew(string workflowName)
        => new(workflowName);
}