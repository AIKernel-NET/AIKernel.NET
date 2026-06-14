using AIKernel.Dtos.Operators;

namespace AIKernel.Abstractions.Operators;

/// <summary>
/// Evaluates bounded operator strategy proposals without executing actions.
/// JA: IOperatorStrategyProvider の公開契約を定義します。
/// </summary>
public interface IOperatorStrategyProvider
{
    /// <summary>
    /// Describes the operator strategy.
    /// JA: DescribeStrategyAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The strategy description request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The strategy descriptor. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyDescriptor> DescribeStrategyAsync(
        OperatorStrategyDescribeRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Evaluates the operator strategy.
    /// JA: EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The strategy request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The strategy result. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyResult> EvaluateAsync(
        OperatorStrategyRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Resets strategy state.
    /// JA: ResetAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The reset request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The reset result. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyResetResult> ResetAsync(
        OperatorStrategyResetRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets strategy state.
    /// JA: GetStateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The state request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The state snapshot. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyStateSnapshot> GetStateAsync(
        OperatorStrategyStateRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Updates the strategy profile.
    /// JA: UpdateProfileAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The profile update request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The profile update result. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyProfileUpdateResult> UpdateProfileAsync(
        OperatorStrategyProfileUpdateRequest request,
        CancellationToken cancellationToken);
}
