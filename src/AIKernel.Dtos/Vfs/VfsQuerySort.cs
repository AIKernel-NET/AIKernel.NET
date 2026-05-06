namespace AIKernel.Dtos.Vfs;

/// <summary>
/// VfsQuerySort の契約を定義します。
/// </summary>
public sealed record VfsQuerySort
{
    public required string FieldName { get; init; }
    public bool Ascending { get; init; } = true;
}



