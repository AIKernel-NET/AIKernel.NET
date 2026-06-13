using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// Converts frames into bounded symbolic perception signals.
/// </summary>
public interface IFramePerceptionProvider : IProviderExtended
{
    /// <summary>
    /// Analyzes a frame snapshot.
    /// </summary>
    /// <param name="frame">The frame snapshot.</param>
    /// <param name="options">The perception options.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The perception result.</returns>
    ValueTask<FramePerceptionResult> AnalyzeAsync(
        FrameSnapshot frame,
        FramePerceptionOptions options,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Produces read-only observation snapshots without selecting actions.
/// </summary>
public interface IObservationProvider : IProviderExtended
{
    /// <summary>
    /// Captures an observation snapshot.
    /// </summary>
    /// <param name="request">The observation request.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The observation snapshot.</returns>
    ValueTask<ObservationSnapshot> ObserveAsync(
        ObservationRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
