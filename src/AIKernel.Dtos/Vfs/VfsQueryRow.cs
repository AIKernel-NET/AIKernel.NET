namespace AIKernel.Dtos.Vfs;

public sealed record VfsQueryRow
{
    public required IReadOnlyDictionary<string, string> Data { get; init; }
}
