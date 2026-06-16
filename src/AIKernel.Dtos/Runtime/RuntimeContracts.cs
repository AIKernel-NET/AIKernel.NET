using AIKernel.Enums;
using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Runtime;

namespace AIKernel.Dtos.Runtime;

/// <summary>
/// EN: Carries a sandbox runtime preparation result.
/// EN: Documentation for public API. JA: SandboxRuntimePreparationResult の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimePreparationResult
{
    /// <summary>EN: Gets whether preparation succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the resulting lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>EN: Gets a stable failure code. JA: FailureCode を取得します。</summary>
    public string? FailureCode { get; init; }

    /// <summary>EN: Gets a human-readable failure message. JA: FailureMessage を取得します。</summary>
    public string? FailureMessage { get; init; }

    /// <summary>EN: Gets optional preparation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a sandbox runtime start request.
/// EN: Documentation for public API. JA: SandboxRuntimeStartRequest の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStartRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets the requested control mode. JA: ControlMode を取得します。</summary>
    public RuntimeControlMode ControlMode { get; init; } = RuntimeControlMode.ObserveOnly;

    /// <summary>EN: Gets optional start metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a sandbox runtime start result.
/// EN: Documentation for public API. JA: SandboxRuntimeStartResult の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStartResult
{
    /// <summary>EN: Gets whether start succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the runtime process identifier. JA: ProcessId を取得します。</summary>
    public string? ProcessId { get; init; }

    /// <summary>EN: Gets the resulting lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>EN: Gets optional start metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a sandbox runtime stop request.
/// EN: Documentation for public API. JA: SandboxRuntimeStopRequest の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStopRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets whether the runtime should be stopped gracefully. JA: Graceful を取得します。</summary>
    public bool Graceful { get; init; } = true;

    /// <summary>EN: Gets optional stop metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a sandbox runtime stop result.
/// EN: Documentation for public API. JA: SandboxRuntimeStopResult の公開契約を定義します。
/// </summary>
public sealed record SandboxRuntimeStopResult
{
    /// <summary>EN: Gets whether stop succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resulting lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>EN: Gets optional stop metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a runtime status snapshot.
/// EN: Documentation for public API. JA: RuntimeStatusSnapshot の公開契約を定義します。
/// </summary>
public sealed record RuntimeStatusSnapshot
{
    /// <summary>EN: Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether status capture succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets the lifecycle status. JA: Status を取得します。</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>EN: Gets the runtime state. JA: State を取得します。</summary>
    public RuntimeState State { get; init; } = RuntimeState.Unknown;

    /// <summary>EN: Gets a health score from 0 to 1. JA: HealthScore を取得します。</summary>
    public double HealthScore { get; init; }

    /// <summary>EN: Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostics emitted while building the snapshot. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets optional status metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a runtime status request.
/// EN: Documentation for public API. JA: RuntimeStatusRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeStatusRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets optional status request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Identifies a sandbox runtime instance.
/// EN: Documentation for public API. JA: SandboxInstanceHandle の公開契約を定義します。
/// </summary>
public sealed record SandboxInstanceHandle
{
    /// <summary>EN: Gets the sandbox instance identifier. JA: InstanceId を取得します。</summary>
    public required string InstanceId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets optional instance metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a sandbox process creation request.
/// EN: Documentation for public API. JA: SandboxProcessCreateRequest の公開契約を定義します。
/// </summary>
public sealed record SandboxProcessCreateRequest
{
    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets the process name. JA: ProcessName を取得します。</summary>
    public required string ProcessName { get; init; }

    /// <summary>EN: Gets optional process metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a sandbox process snapshot.
/// EN: Documentation for public API. JA: SandboxProcessSnapshot の公開契約を定義します。
/// </summary>
public sealed record SandboxProcessSnapshot
{
    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public required string ProcessId { get; init; }

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public required string RuntimeId { get; init; }

    /// <summary>EN: Gets the process state. JA: State を取得します。</summary>
    public RuntimeProcessState State { get; init; } = RuntimeProcessState.Unknown;

    /// <summary>EN: Gets optional process metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Describes a sandbox process.
/// EN: Documentation for public API. JA: SandboxProcessDescriptor の公開契約を定義します。
/// </summary>
public sealed record SandboxProcessDescriptor
{
    /// <summary>EN: Gets the process identifier. JA: ProcessId を取得します。</summary>
    public required string ProcessId { get; init; }

    /// <summary>EN: Gets the process name. JA: Name を取得します。</summary>
    public string? Name { get; init; }

    /// <summary>EN: Gets the process state. JA: State を取得します。</summary>
    public RuntimeProcessState State { get; init; } = RuntimeProcessState.Unknown;

    /// <summary>EN: Gets optional process metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a runtime asset request.
/// EN: Documentation for public API. JA: RuntimeAssetRequest の公開契約を定義します。
/// </summary>
public sealed record RuntimeAssetRequest
{
    /// <summary>EN: Gets the asset identifier. JA: AssetId を取得します。</summary>
    public required string AssetId { get; init; }

    /// <summary>EN: Gets the asset kind. JA: Kind を取得します。</summary>
    public RuntimeAssetKind Kind { get; init; } = RuntimeAssetKind.Unknown;

    /// <summary>EN: Gets the optional artifact URI. JA: ArtifactUri を取得します。</summary>
    public string? ArtifactUri { get; init; }

    /// <summary>EN: Gets the expected content hash. JA: ExpectedHash を取得します。</summary>
    public string? ExpectedHash { get; init; }

    /// <summary>EN: Gets optional asset metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a runtime asset resolution result.
/// EN: Documentation for public API. JA: RuntimeAssetResolutionResult の公開契約を定義します。
/// </summary>
public sealed record RuntimeAssetResolutionResult
{
    /// <summary>EN: Gets whether asset resolution succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resolved artifact reference. JA: ResolvedReference を取得します。</summary>
    public string? ResolvedReference { get; init; }

    /// <summary>EN: Gets the resolved content hash. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>EN: Gets optional resolution metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a memory asset mount request.
/// EN: Documentation for public API. JA: MemoryAssetMountRequest の公開契約を定義します。
/// </summary>
public sealed record MemoryAssetMountRequest
{
    /// <summary>EN: Gets the asset identifier. JA: AssetId を取得します。</summary>
    public required string AssetId { get; init; }

    /// <summary>EN: Gets the content hash being mounted. JA: ContentHash を取得します。</summary>
    public string? ContentHash { get; init; }

    /// <summary>EN: Gets the byte length to mount. JA: Length を取得します。</summary>
    public long Length { get; init; }

    /// <summary>EN: Gets optional mount metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// EN: Carries a memory asset mount result.
/// EN: Documentation for public API. JA: MemoryAssetMountResult の公開契約を定義します。
/// </summary>
public sealed record MemoryAssetMountResult
{
    /// <summary>EN: Gets whether mount succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the mount identifier. JA: MountId を取得します。</summary>
    public string? MountId { get; init; }

    /// <summary>EN: Gets optional mount metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
