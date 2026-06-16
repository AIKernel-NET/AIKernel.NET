using AIKernel.Dtos.Profiles;

namespace AIKernel.Abstractions.Profiles;

/// <summary>
/// EN: Plans, optimizes, compares, and applies profile optimization candidates.
/// EN: Documentation for public API. JA: IProfileOptimizationProvider の公開契約を定義します。
/// </summary>
public interface IProfileOptimizationProvider
{
    /// <summary>
    /// EN: Plans profile optimization.
    /// EN: Documentation for public API. JA: PlanAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The plan request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The plan result. JA: 結果を返します。</returns>
    ValueTask<ProfileOptimizationPlanResult> PlanAsync(
        ProfileOptimizationPlanRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Optimizes a profile.
    /// EN: Documentation for public API. JA: OptimizeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The optimization request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The optimization result. JA: 結果を返します。</returns>
    ValueTask<ProfileOptimizationResult> OptimizeAsync(
        ProfileOptimizationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Compares profiles.
    /// EN: Documentation for public API. JA: CompareAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The comparison request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The comparison result. JA: 結果を返します。</returns>
    ValueTask<ProfileComparisonResult> CompareAsync(
        ProfileComparisonRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Applies an optimization candidate.
    /// EN: Documentation for public API. JA: ApplyAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The apply request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The apply result. JA: 結果を返します。</returns>
    ValueTask<ProfileOptimizationApplyResult> ApplyAsync(
        ProfileOptimizationApplyRequest request,
        CancellationToken cancellationToken);
}
