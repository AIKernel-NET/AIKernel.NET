using AIKernel.Enums;

namespace AIKernel.Dtos.Runtime;

/// <summary>
/// Carries a sandbox runtime preparation result.
/// </summary>
public sealed record SandboxRuntimePreparationResult
{
    /// <summary>Gets whether preparation succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting lifecycle status.</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets a stable failure code.</summary>
    public string? FailureCode { get; init; }

    /// <summary>Gets a human-readable failure message.</summary>
    public string? FailureMessage { get; init; }

    /// <summary>Gets optional preparation metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime start request.
/// </summary>
public sealed record SandboxRuntimeStartRequest
{
    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the requested control mode.</summary>
    public RuntimeControlMode ControlMode { get; init; } = RuntimeControlMode.ObserveOnly;

    /// <summary>Gets optional start metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime start result.
/// </summary>
public sealed record SandboxRuntimeStartResult
{
    /// <summary>Gets whether start succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the runtime process identifier.</summary>
    public string? ProcessId { get; init; }

    /// <summary>Gets the resulting lifecycle status.</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets optional start metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime stop request.
/// </summary>
public sealed record SandboxRuntimeStopRequest
{
    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets whether the runtime should be stopped gracefully.</summary>
    public bool Graceful { get; init; } = true;

    /// <summary>Gets optional stop metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox runtime stop result.
/// </summary>
public sealed record SandboxRuntimeStopResult
{
    /// <summary>Gets whether stop succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting lifecycle status.</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets optional stop metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime status snapshot.
/// </summary>
public sealed record RuntimeStatusSnapshot
{
    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the lifecycle status.</summary>
    public RuntimeLifecycleStatus Status { get; init; } = RuntimeLifecycleStatus.Unknown;

    /// <summary>Gets a health score from 0 to 1.</summary>
    public double HealthScore { get; init; }

    /// <summary>Gets optional status metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime status request.
/// </summary>
public sealed record RuntimeStatusRequest
{
    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets optional status request metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Identifies a sandbox runtime instance.
/// </summary>
public sealed record SandboxInstanceHandle
{
    /// <summary>Gets the sandbox instance identifier.</summary>
    public required string InstanceId { get; init; }

    /// <summary>Gets the runtime identifier.</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets optional instance metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox process creation request.
/// </summary>
public sealed record SandboxProcessCreateRequest
{
    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the process name.</summary>
    public required string ProcessName { get; init; }

    /// <summary>Gets optional process metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a sandbox process snapshot.
/// </summary>
public sealed record SandboxProcessSnapshot
{
    /// <summary>Gets the process identifier.</summary>
    public required string ProcessId { get; init; }

    /// <summary>Gets the runtime identifier.</summary>
    public required string RuntimeId { get; init; }

    /// <summary>Gets the process state.</summary>
    public RuntimeProcessState State { get; init; } = RuntimeProcessState.Unknown;

    /// <summary>Gets optional process metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Describes a sandbox process.
/// </summary>
public sealed record SandboxProcessDescriptor
{
    /// <summary>Gets the process identifier.</summary>
    public required string ProcessId { get; init; }

    /// <summary>Gets the process name.</summary>
    public string? Name { get; init; }

    /// <summary>Gets the process state.</summary>
    public RuntimeProcessState State { get; init; } = RuntimeProcessState.Unknown;

    /// <summary>Gets optional process metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime asset request.
/// </summary>
public sealed record RuntimeAssetRequest
{
    /// <summary>Gets the asset identifier.</summary>
    public required string AssetId { get; init; }

    /// <summary>Gets the asset kind.</summary>
    public RuntimeAssetKind Kind { get; init; } = RuntimeAssetKind.Unknown;

    /// <summary>Gets the optional artifact URI.</summary>
    public string? ArtifactUri { get; init; }

    /// <summary>Gets the expected content hash.</summary>
    public string? ExpectedHash { get; init; }

    /// <summary>Gets optional asset metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a runtime asset resolution result.
/// </summary>
public sealed record RuntimeAssetResolutionResult
{
    /// <summary>Gets whether asset resolution succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resolved artifact reference.</summary>
    public string? ResolvedReference { get; init; }

    /// <summary>Gets the resolved content hash.</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets optional resolution metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a memory asset mount request.
/// </summary>
public sealed record MemoryAssetMountRequest
{
    /// <summary>Gets the asset identifier.</summary>
    public required string AssetId { get; init; }

    /// <summary>Gets the content hash being mounted.</summary>
    public string? ContentHash { get; init; }

    /// <summary>Gets the byte length to mount.</summary>
    public long Length { get; init; }

    /// <summary>Gets optional mount metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}

/// <summary>
/// Carries a memory asset mount result.
/// </summary>
public sealed record MemoryAssetMountResult
{
    /// <summary>Gets whether mount succeeded.</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the mount identifier.</summary>
    public string? MountId { get; init; }

    /// <summary>Gets optional mount metadata.</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>();
}
