using AIKernel.Dtos;
using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を定義します。
/// OrchestrationContract、ExpressionContract、MaterialContract を統合管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// UC-06（3層バッファによる Attention 制御）, UC-08（コンテキストスナップショットと永続化）
/// </summary>
public interface IUnifiedContextContract
{
    /// <summary>
    /// 統合コンテキストの一意識別子を取得します。
    /// </summary>
    /// <returns>統合コンテキスト ID</returns>
    string GetId();

    /// <summary>
    /// OrchestrationContract を取得します。
    /// </summary>
    /// <returns>Orchestration 契約</returns>
    IOrchestrationContract GetOrchestration();

    /// <summary>
    /// ExpressionContract を取得します。
    /// </summary>
    /// <returns>Expression 契約。存在しない場合は null。</returns>
    IExpressionContract? GetExpression();

    /// <summary>
    /// MaterialContract を取得します。
    /// </summary>
    /// <returns>Material 契約。存在しない場合は null。</returns>
    IMaterialContract? GetMaterial();

    /// <summary>
    /// 統合コンテキストのデータを取得します。
    /// </summary>
    /// <returns>統合コンテキスト DTO</returns>
    UnifiedContextDto GetContext();

    /// <summary>
    /// 全体の検証を実行します。
    /// カテゴリ分離、コンテキスト隔離、Attention 汚染検出を行います。
    /// </summary>
    /// <returns>検証結果</returns>
    ValidationResult ValidateAll();

    /// <summary>
    /// 3 層分離が正しく保たれていることを確認します。
    /// </summary>
    /// <returns>分離が保たれている場合は true。</returns>
    bool ValidateLayerSeparation();

    /// <summary>
    /// Attention 汚染の可能性を評価します。
    /// </summary>
    /// <returns>検出された FailureMode 一覧</returns>
    IReadOnlyList<FailureMode> DetectPollution();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    /// <returns>算出された SNR 値</returns>
    double CalculateSignalToNoiseRatio();
}

