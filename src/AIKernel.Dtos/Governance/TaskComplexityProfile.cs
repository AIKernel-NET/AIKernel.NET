using AIKernel.Enums;

namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: Deterministic complexity profile used to decide whether stochastic inference may begin.
/// EN: Documentation for public API. JA: TaskComplexityProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.TaskComplexityProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.TaskComplexityProfile']" />
public sealed record TaskComplexityProfile(
    string ProfileId,
    long InputSizeEstimate,
    TaskCostClass EstimatedCostClass,
    int? RecursionDepthEstimate,
    long? SearchSpaceEstimate,
    bool VerificationHard,
    bool SelfReferential,
    IReadOnlyDictionary<string, string> Metadata);
