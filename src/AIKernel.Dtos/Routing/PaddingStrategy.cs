namespace AIKernel.Dtos.Routing;

/// <summary>
/// PaddingStrategy の契約を定義します。
/// </summary>
public sealed record PaddingStrategy(
    string PaddingType,
    int PhysicalCardinality,
    int LogicalCardinality,
    string? Rationale);



