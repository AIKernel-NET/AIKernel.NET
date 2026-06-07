namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmModelAbi']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmModelAbi']" />
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
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.DynamicSlm.DynamicSlmModelAbi.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.DynamicSlm.DynamicSlmModelAbi.#ctor']" />
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
