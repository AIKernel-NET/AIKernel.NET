namespace AIKernel.Abstractions.Governance;

using AIKernel.Abstractions.Models;
using AIKernel.Dtos.Context;

/// <summary>
/// Attention 消費とコンテキスト品質を受動的に監視するインターフェースです。
/// 統計やログを収集し、運用フェーズにおける分析に利用されます。
/// </summary>
public interface IAttentionObserver
{
    /// <summary>
    /// フェーズ開始時のイベントを記録します。
    /// </summary>
    /// <param name="phaseName">フェーズ名</param>
    /// <param name="modelType">選定されたモデルタイプ</param>
    /// <param name="requiredCapacity">要求された能力ベクトル</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task OnPhaseStartedAsync(
        string phaseName,
        ModelType modelType,
        ModelCapacityVector requiredCapacity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// フェーズ終了時のイベントを記録します。
    /// </summary>
    /// <param name="phaseName">フェーズ名</param>
    /// <param name="modelType">使用されたモデルタイプ</param>
    /// <param name="attentionConsumed">消費された Attention トークン数</param>
    /// <param name="signalToNoiseRatio">信号対雑音比</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task OnPhaseCompletedAsync(
        string phaseName,
        ModelType modelType,
        int attentionConsumed,
        float signalToNoiseRatio,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// モデル選定時のイベントを記録します。
    /// </summary>
    /// <param name="modelType">選定されたモデルタイプ</param>
    /// <param name="requiredCapacity">要求された能力ベクトル</param>
    /// <param name="providedCapacity">提供される能力ベクトル</param>
    /// <param name="selectionScore">選定スコア（0.0 ~ 1.0）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task OnModelSelectedAsync(
        ModelType modelType,
        ModelCapacityVector requiredCapacity,
        ModelCapacityVector providedCapacity,
        float selectionScore,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Attention 汚染の検知時のイベントを記録します。
    /// </summary>
    /// <param name="phaseName">汚染が検知されたフェーズ名</param>
    /// <param name="pollutionLevel">汚染度（0.0 ~ 1.0）</param>
    /// <param name="affectedCategories">影響を受けたコンテキストカテゴリ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task OnAttentionPollutionDetectedAsync(
        string phaseName,
        float pollutionLevel,
        IEnumerable<ContextCategory> affectedCategories,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// コンテキスト品質の変化を記録します。
    /// </summary>
    /// <param name="category">コンテキストカテゴリ</param>
    /// <param name="quality">品質スコア（0.0 ~ 1.0）</param>
    /// <param name="fragmentCount">フラグメント数</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    Task OnContextQualityChangedAsync(
        ContextCategory category,
        float quality,
        int fragmentCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 統計情報を取得します。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>観察された統計情報</returns>
    Task<AttentionObservationStats> GetObservationStatsAsync(CancellationToken cancellationToken = default);
}
