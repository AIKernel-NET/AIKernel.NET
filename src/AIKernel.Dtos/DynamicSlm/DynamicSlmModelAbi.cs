namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmModelAbi(
    string ModelId,
    string Version,
    DynamicSlmSemanticProfile SemanticProfile,
    DynamicSlmCapabilityGraph CapabilityGraph,
    DynamicSlmExecutionProfile ExecutionProfile,
    DynamicSlmLineage Lineage,
    IReadOnlyList<DynamicSlmPayloadDescriptor> Payloads,
    SeedSlmProfile? SeedProfile,
    IReadOnlyDictionary<string, string> Metadata);
