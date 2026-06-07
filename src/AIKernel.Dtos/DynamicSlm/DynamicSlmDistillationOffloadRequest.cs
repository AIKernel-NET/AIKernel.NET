namespace AIKernel.Dtos.DynamicSlm;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationOffloadRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationOffloadRequest']" />
public sealed record DynamicSlmDistillationOffloadRequest(
    DynamicSlmDistillationPlan Plan,
    string Reason,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
