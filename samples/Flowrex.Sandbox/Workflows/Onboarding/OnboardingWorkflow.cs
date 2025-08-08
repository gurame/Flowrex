using Flowrex.Abstractions;
using Flowrex.Sandbox.Workflows.Onboarding.Compensations;
using Flowrex.Sandbox.Workflows.Onboarding.Steps;

namespace Flowrex.Sandbox.Workflows.Onboarding;

public class OnboardingWorkflow : IWorkflowDefinition
{
    public IWorkflow Build(IWorkflowBuilder builder)
    {
        var workflow = builder
            .AddStep<CreateUserStep>()
            .AddStep<AddUserToGroupsStep>()
                .WithCompensation<DeleteUserStep>()
            .Build();
        
        return workflow;
    }
}