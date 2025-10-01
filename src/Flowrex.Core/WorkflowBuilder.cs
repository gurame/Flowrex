using Flowrex.Abstractions;

namespace Flowrex.Core;

public sealed class WorkflowBuilder(string workflowName) : IWorkflowBuilder, IStepBuilder
{
    private readonly List<WorkflowStepDefinition> steps = [];

    public IStepBuilder AddStep<TStep>()
        where TStep : class, IWorkflowStep
    {
        steps.Add(new WorkflowStepDefinition(typeof(TStep)));
        return this;
    }

    public IStepBuilder WithCompensation<TCompensation>()
        where TCompensation : class, ICompensableStep
    {
        if (steps.Count == 0)
        {
            throw new InvalidOperationException("No step to attach compensation to.");
        }

        var last = steps[^1];
        steps[^1] = new WorkflowStepDefinition(last.StepType, typeof(TCompensation));
        return this;
    }

    public IWorkflow Build()
    {
        if (steps.Count == 0)
        {
            throw new InvalidOperationException("Cannot build a workflow with no steps.");
        }

        return new Workflow(workflowName, steps);
    }
}
