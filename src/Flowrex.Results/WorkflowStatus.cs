namespace Flowrex.Results;

/// <summary>
/// Represents the current status of a workflow execution.
/// </summary>
public enum WorkflowStatus
{
    /// <summary>
    /// Workflow has been initialized but not started.
    /// </summary>
    Pending = 0,

    /// <summary>
    /// Workflow is currently running.
    /// </summary>
    Running = 1,

    /// <summary>
    /// Workflow completed successfully.
    /// </summary>
    Completed = 2,

    /// <summary>
    /// Workflow failed.
    /// </summary>
    Failed = 3,

    /// <summary>
    /// Workflow was rolled back via compensation.
    /// </summary>
    Compensated = 4,
    
    /// <summary>
    /// Workflow was canceled before completion.
    /// </summary>
    Canceled = 5
}