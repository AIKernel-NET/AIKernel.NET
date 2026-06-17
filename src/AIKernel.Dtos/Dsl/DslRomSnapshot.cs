namespace AIKernel.Dtos.Dsl;

/// <summary>[EN] Documents this public package API member. [JA] DslRomSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomSnapshot']" />
public sealed record DslRomSnapshot(
    DslRomMetadata Metadata,
    string JsonDsl);
