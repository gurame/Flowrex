using Flowrex;
using Flowrex.Abstractions;
using Flowrex.Configuration;
using Flowrex.Sandbox.Workflows.Onboarding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = new ServiceCollection();
services.AddLogging(builder => builder.AddConsole());

services.AddFlowrex(options =>
{
    options.RegisterWorkflowsFromAssemblyContaining<Program>();
});

var provider = services.BuildServiceProvider();
var executor = provider.GetRequiredService<IWorkflowExecutor>();

var result = await executor.ExecuteAsync<OnboardingWorkflow>();

if (result.IsSuccess)
    Console.WriteLine("✅ ¡Workflow ejecutado con éxito!");
else
    Console.WriteLine($"❌ Falló el workflow: {result.Error}");