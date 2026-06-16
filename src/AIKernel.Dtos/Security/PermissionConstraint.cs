namespace AIKernel.Dtos.Security;

/// <summary>
/// EN: PermissionConstraint の契約を定義します。
/// EN: Documentation for public API. JA: PermissionConstraint の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PermissionConstraint']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PermissionConstraint']" />
public sealed record PermissionConstraint
{
    /// <summary>EN: Documentation for public API. JA: ConstraintType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.ConstraintType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.ConstraintType']" />
    public required string ConstraintType { get; init; }
    /// <summary>EN: Documentation for public API. JA: Value を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Value']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Value']" />
    public required string Value { get; init; }
    /// <summary>EN: Documentation for public API. JA: Description を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Description']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PermissionConstraint.Description']" />
    public string? Description { get; init; }
}



