namespace AIKernel.Dtos.Rom;

/// <summary>
/// EntityTypeSchema の契約を定義します。
/// </summary>
public sealed record EntityTypeSchema
{
    public required string TypeName { get; init; }
    public IReadOnlyList<string> RequiredProperties { get; init; } = new List<string>();
    public IReadOnlyList<string> AllowedProperties { get; init; } = new List<string>();
    public IReadOnlyDictionary<string, string> PropertyTypes { get; init; } = new Dictionary<string, string>();
}




