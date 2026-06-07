namespace AIKernel.Dtos.Dsl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineState']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineState']" />
public sealed record DslPipelineState(
    string PipelineId,
    string CurrentNode,
    int ExecutedNodeCount);
