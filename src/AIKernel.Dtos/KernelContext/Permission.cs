namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Permission の契約を定義します。
/// </summary>
public sealed record Permission(
    string PermissionId,
    string Description,
    string Scope,
    DateTime? ExpiresAt,
    bool IsActive,
    IReadOnlyDictionary<string, string>? Metadata);


