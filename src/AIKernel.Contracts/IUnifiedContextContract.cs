using AIKernel.Dtos.Context;

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
    /// <returns>統合コンテキスト Id</returns>
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
}

