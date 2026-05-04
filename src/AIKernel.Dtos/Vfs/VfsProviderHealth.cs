namespace AIKernel.Dtos.Vfs;

public sealed record VfsProviderHealth
{
    public required bool IsHealthy { get; init; }
    public string? Message { get; init; }
    public required DateTimeOffset CheckedAtUtc { get; init; }
}
