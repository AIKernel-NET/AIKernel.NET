namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Identity の契約を定義します。
/// </summary>
public sealed record Identity(
    string Id,
    string Name,
    string Type,
    string? Email,
    string? Organization,
    IReadOnlyDictionary<string, string>? Metadata,
    DateTime CreatedAt);


