namespace AIKernel.Dtos.Rom;

/// <summary>
/// ResolvableEntity の契約を定義します。
/// </summary>
public sealed record ResolvableEntity
{
    public required string Id { get; init; }
    public required string Type { get; init; }
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}




