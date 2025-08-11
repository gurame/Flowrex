namespace Flowrex.Configuration;

public static class FlowrexOptionsExtensions
{
    public static FlowrexOptions RegisterWorkflowsFromAssemblyContaining<T>(this FlowrexOptions options)
    {
        options.AssemblyToScan = typeof(T).Assembly;
        return options;
    }
}