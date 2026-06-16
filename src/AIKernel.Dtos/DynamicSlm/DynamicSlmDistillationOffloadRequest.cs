namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmDistillationOffloadRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationOffloadRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationOffloadRequest']" />
public sealed record DynamicSlmDistillationOffloadRequest(
    DynamicSlmDistillationPlan Plan,
    string Reason,
    string? ReplayLogHash,
    IReadOnlyDictionary<string, string> Metadata);
