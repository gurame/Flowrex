using Flowrex.Abstractions;

namespace Flowrex.Core;

public sealed class WorkflowBuilder(string workflowName) : IWorkflowBuilder, IStepBuilder
{
    private readonly List<WorkflowStepDefinition> _steps = [];

    public IStepBuilder AddStep<TStep>() where TStep : class, IWorkflowStep
    {
        _steps.Add(new WorkflowStepDefinition(typeof(TStep)));
        return this;
    }

    public IStepBuilder WithCompensation<TCompensation>() where TCompensation : class, ICompensableStep
    {
        if (_steps.Count == 0)
            throw new InvalidOperationException("No step to attach compensation to.");

        var last = _steps[^1];
        _steps[^1] = new WorkflowStepDefinition(last.StepType, typeof(TCompensation));
        return this;
    }

    public IWorkflow Build()
    {
        if (_steps.Count == 0)
            throw new InvalidOperationException("Cannot build a workflow with no steps.");

        return new Workflow(workflowName, _steps);
    }
}