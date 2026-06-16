using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Runtime;

namespace AIKernel.Dtos.Runtime;

/// <summary>
/// EN: Identifies a runtime boundary.
/// [EN] Documents this public package API member. [JA] RuntimeHandle の公開契約を定義します。
/// </summary>
public sealed record RuntimeHandle
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>EN: Gets the runtime instance identifier. JA: InstanceId を取得します。</summary>
    public string? InstanceId { get; init; }

    /// <summary>EN: Gets handle metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Describes a runtime.
/// [EN] Documents this public package API member. [JA] RuntimeDescriptor の公開契約を定義します。
/// </summary>
public sealed record RuntimeDescriptor
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>EN: Gets the runtime display name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>EN: Gets the runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>EN: Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime attach request.
/// [EN] Documents this public package API member. [JA] RuntimeAttachRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeAttachRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;

    /// <summary>EN: Gets the attachment mode. JA: Mode を取得します。</summary>
    public RuntimeAttachmentMode Mode { get; init; } = RuntimeAttachmentMode.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime attach result.
/// [EN] Documents this public package API member. [JA] RuntimeAttachResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeAttachResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether attach succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets attach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when attach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime detach request.
/// [EN] Documents this public package API member. [JA] RuntimeDetachRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeDetachRequest
{
    /// <summary>EN: Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime detach result.
/// [EN] Documents this public package API member. [JA] RuntimeDetachResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeDetachResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether detach succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resulting runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets detach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when detach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime control request.
/// [EN] Documents this public package API member. [JA] RuntimeControlRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeControlRequest
{
    /// <summary>EN: Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the requested operation. JA: Operation を取得します。</summary>
    public RuntimeControlOperation Operation { get; init; } = RuntimeControlOperation.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime control result.
/// [EN] Documents this public package API member. [JA] RuntimeControlResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeControlResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether control succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resulting runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>EN: Gets the runtime failure kind. JA: FailureKind を取得します。</summary>
    public RuntimeFailureKind FailureKind { get; init; } = RuntimeFailureKind.Unknown;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets control diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when control was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime snapshot request.
/// [EN] Documents this public package API member. [JA] RuntimeSnapshotRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeSnapshotRequest
{
    /// <summary>EN: Gets the runtime handle. JA: Handle を取得します。</summary>
    public RuntimeHandle? Handle { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime probe request.
/// [EN] Documents this public package API member. [JA] RuntimeProbeRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeProbeRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets probe metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a runtime probe result.
/// [EN] Documents this public package API member. [JA] RuntimeProbeResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeProbeResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether probe succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets whether the runtime is available. JA: IsAvailable を取得します。</summary>
    public bool IsAvailable { get; init; }

    /// <summary>EN: Gets the runtime descriptor. JA: Runtime を取得します。</summary>
    public RuntimeDescriptor? Runtime { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets probe diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when probe was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Identifies a process boundary.
/// [EN] Documents this public package API member. [JA] ProcessHandle の公開契約を定義します。
/// </summary>
public sealed record ProcessHandle
{
    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string ProcessId { get; init; } = string.Empty;

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets handle metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process list request.
/// [EN] Documents this public package API member. [JA] ProcessListRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessListRequest
{
    /// <summary>EN: Gets the runtime handle. JA: Runtime を取得します。</summary>
    public RuntimeHandle? Runtime { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process list result.
/// [EN] Documents this public package API member. [JA] ProcessListResult の公開契約を定義します。
/// </summary>
public sealed record ProcessListResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether list succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets process descriptors. JA: Processes を取得します。</summary>
    public IReadOnlyList<ProcessDescriptor> Processes { get; init; } = [];

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when the result was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process query request.
/// [EN] Documents this public package API member. [JA] ProcessQueryRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessQueryRequest
{
    /// <summary>EN: Gets the process handle. JA: Process を取得します。</summary>
    public ProcessHandle? Process { get; init; }

    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets query metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Describes a runtime process.
/// [EN] Documents this public package API member. [JA] ProcessDescriptor の公開契約を定義します。
/// </summary>
public sealed record ProcessDescriptor
{
    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string ProcessId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether process description succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets the process display name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>EN: Gets the process state. JA: State を取得します。</summary>
    public ProcessStateKind State { get; init; } = ProcessStateKind.Unknown;

    /// <summary>EN: Gets when the descriptor was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets process diagnostics. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process control request.
/// [EN] Documents this public package API member. [JA] ProcessControlRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessControlRequest
{
    /// <summary>EN: Gets the process handle. JA: Process を取得します。</summary>
    public ProcessHandle? Process { get; init; }

    /// <summary>EN: Gets the requested operation. JA: Operation を取得します。</summary>
    public ProcessControlOperation Operation { get; init; } = ProcessControlOperation.Unknown;

    /// <summary>EN: Gets the process signal. JA: Signal を取得します。</summary>
    public ProcessSignalKind Signal { get; init; } = ProcessSignalKind.Unknown;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process control result.
/// [EN] Documents this public package API member. [JA] ProcessControlResult の公開契約を定義します。
/// </summary>
public sealed record ProcessControlResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether process control succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resulting process state. JA: State を取得します。</summary>
    public ProcessStateKind State { get; init; } = ProcessStateKind.Unknown;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets process diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when control was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process attach request.
/// [EN] Documents this public package API member. [JA] ProcessAttachRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessAttachRequest
{
    /// <summary>EN: Gets the runtime handle. JA: Runtime を取得します。</summary>
    public RuntimeHandle? Runtime { get; init; }

    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets attach metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process attach result.
/// [EN] Documents this public package API member. [JA] ProcessAttachResult の公開契約を定義します。
/// </summary>
public sealed record ProcessAttachResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether attach succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the process handle. JA: Handle を取得します。</summary>
    public ProcessHandle? Handle { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets attach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when attach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process detach request.
/// [EN] Documents this public package API member. [JA] ProcessDetachRequest の公開契約を定義します。
/// </summary>
public sealed record ProcessDetachRequest
{
    /// <summary>EN: Gets the process handle. JA: Process を取得します。</summary>
    public ProcessHandle? Process { get; init; }

    /// <summary>EN: Gets detach metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a process detach result.
/// [EN] Documents this public package API member. [JA] ProcessDetachResult の公開契約を定義します。
/// </summary>
public sealed record ProcessDetachResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether detach succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets detach diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when detach was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
