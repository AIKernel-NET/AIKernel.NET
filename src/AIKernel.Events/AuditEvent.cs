using AIKernel.Abstractions;
using AIKernel.Contracts;
using AIKernel.Enums;

namespace AIKernel.Events;

/// <summary>
/// 監査イベントを表現します。
/// セキュリティ監査とアクティビティログを管理します。
/// </summary>
public sealed class AuditEvent : IAuditEvent
{
    public string EventId { get; init; } = Guid.NewGuid().ToString();
    public string EventType { get; init; } = string.Empty;
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
    public string Subject { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public AuditSeverity Severity { get; init; } = AuditSeverity.Information;
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
