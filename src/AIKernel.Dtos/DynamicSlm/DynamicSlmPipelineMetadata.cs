namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmPipelineMetadata(
    string PipelineId,
    string? ReplayLogHash,
    string? ModelAbiHash,
    string? CapabilityGraphHash,
    string? LineageHash,
    string? PlacementPlanId,
    IReadOnlyDictionary<string, string> Values);
