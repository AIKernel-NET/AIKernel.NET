namespace AIKernel.Dtos.DynamicSlm;

/// <summary>[EN] Documents this public package API member. [JA] DynamicSlmDistillationPlan を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationPlan']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.DynamicSlm.DynamicSlmDistillationPlan']" />
public sealed record DynamicSlmDistillationPlan(
    string PlanId,
    DynamicSlmDistillationRequest Request,
    IReadOnlyList<DynamicSlmPayloadDescriptor> ExpectedOutputs,
    IReadOnlyDictionary<string, string> ValidationPolicy,
    IReadOnlyDictionary<string, string> Metadata);
