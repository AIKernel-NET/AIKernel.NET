namespace AIKernel.Dtos.Routing;

/// <summary>EN: Documentation for public API. JA: RoutingScore を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.RoutingScore']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.RoutingScore']" />
public sealed record RoutingScore(
    double Value,
    string? ProfileId = null,
    IReadOnlyDictionary<string, string>? Metadata = null);
