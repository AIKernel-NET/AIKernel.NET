using AIKernel.Dtos.Operators;

namespace AIKernel.Abstractions.Operators;

/// <summary>
/// EN: Evaluates bounded operator strategy proposals without executing actions.
/// [EN] Documents this public package API member. [JA] IOperatorStrategyProvider の公開契約を定義します。
/// </summary>
public interface IOperatorStrategyProvider
{
    /// <summary>
    /// EN: Describes the operator strategy.
    /// [EN] Documents this public package API member. [JA] DescribeStrategyAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The strategy description request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The strategy descriptor. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyDescriptor> DescribeStrategyAsync(
        OperatorStrategyDescribeRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Evaluates the operator strategy.
    /// [EN] Documents this public package API member. [JA] EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The strategy request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The strategy result. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyResult> EvaluateAsync(
        OperatorStrategyRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Resets strategy state.
    /// [EN] Documents this public package API member. [JA] ResetAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The reset request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The reset result. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyResetResult> ResetAsync(
        OperatorStrategyResetRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets strategy state.
    /// [EN] Documents this public package API member. [JA] GetStateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The state request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The state snapshot. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyStateSnapshot> GetStateAsync(
        OperatorStrategyStateRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Updates the strategy profile.
    /// [EN] Documents this public package API member. [JA] UpdateProfileAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The profile update request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The profile update result. JA: 結果を返します。</returns>
    ValueTask<OperatorStrategyProfileUpdateResult> UpdateProfileAsync(
        OperatorStrategyProfileUpdateRequest request,
        CancellationToken cancellationToken);
}
