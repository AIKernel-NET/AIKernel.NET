namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// TraceLog の契約を定義します。
/// JA: TraceLog の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.TraceLog']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.TraceLog']" />
public sealed record TraceLog(
    string Level,
    string Message,
    DateTime Timestamp,
    IReadOnlyDictionary<string, string>? Data);


