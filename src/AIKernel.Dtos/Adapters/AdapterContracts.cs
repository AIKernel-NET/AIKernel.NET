using AIKernel.Dtos.Diagnostics;
using AIKernel.Enums.Adapters;

namespace AIKernel.Dtos.Adapters;

/// <summary>
/// EN: Carries a provider adapter description request.
/// EN: Documentation for public API. JA: ProviderAdapterDescribeRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterDescribeRequest
{
    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Describes a provider adapter.
/// EN: Documentation for public API. JA: ProviderAdapterDescriptor の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterDescriptor
{
    /// <summary>EN: Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether description succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets the adapter kind. JA: Kind を取得します。</summary>
    public AdapterKind Kind { get; init; } = AdapterKind.Unknown;

    /// <summary>EN: Gets the adapter version. JA: Version を取得します。</summary>
    public string? Version { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets diagnostics emitted while describing the adapter. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets descriptor metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter validation request.
/// EN: Documentation for public API. JA: ProviderAdapterValidationRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterValidationRequest
{
    /// <summary>EN: Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>EN: Gets validation metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter validation result.
/// EN: Documentation for public API. JA: ProviderAdapterValidationResult の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterValidationResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether validation succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the highest validation severity. JA: Severity を取得します。</summary>
    public AdapterValidationSeverity Severity { get; init; } = AdapterValidationSeverity.Unknown;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets validation diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when validation was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter bind request.
/// EN: Documentation for public API. JA: ProviderAdapterBindRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterBindRequest
{
    /// <summary>EN: Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string ProviderId { get; init; } = string.Empty;

    /// <summary>EN: Gets the runtime identifier. JA: RuntimeId を取得します。</summary>
    public string? RuntimeId { get; init; }

    /// <summary>EN: Gets bind metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter bind result.
/// EN: Documentation for public API. JA: ProviderAdapterBindResult の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterBindResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether bind succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resulting binding state. JA: State を取得します。</summary>
    public AdapterBindingState State { get; init; } = AdapterBindingState.Unknown;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets bind diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when bind was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter unbind request.
/// EN: Documentation for public API. JA: ProviderAdapterUnbindRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterUnbindRequest
{
    /// <summary>EN: Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>EN: Gets the provider identifier. JA: ProviderId を取得します。</summary>
    public string? ProviderId { get; init; }

    /// <summary>EN: Gets unbind metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter unbind result.
/// EN: Documentation for public API. JA: ProviderAdapterUnbindResult の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterUnbindResult
{
    /// <summary>EN: Gets the operation identifier. JA: OperationId を取得します。</summary>
    public string OperationId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether unbind succeeded. JA: Succeeded を取得します。</summary>
    public bool Succeeded { get; init; }

    /// <summary>EN: Gets the resulting binding state. JA: State を取得します。</summary>
    public AdapterBindingState State { get; init; } = AdapterBindingState.Unknown;

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets unbind diagnostics. JA: Diagnostics を取得します。</summary>
    public IReadOnlyList<DiagnosticEntry> Diagnostics { get; init; } = [];

    /// <summary>EN: Gets when unbind was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets the correlation identifier. JA: CorrelationId を取得します。</summary>
    public string? CorrelationId { get; init; }

    /// <summary>EN: Gets the trace identifier. JA: TraceId を取得します。</summary>
    public string? TraceId { get; init; }

    /// <summary>EN: Gets result metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter state request.
/// EN: Documentation for public API. JA: ProviderAdapterStateRequest の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterStateRequest
{
    /// <summary>EN: Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>EN: Gets request metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}

/// <summary>
/// EN: Carries a provider adapter state snapshot.
/// EN: Documentation for public API. JA: ProviderAdapterStateSnapshot の公開契約を定義します。
/// </summary>
public sealed record ProviderAdapterStateSnapshot
{
    /// <summary>EN: Gets the snapshot identifier. JA: SnapshotId を取得します。</summary>
    public string SnapshotId { get; init; } = string.Empty;

    /// <summary>EN: Gets whether state capture succeeded. JA: Succeeded を取得します。</summary>
    public bool? Succeeded { get; init; }

    /// <summary>EN: Gets the adapter identifier. JA: AdapterId を取得します。</summary>
    public string AdapterId { get; init; } = string.Empty;

    /// <summary>EN: Gets the binding state. JA: State を取得します。</summary>
    public AdapterBindingState State { get; init; } = AdapterBindingState.Unknown;

    /// <summary>EN: Gets when the snapshot was observed. JA: ObservedAt を取得します。</summary>
    public DateTimeOffset ObservedAt { get; init; }

    /// <summary>EN: Gets a stable error code. JA: ErrorCode を取得します。</summary>
    public string? ErrorCode { get; init; }

    /// <summary>EN: Gets a human-readable error message. JA: ErrorMessage を取得します。</summary>
    public string? ErrorMessage { get; init; }

    /// <summary>EN: Gets state diagnostics. JA: Diagnostics を取得します。</summary>
    public DiagnosticInfo? Diagnostics { get; init; }

    /// <summary>EN: Gets snapshot metadata. JA: Metadata を取得します。</summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } = new Dictionary<string, string>(StringComparer.Ordinal);
}
