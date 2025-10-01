using Flowrex.Abstractions;
using Flowrex.Results;
using Microsoft.Extensions.Logging;

namespace Flowrex.Sandbox.Workflows.Onboarding.Compensations;

public class DeleteUserStep(ILogger<DeleteUserStep> logger) : ICompensableStep
{
    public async Task<StepResult> CompensateAsync(IWorkflowContext context, CancellationToken cancellationToken)
    {
        var userId = context.GetOutput<Guid>("UserId");
        logger.LogInformation("Compensating DeleteUserStep for UserId: {UserId}", userId);
        await Task.Delay(300, cancellationToken);
        return StepResult.Success();
    }
}
