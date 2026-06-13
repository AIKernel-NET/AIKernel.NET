using AIKernel.Dtos.Providers;
using AIKernel.Dtos.Telemetry;

namespace AIKernel.Abstractions.Telemetry;

/// <summary>
/// Captures runtime telemetry snapshots.
/// </summary>
public interface IRuntimeTelemetryProvider : IProviderExtended
{
    /// <summary>
    /// Captures a runtime telemetry snapshot.
    /// </summary>
    /// <param name="runtimeId">The runtime identifier.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The telemetry snapshot.</returns>
    ValueTask<RuntimeTelemetrySnapshot> CaptureTelemetryAsync(
        string runtimeId,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets runtime telemetry.
    /// </summary>
    /// <param name="request">The telemetry request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The telemetry snapshot.</returns>
    ValueTask<RuntimeTelemetrySnapshot> GetTelemetryAsync(
        RuntimeTelemetryRequest request,
        CancellationToken cancellationToken);
}

/// <summary>
/// Captures evidence without mutating runtime state.
/// </summary>
public interface IEvidenceCaptureProvider : IProviderExtended
{
    /// <summary>
    /// Captures an evidence bundle.
    /// </summary>
    /// <param name="request">The evidence capture request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The evidence bundle.</returns>
    ValueTask<EvidenceBundle> CaptureAsync(
        EvidenceCaptureRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Records replay evidence for deterministic audit.
/// </summary>
public interface IReplayEvidenceProvider : IProviderExtended
{
    /// <summary>
    /// Records replay evidence.
    /// </summary>
    /// <param name="request">The replay evidence request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The replay evidence record.</returns>
    ValueTask<ReplayEvidenceRecord> RecordAsync(
        ReplayEvidenceRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
