namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Environment の契約を定義します。
/// JA: Environment の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Environment']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Environment']" />
public sealed record Environment(
    string EnvironmentId,
    string Name,
    string? Region,
    IReadOnlyDictionary<string, string>? Variables,
    IReadOnlyDictionary<string, string>? Configuration,
    bool IsProduction);


