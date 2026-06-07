namespace AIKernel.Dtos.Routing;

/// <summary>
/// PaddingStrategy の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.PaddingStrategy']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.PaddingStrategy']" />
public sealed record PaddingStrategy(
    string PaddingType,
    int PhysicalCardinality,
    int LogicalCardinality,
    string? Rationale);



