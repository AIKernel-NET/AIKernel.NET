namespace AIKernel.Dtos.Vfs;

/// <summary>
/// VfsProviderHealth の契約を定義します。
/// </summary>
public sealed record VfsProviderHealth
{
    public required bool IsHealthy { get; init; }
    public string? Message { get; init; }
    public required DateTimeOffset CheckedAtUtc { get; init; }
}



