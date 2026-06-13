namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Identity の契約を定義します。
/// JA: Identity の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Identity']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Identity']" />
public sealed record Identity(
    string Id,
    string Name,
    string Type,
    string? Email,
    string? Organization,
    IReadOnlyDictionary<string, string>? Metadata,
    DateTime CreatedAt);


