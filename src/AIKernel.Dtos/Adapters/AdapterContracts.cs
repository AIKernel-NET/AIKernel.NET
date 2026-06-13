using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Adapters;

namespace AIKernel.Dtos.Adapters;

/// <summary>
/// Carries a provider adapter description request.
/// JA: ProviderAdapterDescribeRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterDescribeRequest
{
    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Describes a provider adapter.
/// JA: ProviderAdapterDescriptor の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterDescriptor
{
    /// <summary>Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>Gets whether description succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets the adapter kind. JA: Kind を取得します。</summary>
    public AdapterKind Kind { get; init; } = AdapterKind.Unknown;

    /// <summary>Gets the adapter version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets diagnostics emitted while describing the adapter. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter validation request.
/// JA: ProviderAdapterValidationRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterValidationRequest
{
    /// <summary>Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>Gets validation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter validation result.
/// JA: ProviderAdapterValidationResult の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterValidationResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether validation succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the highest validation severity. JA: Severity を取得します。</summary>
    public AdapterValidationSeverity Severity { get; init; } = AdapterValidationSeverity.Unknown;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets validation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when validation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter bind request.
/// JA: ProviderAdapterBindRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterBindRequest
{
    /// <summary>Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string ProviderId { get; init; } = string.Empty;

    /// <summary>Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>Gets bind metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter bind result.
/// JA: ProviderAdapterBindResult の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterBindResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether bind succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting binding state. JA: State を取得します。</summary>
    public AdapterBindingState State { get; init; } = AdapterBindingState.Unknown;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets bind diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when bind was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter unbind request.
/// JA: ProviderAdapterUnbindRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterUnbindRequest
{
    /// <summary>Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>Gets unbind metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter unbind result.
/// JA: ProviderAdapterUnbindResult の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterUnbindResult
{
    /// <summary>Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>Gets whether unbind succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>Gets the resulting binding state. JA: State を取得します。</summary>
    public AdapterBindingState State { get; init; } = AdapterBindingState.Unknown;

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets unbind diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>Gets when unbind was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter state request.
/// JA: ProviderAdapterStateRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterStateRequest
{
    /// <summary>Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// Carries a provider adapter state snapshot.
/// JA: ProviderAdapterStateSnapshot の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterStateSnapshot
{
    /// <summary>Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>Gets whether state capture succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>Gets the binding state. JA: State を取得します。</summary>
    public AdapterBindingState State { get; init; } = AdapterBindingState.Unknown;

    /// <summary>Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>Gets state diagnostics. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
