namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmSemanticProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmSemanticProfile']" />
public sealed record DynamicSlmSemanticProfile(
    string ProfileId,
    string Scope,
    IReadOnlyList<string> TaskDomains,
    IReadOnlyList<string> InputAssumptions,
    string OutputSchema,
    IReadOnlyList<string> ReplayLogCompatibility);
