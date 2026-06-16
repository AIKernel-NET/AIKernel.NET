namespace AIKernel.Dtos.Events;

/// <summary>
/// EN: ProviderEvent の契約を定義します。
/// EN: Documentation for public API. JA: ProviderEvent の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.ProviderEvent']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.ProviderEvent']" />
public sealed record ProviderEvent(
    string EventId,
    DateTime EventTime,
    string ProviderId,
    string EventType,
    string? Description,
    bool Success,
    string? ErrorMessage,
    IReadOnlyDictionary<string, string>? Metadata);


