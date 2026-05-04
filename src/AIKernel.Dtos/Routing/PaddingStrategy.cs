namespace AIKernel.Dtos.Routing;

public sealed record PaddingStrategy(
    string PaddingType,
    int PhysicalCardinality,
    int LogicalCardinality,
    string? Rationale);
