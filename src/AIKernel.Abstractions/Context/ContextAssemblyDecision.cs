namespace AIKernel.Abstractions.Context;

public sealed record ContextAssemblyDecision(
    bool IsAllowed,
    string? Reason = null)
{
    public static ContextAssemblyDecision Allow()
    {
        return new ContextAssemblyDecision(true);
    }

    public static ContextAssemblyDecision Deny(string reason)
    {
        return new ContextAssemblyDecision(false, reason);
    }
}
