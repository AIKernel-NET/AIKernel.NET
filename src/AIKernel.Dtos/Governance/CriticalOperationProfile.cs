namespace AIKernel.Dtos.Governance;

/// <summary>
/// Deterministic side-effect profile evaluated before inference begins.
/// </summary>
public sealed record CriticalOperationProfile(
    string ProfileId,
    string? OperationSignature,
    bool HasDestructiveEffect,
    bool HasPersistentEffect,
    bool RequiresPrivilege,
    bool HasExternalSideEffect,
    IReadOnlyList<string> SideEffectMarkers,
    IReadOnlyDictionary<string, string> Metadata);
