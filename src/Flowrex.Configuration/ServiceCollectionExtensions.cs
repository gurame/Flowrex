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

        // Discover and register all IWorkflowDefinition
        services.Scan(scan => scan
            .FromAssemblies(options.AssemblyToScan ?? Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo<IWorkflowDefinition>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        // Discover and register all IWorkflowStep and ICompensableStep as self
        services.Scan(scan => scan
            .FromAssemblies(options.AssemblyToScan ?? Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo<IWorkflowStep>())
            .AsSelf()
            .WithTransientLifetime()
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