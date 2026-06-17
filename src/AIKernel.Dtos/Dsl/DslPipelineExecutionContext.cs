namespace AIKernel.Dtos.Dsl;

/// <summary>[EN] Documents this public package API member. [JA] DslPipelineExecutionContext を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineExecutionContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineExecutionContext']" />
public sealed record DslPipelineExecutionContext(
    DslPipelineValue Input,
    DateTimeOffset StartedAtUtc);
