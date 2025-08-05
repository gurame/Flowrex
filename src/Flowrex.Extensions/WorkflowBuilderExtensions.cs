using Flowrex.Abstractions;

namespace Flowrex.Extensions;

/// <summary>
/// Provides extension methods to enhance the Flowrex workflow builder fluent API.
/// </summary>
public static class WorkflowBuilderExtensions
{
    /// <summary>
    /// Adds a step with its compensation in a single chained call.
    /// </summary>
    public static IStepBuilder AddStepWithCompensation<TStep, TCompensation>(this IStepBuilder builder)
        where TStep : class, IWorkflowStep
        where TCompensation : class, ICompensableStep
    {
        return builder
            .AddStep<TStep>()
            .WithCompensation<TCompensation>();
    }

    /// <summary>
    /// Uses the name of the workflow definition type as the workflow name.
    /// Useful when registering from IWorkflowDefinition.
    /// </summary>
    public static string GetWorkflowNameFromType<TWorkflow>() where TWorkflow : IWorkflowDefinition
    {
        return typeof(TWorkflow).Name;
    }

    /// <summary>
    /// Registers multiple steps by scanning a static list in a configuration class.
    /// Useful for central definitions.
    /// </summary>
    public static IStepBuilder AddSteps(this IStepBuilder builder, IEnumerable<Type> stepTypes)
    {
        foreach (var type in stepTypes)
        {
            if (!typeof(IWorkflowStep).IsAssignableFrom(type))
                throw new InvalidOperationException($"{type.Name} does not implement IWorkflowStep");

            var method = typeof(IStepBuilder).GetMethod(nameof(IStepBuilder.AddStep))!;
            method.MakeGenericMethod(type).Invoke(builder, null);
        }

        return builder;
    }
}