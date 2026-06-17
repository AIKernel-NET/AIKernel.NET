namespace AIKernel.Dtos.Dsl;

/// <summary>[EN] Documents this public package API member. [JA] DslPipelineState を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineState']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineState']" />
public sealed record DslPipelineState(
    string PipelineId,
    string CurrentNode,
    int ExecutedNodeCount);
