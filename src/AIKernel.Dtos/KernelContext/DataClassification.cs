namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// DataClassification の契約を定義します。
/// </summary>
public sealed record DataClassification(
    string Level,
    IReadOnlyList<string> HandlingPolicies,
    bool RequiresEncryption,
    bool RequiresAuditLog,
    DateTime ClassifiedAt,
    string? Reason);


