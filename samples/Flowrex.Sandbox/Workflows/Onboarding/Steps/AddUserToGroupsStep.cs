using Flowrex.Abstractions;
using Flowrex.Results;
using Microsoft.Extensions.Logging;

namespace Flowrex.Sandbox.Workflows.Onboarding.Steps;
public class AddUserToGroupsStep(ILogger<AddUserToGroupsStep> logger) : IWorkflowStep
{
    public async Task<StepResult> ExecuteAsync(IWorkflowContext context, CancellationToken cancellationToken)
    {
        var userId = context.GetOutput<Guid>("UserId");
        
        logger.LogInformation("Adding user {UserId} to groups", userId);
        await Task.Delay(500, cancellationToken);
        
        return StepResult.Success();
    }
}