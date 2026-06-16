namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// EN: TraceContext の契約を定義します。
/// EN: Documentation for public API. JA: TraceContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.TraceContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.TraceContext']" />
public sealed record TraceContext(
    string TraceId,
    string? SpanId,
    string? ParentSpanId,
    DateTime StartTime,
    DateTime? EndTime,
    IReadOnlyDictionary<string, string>? Tags,
    IReadOnlyList<TraceLog>? Logs);


