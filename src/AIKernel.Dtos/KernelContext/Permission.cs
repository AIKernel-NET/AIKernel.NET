namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Permission の契約を定義します。
/// JA: Permission の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Permission']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Permission']" />
public sealed record Permission(
    string PermissionId,
    string Description,
    string Scope,
    DateTime? ExpiresAt,
    bool IsActive,
    IReadOnlyDictionary<string, string>? Metadata);


