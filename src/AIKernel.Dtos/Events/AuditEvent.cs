using AIKernel.Enums;

namespace AIKernel.Dtos.Events;

/// <summary>
/// AuditEvent の契約を定義します。
/// </summary>
public sealed record AuditEvent(
    string EventId,
    string EventType,
    DateTime Timestamp,
    string Subject,
    string Description,
    AuditSeverity Severity,
    IReadOnlyDictionary<string, string> Metadata);


