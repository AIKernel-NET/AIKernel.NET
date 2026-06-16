using AIKernel.Enums;

namespace AIKernel.Dtos.DynamicSlm;

/// <summary>EN: Documentation for public API. JA: DynamicSlmDistillationJobDescriptor を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationJobDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationJobDescriptor']" />
public sealed record DynamicSlmDistillationJobDescriptor(
    DynamicSlmDistillationJobId JobId,
    DynamicSlmDistillationPlan Plan,
    DynamicSlmDistillationJobStatus Status,
    IReadOnlyList<string> SourceReplayLogHashes,
    IReadOnlyDictionary<string, string> Metadata);
