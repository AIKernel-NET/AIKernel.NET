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
    IReadOnlyDictionary<string, string> Metadata)
{
    public DynamicSlmModelAbi(
        string modelId,
        string version,
        DynamicSlmSemanticProfile semanticProfile,
        DynamicSlmCapabilityGraph capabilityGraph,
        DynamicSlmExecutionProfile executionProfile,
        DynamicSlmLineage lineage,
        IReadOnlyList<DynamicSlmPayloadDescriptor> payloads,
        IReadOnlyDictionary<string, string> metadata)
        : this(
            modelId,
            version,
            semanticProfile,
            capabilityGraph,
            executionProfile,
            lineage,
            payloads,
            null,
            metadata)
    {
    }
}
