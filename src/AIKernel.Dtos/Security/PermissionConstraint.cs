namespace AIKernel.Dtos.Security;

public sealed record PermissionConstraint
{
    public required string ConstraintType { get; init; }
    public required string Value { get; init; }
    public string? Description { get; init; }
}
