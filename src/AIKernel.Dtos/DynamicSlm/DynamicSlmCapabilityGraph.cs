using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmCapabilityNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityNode']" />
public sealed record DynamicSlmCapabilityNode(
    string CapabilityId,
    string Name,
    string SemanticProfileId,
    IReadOnlyList<string> PayloadIds,
    IReadOnlyList<string> Tags);

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmCapabilityEdge を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityEdge']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityEdge']" />
public sealed record DynamicSlmCapabilityEdge(
    string FromCapabilityId,
    string ToCapabilityId,
    DynamicSlmCapabilityRelationKind RelationKind);

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmCapabilityGraph を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGraph']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmCapabilityGraph']" />
public sealed record DynamicSlmCapabilityGraph(
    IReadOnlyList<DynamicSlmCapabilityNode> Nodes,
    IReadOnlyList<DynamicSlmCapabilityEdge> Edges);
