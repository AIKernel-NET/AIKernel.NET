namespace AIKernel.Abstractions.Governance;

using AIKernel.Abstractions.Models;
using AIKernel.Abstractions.Context;

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

/// <summary>
/// Attention 観察の統計情報を表現します。
/// </summary>
public class AttentionObservationStats
{
    /// <summary>
    /// 観察開始時刻を取得します。
    /// </summary>
    public DateTime ObservationStartedAt { get; init; }

    /// <summary>
    /// 消費された総 Attention を取得します。
    /// </summary>
    public long TotalAttentionConsumed { get; init; }

    /// <summary>
    /// 検知された Attention 汚染の回数を取得します。
    /// </summary>
    public int PollutionDetectionCount { get; init; }

    /// <summary>
    /// 平均信号対雑音比を取得します。
    /// </summary>
    public float AverageSignalToNoiseRatio { get; init; }

    /// <summary>
    /// モデル選定の成功率を取得します。
    /// </summary>
    public float ModelSelectionSuccessRate { get; init; }

    /// <summary>
    /// フェーズごとの詳細統計を取得します。
    /// </summary>
    public Dictionary<string, PhaseObservationStats> PhaseStatistics { get; init; } = new();
}

/// <summary>
/// フェーズごとの観察統計を表現します。
/// </summary>
public class PhaseObservationStats
{
    /// <summary>
    /// フェーズ名を取得します。
    /// </summary>
    public required string PhaseName { get; init; }

    /// <summary>
    /// 実行回数を取得します。
    /// </summary>
    public int ExecutionCount { get; init; }

    /// <summary>
    /// 平均実行時間（ミリ秒）を取得します。
    /// </summary>
    public double AverageExecutionTimeMs { get; init; }

    /// <summary>
    /// 消費された総 Attention を取得します。
    /// </summary>
    public long TotalAttentionConsumed { get; init; }
}
