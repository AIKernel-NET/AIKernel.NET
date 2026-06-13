using AIKernel.Dtos.Replay;

namespace AIKernel.Abstractions.Replay;

/// <summary>
/// Provides deterministic replay timeline operations.
/// JA: IReplayProvider の公開契約を定義します。
/// </summary>
public interface IReplayProvider
{
    /// <summary>
    /// Creates a replay timeline.
    /// JA: CreateTimelineAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The timeline create request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The timeline create result. JA: 結果を返します。</returns>
    ValueTask<ReplayTimelineCreateResult> CreateTimelineAsync(
        ReplayTimelineCreateRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Appends a replay frame.
    /// JA: AppendFrameAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The frame append request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The append result. JA: 結果を返します。</returns>
    ValueTask<ReplayAppendResult> AppendFrameAsync(
        ReplayFrameAppendRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Appends a replay event.
    /// JA: AppendEventAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The event append request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The append result. JA: 結果を返します。</returns>
    ValueTask<ReplayAppendResult> AppendEventAsync(
        ReplayEventAppendRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a replay timeline.
    /// JA: GetTimelineAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The timeline query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The replay timeline. JA: 結果を返します。</returns>
    ValueTask<ReplayTimeline> GetTimelineAsync(
        ReplayTimelineQuery request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Seals a replay timeline.
    /// JA: SealTimelineAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The seal request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The seal result. JA: 結果を返します。</returns>
    ValueTask<ReplaySealResult> SealTimelineAsync(
        ReplaySealRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Queries replay events.
    /// JA: QueryEventsAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The event query. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The replay events. JA: 結果を返します。</returns>
    IAsyncEnumerable<ReplayEvent> QueryEventsAsync(
        ReplayEventQuery request,
        CancellationToken cancellationToken);
}
