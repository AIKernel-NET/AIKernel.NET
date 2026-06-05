namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmResolvedSubgraph(
    string ModelId,
    IReadOnlyList<DynamicSlmCapabilityNode> Nodes,
    IReadOnlyList<DynamicSlmCapabilityEdge> Edges,
    IReadOnlyList<DynamicSlmPayloadDescriptor> RequiredPayloads);
