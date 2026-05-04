using AIKernel.Enums;

namespace AIKernel.Dtos.Vfs;

public sealed record VfsEntry
{
    public required string Name { get; init; }
    public required VfsEntryType Type { get; init; }
    public required string Path { get; init; }
    public long Size { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime ModifiedAt { get; init; }
}
