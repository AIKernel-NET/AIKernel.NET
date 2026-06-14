using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// Converts frames into bounded symbolic perception signals.
/// JA: IFramePerceptionProvider の公開契約を定義します。
/// </summary>
public interface IFramePerceptionProvider : IKernelProvider
{
    /// <summary>
    /// Analyzes a frame snapshot.
    /// JA: AnalyzeAsync 操作を実行します。
    /// </summary>
    /// <param name="frame">The frame snapshot. JA: frame パラメーターです。</param>
    /// <param name="options">The perception options. JA: options パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The perception result. JA: 結果を返します。</returns>
    ValueTask<FramePerceptionResult> AnalyzeAsync(
        FrameSnapshot frame,
        FramePerceptionOptions options,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// Produces read-only observation snapshots without selecting actions.
/// JA: IObservationProvider の公開契約を定義します。
/// </summary>
public interface IObservationProvider : IKernelProvider
{
    /// <summary>
    /// Captures an observation snapshot.
    /// JA: ObserveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The observation request. JA: request パラメーターです。</param>
    /// <param name="context">The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The observation snapshot. JA: 結果を返します。</returns>
    ValueTask<ObservationSnapshot> ObserveAsync(
        ObservationRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
