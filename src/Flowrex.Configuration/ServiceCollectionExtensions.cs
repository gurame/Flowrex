using System.Reflection;
using Flowrex.Abstractions;
using Flowrex.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Flowrex.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFlowrex(this IServiceCollection services, Action<FlowrexOptions>? configure = null)
    {
        var options = new FlowrexOptions();
        configure?.Invoke(options);

        services.AddSingleton(typeof(IWorkflowStore), options.WorkflowStoreType!);
        services.AddSingleton(typeof(ICompensationStrategy), options.CompensationStrategyType!);
        services.AddTransient<IWorkflowExecutor, WorkflowExecutor>();

        var assemblyToScan = options.AssemblyToScan ?? Assembly.GetExecutingAssembly();
        
        // Discover and register all IWorkflowDefinition
        services.Scan(scan => scan
            .FromAssemblies(assemblyToScan)
            .AddClasses(c => c.AssignableTo<IWorkflowDefinition>())
            .AddClasses(c => c.AssignableTo<IWorkflowStep>())
            .AddClasses(c => c.AssignableTo<ICompensableStep>())
            .AsSelf()
            .WithTransientLifetime());

        return services;
    }
    
    public static FlowrexOptions RegisterWorkflowsFromAssemblyContaining<T>(this FlowrexOptions options)
    {
        options.AssemblyToScan = typeof(T).Assembly;
        return options;
    }
}