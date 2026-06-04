namespace AIKernel.Dtos.Context;

public sealed record ContextAssemblyDecision(
    bool IsAllowed,
    string? Reason = null);
