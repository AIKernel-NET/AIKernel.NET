namespace AIKernel.Dtos.Routing;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.RoutingReason']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.RoutingReason']" />
public sealed record RoutingReason(
    string Code,
    string Description,
    IReadOnlyDictionary<string, string>? Metadata = null);
