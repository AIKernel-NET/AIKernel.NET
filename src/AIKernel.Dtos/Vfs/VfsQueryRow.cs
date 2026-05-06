namespace AIKernel.Dtos.Vfs;

/// <summary>
/// VfsQueryRow の契約を定義します。
/// </summary>
public sealed record VfsQueryRow
{
    public required IReadOnlyDictionary<string, string> Data { get; init; }
}



