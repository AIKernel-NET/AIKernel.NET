namespace AIKernel.Dtos.Events;

/// <summary>
/// EN: ExecutionEvent の契約を定義します。
/// [EN] Documents this public package API member. [JA] ExecutionEvent の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.ExecutionEvent']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.ExecutionEvent']" />
public sealed record ExecutionEvent(
    string EventId,
    string ExecutionId,
    string FunctionName,
    DateTime StartTime,
    DateTime? EndTime,
    string Status,
    string? Result,
    string? ErrorMessage,
    IReadOnlyDictionary<string, string>? Metadata);


