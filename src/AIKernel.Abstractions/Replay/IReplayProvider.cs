using AIKernel.Dtos.Replay;

namespace AIKernel.Abstractions.Replay;

/// <summary>
/// EN: Provides deterministic replay timeline operations.
/// [EN] Documents this public package API member. [JA] IReplayProvider の公開契約を定義します。
/// </summary>
public interface IReplayProvider
{
    /// <summary>
    /// EN: Creates a replay timeline.
    /// [EN] Documents this public package API member. [JA] CreateTimelineAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The timeline create request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The timeline create result. JA: 結果を返します。</returns>
    ValueTask<ReplayTimelineCreateResult> CreateTimelineAsync(
        ReplayTimelineCreateRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Appends a replay frame.
    /// [EN] Documents this public package API member. [JA] AppendFrameAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The frame append request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The append result. JA: 結果を返します。</returns>
    ValueTask<ReplayAppendResult> AppendFrameAsync(
        ReplayFrameAppendRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Appends a replay event.
    /// [EN] Documents this public package API member. [JA] AppendEventAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The event append request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The append result. JA: 結果を返します。</returns>
    ValueTask<ReplayAppendResult> AppendEventAsync(
        ReplayEventAppendRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets a replay timeline.
    /// [EN] Documents this public package API member. [JA] GetTimelineAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The timeline query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The replay timeline. JA: 結果を返します。</returns>
    ValueTask<ReplayTimeline> GetTimelineAsync(
        ReplayTimelineQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Seals a replay timeline.
    /// [EN] Documents this public package API member. [JA] SealTimelineAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The seal request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The seal result. JA: 結果を返します。</returns>
    ValueTask<ReplaySealResult> SealTimelineAsync(
        ReplaySealRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Queries replay events.
    /// [EN] Documents this public package API member. [JA] QueryEventsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The event query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The replay events. JA: 結果を返します。</returns>
    IAsyncEnumerable<ReplayEvent> QueryEventsAsync(
        ReplayEventQuery request,
        CancellationToken cancellationToken);
}
