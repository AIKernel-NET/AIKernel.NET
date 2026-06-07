namespace AIKernel.Dtos.Events;

/// <summary>
/// GuardEvent の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.GuardEvent']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.GuardEvent']" />
public sealed record GuardEvent(
    string EventId,
    DateTime EventTime,
    string Decision,
    string? Resource,
    string? Action,
    string? Reason,
    IReadOnlyDictionary<string, string>? Metadata);


