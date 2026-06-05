using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// Deterministic complexity profile used to decide whether stochastic inference may begin.
/// </summary>
public sealed record TaskComplexityProfile(
    string ProfileId,
    long InputSizeEstimate,
    TaskCostClass EstimatedCostClass,
    int? RecursionDepthEstimate,
    long? SearchSpaceEstimate,
    bool VerificationHard,
    bool SelfReferential,
    IReadOnlyDictionary<string, string> Metadata);
