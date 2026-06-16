using AIKernel.Dtos.Frame;
using AIKernel.Dtos.Perception;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Perception;

/// <summary>
/// EN: Converts frames into bounded symbolic perception signals.
/// [EN] Documents this public package API member. [JA] IFramePerceptionProvider の公開契約を定義します。
/// </summary>
public interface IFramePerceptionProvider : IKernelProvider
{
    /// <summary>
    /// EN: Analyzes a frame snapshot.
    /// [EN] Documents this public package API member. [JA] AnalyzeAsync 操作を実行します。
    /// </summary>
    /// <param name="frame">EN: The frame snapshot. JA: frame パラメーターです。</param>
    /// <param name="options">EN: The perception options. JA: options パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The perception result. JA: 結果を返します。</returns>
    ValueTask<FramePerceptionResult> AnalyzeAsync(
        FrameSnapshot frame,
        FramePerceptionOptions options,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Produces read-only observation snapshots without selecting actions.
/// [EN] Documents this public package API member. [JA] IObservationProvider の公開契約を定義します。
/// </summary>
public interface IObservationProvider : IKernelProvider
{
    /// <summary>
    /// EN: Captures an observation snapshot.
    /// [EN] Documents this public package API member. [JA] ObserveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The observation request. JA: request パラメーターです。</param>
    /// <param name="context">EN: The execution context. JA: context パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The observation snapshot. JA: 結果を返します。</returns>
    ValueTask<ObservationSnapshot> ObserveAsync(
        ObservationRequest request,
        ProviderExecutionContext context,
        CancellationToken cancellationToken);
}
