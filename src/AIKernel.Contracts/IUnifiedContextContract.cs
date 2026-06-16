using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を定義します。
/// OrchestrationContract、ExpressionContract、MaterialContract を統合管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// EN: UC-06（3層バッファによる Attention 制御）, UC-08（コンテキストスナップショットと永続化）
/// EN: Documentation for public API. JA: IUnifiedContextContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContract']" />
public interface IUnifiedContextContract
{
    /// <summary>
    /// EN: 統合コンテキストの一意識別子を取得します。
    /// EN: Documentation for public API. JA: GetId 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 統合コンテキスト Id 結果を返します。</returns>
    string GetId();

    /// <summary>
    /// EN: OrchestrationContract を取得します。
    /// EN: Documentation for public API. JA: GetOrchestration 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Orchestration 契約 結果を返します。</returns>
    IOrchestrationContract GetOrchestration();

    /// <summary>
    /// EN: ExpressionContract を取得します。
    /// EN: Documentation for public API. JA: GetExpression 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Expression 契約。存在しない場合は null。 結果を返します。</returns>
    IExpressionContract? GetExpression();

    /// <summary>
    /// EN: MaterialContract を取得します。
    /// EN: Documentation for public API. JA: GetMaterial 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: Material 契約。存在しない場合は null。 結果を返します。</returns>
    IMaterialContract? GetMaterial();

    /// <summary>
    /// EN: 統合コンテキストのデータを取得します。
    /// EN: Documentation for public API. JA: GetContext 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 統合コンテキスト DTO 結果を返します。</returns>
    UnifiedContextDto GetContext();
}

