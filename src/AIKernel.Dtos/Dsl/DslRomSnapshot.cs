namespace AIKernel.Dtos.Dsl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslRomSnapshot']" />
public sealed record DslRomSnapshot(
    DslRomMetadata Metadata,
    string JsonDsl);
