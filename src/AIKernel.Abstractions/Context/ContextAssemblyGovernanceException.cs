namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Rom;

public sealed class ContextAssemblyGovernanceException : ContextAssemblyException
{
    public ContextAssemblyGovernanceException(RomId romId, string? reason)
        : base($"Context assembly was denied for ROM '{romId.Value}'. {reason}".Trim())
    {
        RomId = romId;
        Reason = reason;
    }

    public RomId RomId { get; }

    public string? Reason { get; }
}
