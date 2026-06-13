using AIKernel.Enums;
using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Runtime;

namespace AIKernel.Dtos.Runtime;

/// <summary>
/// Carries a sandbox runtime preparation result.
/// JA: SandboxRuntimePreparationResult の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimePreparationResult
{
    /// <summary>Gets whether preparation succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the resulting lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets a stable failure code. JA: FailureCode を取得します。</summary>
    public string? FailureCode { get; init; }

    /// <summary>Gets a human-readable failure message. JA: FailureMessage を取得します。</summary>
    public string? FailureMessage { get; init; }

    /// <summary>Gets optional preparation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime start request.
/// JA: SandboxRuntimeStartRequest の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStartRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the requested control mode. JA: ControlMode を取得します。</summary>
    public RuntimeControlMode ControlMode { get; init; } = RuntimeControlMode.ObserveOnly;

    /// <summary>Gets optional start metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime start result.
/// JA: SandboxRuntimeStartResult の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStartResult
{
    /// <summary>Gets whether start succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the runtime process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets the resulting lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets optional start metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime stop request.
/// JA: SandboxRuntimeStopRequest の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStopRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets whether the runtime should be stopped gracefully. JA: Graceful を取得します。</summary>
    public bool Graceful { get; init; } = true;

    /// <summary>Gets optional stop metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime stop result.
/// JA: SandboxRuntimeStopResult の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStopResult
{
    /// <summary>Gets whether stop succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets optional stop metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime status snapshot.
/// JA: RuntimeStatusSnapshot の公開契約を定義します。
/// </summary>
public sealed record RuntimeStatusSnapshot
{
    /// <summary>Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>Gets whether status capture succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets the runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>Gets a health score from 0 to 1. JA: HealthScore を取得します。</summary>
    public double HealthScore { get; init; }

    /// <summary>Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets diagnostics emitted while building the snapshot. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets optional status metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime status request.
/// JA: RuntimeStatusRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeStatusRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets optional status request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Identifies a sandbox runtime instance.
/// JA: SandboxInstanceHandle の公開契約を定義します。
/// </summary>
public sealed record SandboxInstanceHandle
{
    /// <summary>Gets the sandbox instance identifier. JA: InstanceId を取得します。</summary>
    public required string InstanceId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets optional instance metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox process creation request.
/// JA: SandboxProcessCreateRequest の公開契約を定義します。
/// </summary>
public sealed record SandboxProcessCreateRequest
{
    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the process name. JA: ProcessName を取得します。</summary>
    public required string ProcessName { get; init; }

    /// <summary>Gets optional process metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox process snapshot.
/// JA: SandboxProcessSnapshot の公開契約を定義します。
/// </summary>
public sealed record SandboxProcessSnapshot
{
    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public required string ProcessId { get; init; }

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the process state. JA: State を取得します。</summary>
    public RuntimeProcessState State { get; init; } = RuntimeProcessState.Unknown;

    /// <summary>Gets optional process metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a sandbox process.
/// JA: SandboxProcessDescriptor の公開契約を定義します。
/// </summary>
public sealed record SandboxProcessDescriptor
{
    /// <summary>Gets the process identifier. JA: ProcessId を取得します。</summary>
    public required string ProcessId { get; init; }

    /// <summary>Gets the process name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>Gets the process state. JA: State を取得します。</summary>
    public RuntimeProcessState State { get; init; } = RuntimeProcessState.Unknown;

    /// <summary>Gets optional process metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime asset request.
/// JA: RuntimeAssetRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeAssetRequest
{
    /// <summary>Gets the asset identifier. JA: AssetId を取得します。</summary>
    public required string AssetId { get; init; }

    /// <summary>Gets the asset kind. JA: Kind を取得します。</summary>
    public RuntimeAssetKind Kind { get; init; } = RuntimeAssetKind.Unknown;

    /// <summary>Gets the optional artifact URI. JA: ArtifactUri を取得します。</summary>
    public string? ArtifactUri { get; init; }

    /// <summary>Gets the expected content hash. JA: ExpectedHash を取得します。</summary>
    public string? ExpectedHash { get; init; }

    /// <summary>Gets optional asset metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime asset resolution result.
/// JA: RuntimeAssetResolutionResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeAssetResolutionResult
{
    /// <summary>Gets whether asset resolution succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resolved artifact reference. JA: ResolvedReference を取得します。</summary>
    public string? ResolvedReference { get; init; }

    /// <summary>Gets the resolved content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets optional resolution metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a memory asset mount request.
/// JA: MemoryAssetMountRequest の公開契約を定義します。
/// </summary>
public sealed record MemoryAssetMountRequest
{
    /// <summary>Gets the asset identifier. JA: AssetId を取得します。</summary>
    public required string AssetId { get; init; }

    /// <summary>Gets the content hash being mounted. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets the byte length to mount. JA: Length を取得します。</summary>
    public long Length { get; init; }

    /// <summary>Gets optional mount metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a memory asset mount result.
/// JA: MemoryAssetMountResult の公開契約を定義します。
/// </summary>
public sealed record MemoryAssetMountResult
{
    /// <summary>Gets whether mount succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the mount identifier. JA: MountId を取得します。</summary>
    public string? MountId { get; init; }

    /// <summary>Gets optional mount metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
