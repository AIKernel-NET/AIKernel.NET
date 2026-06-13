using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// Extends frame perception with diagnostics-bearing analysis results.
/// </summary>
public interface IFramePerceptionProviderExtended : IFramePerceptionProvider
{
    /// <summary>
    /// Analyzes a frame snapshot with diagnostics-bearing output.
    /// </summary>
    /// <param name="frame">The frame snapshot.</param>
    /// <param name="options">The perception options.</param>
    /// <param name="context">The execution context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The perception result.</returns>
    ValueTask<FramePerceptionResult> AnalyzeWithDiagnosticsAsync(
        FrameSnapshot frame,
        FramePerceptionOptions options,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
