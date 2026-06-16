namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: Deterministic side-effect profile evaluated before inference begins.
/// [EN] Documents this public package API member. [JA] CriticalOperationProfile の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.CriticalOperationProfile']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.CriticalOperationProfile']" />
public sealed record CriticalOperationProfile(
    string ProfileId,
    string? OperationSignature,
    bool HasDestructiveEffect,
    bool HasPersistentEffect,
    bool RequiresPrivilege,
    bool HasExternalSideEffect,
    IReadOnlyList<string> SideEffectMarkers,
    IReadOnlyDictionary<string, string> Metadata);
