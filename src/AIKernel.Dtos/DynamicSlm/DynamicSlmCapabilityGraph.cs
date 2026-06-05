using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmCapabilityNode(
    string CapabilityId,
    string Name,
    string SemanticProfileId,
    IReadOnlyList<string> PayloadIds,
    IReadOnlyList<string> Tags);

public sealed record DynamicSlmCapabilityEdge(
    string FromCapabilityId,
    string ToCapabilityId,
    DynamicSlmCapabilityRelationKind RelationKind);

public sealed record DynamicSlmCapabilityGraph(
    IReadOnlyList<DynamicSlmCapabilityNode> Nodes,
    IReadOnlyList<DynamicSlmCapabilityEdge> Edges);
