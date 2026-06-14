namespace AIKernel.Dtos.Security;

/// <summary>
/// PermissionConstraint の契約を定義します。
/// JA: PermissionConstraint の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PermissionConstraint']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PermissionConstraint']" />
public sealed record PermissionConstraint
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.ConstraintType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.ConstraintType']" />
    public required string ConstraintType { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Value']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Value']" />
    public required string Value { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Description']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Description']" />
    public string? Description { get; init; }
}



