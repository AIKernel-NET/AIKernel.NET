using AIKernel.Dtos.Profiles;

namespace AIKernel.Abstractions.Profiles;

/// <summary>
/// Plans, optimizes, compares, and applies profile optimization candidates.
/// JA: IProfileOptimizationProvider の公開契約を定義します。
/// </summary>
public interface IProfileOptimizationProvider
{
    /// <summary>
    /// Plans profile optimization.
    /// JA: PlanAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The plan request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The plan result. JA: 結果を返します。</returns>
    ValueTask<ProfileOptimizationPlanResult> PlanAsync(
        ProfileOptimizationPlanRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Optimizes a profile.
    /// JA: OptimizeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The optimization request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The optimization result. JA: 結果を返します。</returns>
    ValueTask<ProfileOptimizationResult> OptimizeAsync(
        ProfileOptimizationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Compares profiles.
    /// JA: CompareAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The comparison request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The comparison result. JA: 結果を返します。</returns>
    ValueTask<ProfileComparisonResult> CompareAsync(
        ProfileComparisonRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Applies an optimization candidate.
    /// JA: ApplyAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The apply request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The apply result. JA: 結果を返します。</returns>
    ValueTask<ProfileOptimizationApplyResult> ApplyAsync(
        ProfileOptimizationApplyRequest request,
        CancellationToken cancellationToken);
}
