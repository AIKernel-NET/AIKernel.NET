namespace AIKernel.Dtos.Vfs;

public sealed record VfsQuerySort
{
    public required string FieldName { get; init; }
    public bool Ascending { get; init; } = true;
}
