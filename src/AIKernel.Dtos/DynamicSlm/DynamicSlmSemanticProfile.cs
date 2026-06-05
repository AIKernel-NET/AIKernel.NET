namespace AIKernel.Dtos.DynamicSlm;

public sealed record DynamicSlmSemanticProfile(
    string ProfileId,
    string Scope,
    IReadOnlyList<string> TaskDomains,
    IReadOnlyList<string> InputAssumptions,
    string OutputSchema,
    IReadOnlyList<string> ReplayLogCompatibility);
