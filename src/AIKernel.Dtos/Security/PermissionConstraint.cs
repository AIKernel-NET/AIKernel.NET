namespace AIKernel.Dtos.Security;

/// <summary>
/// PermissionConstraint の契約を定義します。
/// </summary>
public sealed record PermissionConstraint
{
    public required string ConstraintType { get; init; }
    public required string Value { get; init; }
    public string? Description { get; init; }
}



