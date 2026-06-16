namespace AIKernel.Abstractions.Governance;

using AIKernel.Abstractions.Models;
using AIKernel.Dtos.Context;

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// Attention 消費とコンテキスト品質を受動的に監視するインターフェースです。
/// EN: 統計やログを収集し、運用フェーズにおける分析に利用されます。
/// [EN] Documents this public package API member. [JA] IAttentionObserver の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IAttentionObserver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IAttentionObserver']" />
public interface IAttentionObserver
{
    /// <summary>
    /// EN: フェーズ開始時のイベントを記録します。
    /// [EN] Documents this public package API member. [JA] OnPhaseStartedAsync 操作を実行します。
    /// </summary>
    /// <param name="phaseName">[EN] Documents this public package API member. [JA] フェーズ名 phaseName パラメーターです。</param>
    /// <param name="modelType">[EN] Documents this public package API member. [JA] 選定されたモデルタイプ modelType パラメーターです。</param>
    /// <param name="requiredCapacity">[EN] Documents this public package API member. [JA] 要求された能力ベクトル requiredCapacity パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task OnPhaseStartedAsync(
        string phaseName,
        ModelType modelType,
        ModelCapacityVector requiredCapacity,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: フェーズ終了時のイベントを記録します。
    /// [EN] Documents this public package API member. [JA] OnPhaseCompletedAsync 操作を実行します。
    /// </summary>
    /// <param name="phaseName">[EN] Documents this public package API member. [JA] フェーズ名 phaseName パラメーターです。</param>
    /// <param name="modelType">[EN] Documents this public package API member. [JA] 使用されたモデルタイプ modelType パラメーターです。</param>
    /// <param name="attentionConsumed">[EN] Documents this public package API member. [JA] 消費された Attention トークン数 attentionConsumed パラメーターです。</param>
    /// <param name="signalToNoiseRatio">[EN] Documents this public package API member. [JA] 信号対雑音比 signalToNoiseRatio パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task OnPhaseCompletedAsync(
        string phaseName,
        ModelType modelType,
        int attentionConsumed,
        float signalToNoiseRatio,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: モデル選定時のイベントを記録します。
    /// [EN] Documents this public package API member. [JA] OnModelSelectedAsync 操作を実行します。
    /// </summary>
    /// <param name="modelType">[EN] Documents this public package API member. [JA] 選定されたモデルタイプ modelType パラメーターです。</param>
    /// <param name="requiredCapacity">[EN] Documents this public package API member. [JA] 要求された能力ベクトル requiredCapacity パラメーターです。</param>
    /// <param name="providedCapacity">[EN] Documents this public package API member. [JA] 提供される能力ベクトル providedCapacity パラメーターです。</param>
    /// <param name="selectionScore">[EN] Documents this public package API member. [JA] 選定スコア（0.0 ~ 1.0） selectionScore パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task OnModelSelectedAsync(
        ModelType modelType,
        ModelCapacityVector requiredCapacity,
        ModelCapacityVector providedCapacity,
        float selectionScore,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: Attention 汚染の検知時のイベントを記録します。
    /// [EN] Documents this public package API member. [JA] OnAttentionPollutionDetectedAsync 操作を実行します。
    /// </summary>
    /// <param name="phaseName">[EN] Documents this public package API member. [JA] 汚染が検知されたフェーズ名 phaseName パラメーターです。</param>
    /// <param name="pollutionLevel">[EN] Documents this public package API member. [JA] 汚染度（0.0 ~ 1.0） pollutionLevel パラメーターです。</param>
    /// <param name="affectedCategories">[EN] Documents this public package API member. [JA] 影響を受けたコンテキストカテゴリ affectedCategories パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task OnAttentionPollutionDetectedAsync(
        string phaseName,
        float pollutionLevel,
        IEnumerable<ContextCategory> affectedCategories,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: コンテキスト品質の変化を記録します。
    /// [EN] Documents this public package API member. [JA] OnContextQualityChangedAsync 操作を実行します。
    /// </summary>
    /// <param name="category">[EN] Documents this public package API member. [JA] コンテキストカテゴリ category パラメーターです。</param>
    /// <param name="quality">[EN] Documents this public package API member. [JA] 品質スコア（0.0 ~ 1.0） quality パラメーターです。</param>
    /// <param name="fragmentCount">[EN] Documents this public package API member. [JA] フラグメント数 fragmentCount パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    Task OnContextQualityChangedAsync(
        ContextCategory category,
        float quality,
        int fragmentCount,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: 統計情報を取得します。
    /// [EN] Documents this public package API member. [JA] GetObservationStatsAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 観察された統計情報 結果を返します。</returns>
    Task<AttentionObservationStats> GetObservationStatsAsync(CancellationToken cancellationToken = default);
}

