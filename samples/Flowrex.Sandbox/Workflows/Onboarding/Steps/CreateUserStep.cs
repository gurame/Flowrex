using Flowrex.Abstractions;
using Flowrex.Results;
using Microsoft.Extensions.Logging;

namespace Flowrex.Sandbox.Workflows.Onboarding.Steps;

public class CreateUserStep(ILogger<CreateUserStep> logger) : IWorkflowStep
{
    public async Task<StepResult> ExecuteAsync(IWorkflowContext context, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating user");
        await Task.Delay(500, cancellationToken);
        context.SetOutput("UserId", Guid.NewGuid());
        return StepResult.Success();
    }
}
