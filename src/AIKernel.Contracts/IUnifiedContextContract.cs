using AIKernel.Dtos;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を定義します。
/// OrchestrationContract、ExpressionContract、MaterialContract を統合管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IUnifiedContextContract
{
    /// <summary>
    /// 統合コンテキストの一意識別子を取得します。
    /// </summary>
    string GetId();

    /// <summary>
    /// OrchestrationContract を取得します。
    /// </summary>
    IOrchestrationContract GetOrchestration();

    /// <summary>
    /// ExpressionContract を取得します。
    /// </summary>
    IExpressionContract? GetExpression();

    /// <summary>
    /// MaterialContract を取得します。
    /// </summary>
    IMaterialContract? GetMaterial();

    /// <summary>
    /// 統合コンテキストのデータを取得します。
    /// </summary>
    UnifiedContextDto GetContext();

    /// <summary>
    /// 全体の検証を実行します。
    /// カテゴリ分離、コンテキスト隔離、Attention 汚染検出を行います。
    /// </summary>
    ValidationResult ValidateAll();

    /// <summary>
    /// 3 層分離が正しく保たれていることを確認します。
    /// </summary>
    bool ValidateLayerSeparation();

    /// <summary>
    /// Attention 汚染の可能性を評価します。
    /// </summary>
    IReadOnlyList<FailureMode> DetectPollution();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    double CalculateSignalToNoiseRatio();
}
