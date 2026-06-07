namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmResolvedSubgraph']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmResolvedSubgraph']" />
public sealed record DynamicSlmResolvedSubgraph(
    string ModelId,
    IReadOnlyList<DynamicSlmCapabilityNode> Nodes,
    IReadOnlyList<DynamicSlmCapabilityEdge> Edges,
    IReadOnlyList<DynamicSlmPayloadDescriptor> RequiredPayloads);
