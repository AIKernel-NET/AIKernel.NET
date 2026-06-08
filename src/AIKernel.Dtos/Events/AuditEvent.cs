using AIKernel.Enums;

namespace AIKernel.Dtos.Events;

/// <summary>
/// AuditEvent の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.AuditEvent']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Events.AuditEvent']" />
public sealed record AuditEvent(
    string EventId,
    string EventType,
    DateTime Timestamp,
    string Subject,
    string Description,
    AuditSeverity Severity,
    IReadOnlyDictionary<string, string> Metadata);


