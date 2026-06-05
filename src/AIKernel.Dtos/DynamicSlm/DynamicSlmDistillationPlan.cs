namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmDistillationPlan(
    string PlanId,
    DynamicSlmDistillationRequest Request,
    IReadOnlyList<DynamicSlmPayloadDescriptor> ExpectedOutputs,
    IReadOnlyDictionary<string, string> ValidationPolicy);
