using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を定義します。
/// OrchestrationContract、ExpressionContract、MaterialContract を統合管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// UC-06（3層バッファによる Attention 制御）, UC-08（コンテキストスナップショットと永続化）
/// JA: IUnifiedContextContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContract']" />
public interface IUnifiedContextContract
{
    /// <summary>
    /// 統合コンテキストの一意識別子を取得します。
    /// JA: GetId 操作を実行します。
    /// </summary>
    /// <returns>統合コンテキスト Id JA: 結果を返します。</returns>
    string GetId();

    /// <summary>
    /// OrchestrationContract を取得します。
    /// JA: GetOrchestration 操作を実行します。
    /// </summary>
    /// <returns>Orchestration 契約 JA: 結果を返します。</returns>
    IOrchestrationContract GetOrchestration();

    /// <summary>
    /// ExpressionContract を取得します。
    /// JA: GetExpression 操作を実行します。
    /// </summary>
    /// <returns>Expression 契約。存在しない場合は null。 JA: 結果を返します。</returns>
    IExpressionContract? GetExpression();

    /// <summary>
    /// MaterialContract を取得します。
    /// JA: GetMaterial 操作を実行します。
    /// </summary>
    /// <returns>Material 契約。存在しない場合は null。 JA: 結果を返します。</returns>
    IMaterialContract? GetMaterial();

    /// <summary>
    /// 統合コンテキストのデータを取得します。
    /// JA: GetContext 操作を実行します。
    /// </summary>
    /// <returns>統合コンテキスト DTO JA: 結果を返します。</returns>
    UnifiedContextDto GetContext();
}

