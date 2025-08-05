using Flowrex.Abstractions;
using Flowrex.Sandbox.Workflows.Onboarding.Compensations;
using Flowrex.Sandbox.Workflows.Onboarding.Steps;

namespace Flowrex.Sandbox.Workflows.Onboarding;

public class OnboardingWorkflow : IWorkflowDefinition
{
    public string Name { get; }

    public void Build(IWorkflowBuilder builder)
    {
        builder
            .AddStep<CreateUserStep>()
            .AddStep<AddUserToGroupsStep>()
                .WithCompensation<DeleteUserStep>()
            .Build();
    }
}