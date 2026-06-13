namespace AIKernel.Dtos.Events;

/// <summary>
/// PipelineEvent の契約を定義します。
/// JA: PipelineEvent の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.PipelineEvent']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.PipelineEvent']" />
public sealed record PipelineEvent(
    string EventId,
    string PipelineId,
    string StageName,
    DateTime EventTime,
    string Status,
    long DurationMs,
    string? Description,
    IReadOnlyDictionary<string, string>? Metadata);


