namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmModelAbi を表します。</summary>
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
    /// <summary>[EN] Documents this public package API member. [JA] DynamicSlmModelAbi を取得します。</summary>
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
