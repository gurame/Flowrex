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

    public IReadOnlyList<string> ExecutedSteps => executedSteps.AsReadOnly();

    private readonly List<string> executedSteps = [];

    private WorkflowExecution(string workflowName)
    {
        WorkflowName = workflowName;
        Status = WorkflowStatus.Running;
    }

    public void MarkStepExecuted(string stepName)
    {
        if (!executedSteps.Contains(stepName))
        {
            executedSteps.Add(stepName);
        }
    }

    public void Cancel()
    {
        MarkCompleted(WorkflowStatus.Canceled);
    }

    public void Fail()
    {
        MarkCompleted(WorkflowStatus.Failed);
    }

    public void Succeed()
    {
        MarkCompleted(WorkflowStatus.Succeeded);
    }

    private void MarkCompleted(WorkflowStatus finalStatus)
    {
        Status = finalStatus;
        CompletedAtUtc = DateTime.UtcNow;
    }

    public static WorkflowExecution StartNew(string workflowName)
    {
        var execution = new WorkflowExecution(workflowName);
        return execution;
    }
}
