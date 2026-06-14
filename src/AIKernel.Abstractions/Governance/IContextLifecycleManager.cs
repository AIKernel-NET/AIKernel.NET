namespace AIKernel.Abstractions.Governance;

using AIKernel.Dtos.Context;

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// コンテキストバッファの寿命管理と状態遷移を統治するインターフェースです。
/// 履歴の忘却、圧縮、昇格などの戦略をOS レベルで標準化します。
/// JA: IContextLifecycleManager の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IContextLifecycleManager']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IContextLifecycleManager']" />
public interface IContextLifecycleManager
{
    /// <summary>
    /// Orchestration から Material へのコンテキスト昇格を実行します。
    /// 推論フェーズが完了後、結果をマテリアル化されたコンテキストに昇格させます。
    /// JA: PromoteOrchestrationToMaterialAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">対象のコンテキスト集約 JA: collection パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>昇格後のコンテキスト集約 JA: 結果を返します。</returns>
    Task<IContextCollection> PromoteOrchestrationToMaterialAsync(
        IContextCollection collection,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定カテゴリのコンテキストフラグメントをクリアします。
    /// JA: ClearByCategoryAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">対象のコンテキスト集約 JA: collection パラメーターです。</param>
    /// <param name="category">クリア対象のカテゴリ JA: category パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>クリア後のコンテキスト集約 JA: 結果を返します。</returns>
    Task<IContextCollection> ClearByCategoryAsync(
        IContextCollection collection,
        ContextCategory category,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 期限切れまたは不要なコンテキストフラグメントを削除します。
    /// JA: PurgeExpiredFragmentsAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">対象のコンテキスト集約 JA: collection パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>整理後のコンテキスト集約 JA: 結果を返します。</returns>
    Task<IContextCollection> PurgeExpiredFragmentsAsync(
        IContextCollection collection,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// コンテキストを圧縮し、冗長性を削減します。
    /// JA: CompressAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">対象のコンテキスト集約 JA: collection パラメーターです。</param>
    /// <param name="compressionRatio">圧縮率（0.0 ~ 1.0） JA: compressionRatio パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>圧縮後のコンテキスト集約 JA: 結果を返します。</returns>
    Task<IContextCollection> CompressAsync(
        IContextCollection collection,
        float compressionRatio = 0.7f,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// コンテキストを要約し、忘却戦略を適用します。
    /// JA: SummarizeAndForgetAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">対象のコンテキスト集約 JA: collection パラメーターです。</param>
    /// <param name="policyType">忘却ポリシーの種類 JA: policyType パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>要約後のコンテキスト集約 JA: 結果を返します。</returns>
    Task<IContextCollection> SummarizeAndForgetAsync(
        IContextCollection collection,
        string policyType,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// コンテキストのライフサイクル状態を確認します。
    /// JA: GetLifecycleStateAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">対象のコンテキスト集約 JA: collection パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>ライフサイクル状態情報 JA: 結果を返します。</returns>
    Task<ContextLifecycleState> GetLifecycleStateAsync(
        IContextCollection collection,
        CancellationToken cancellationToken = default);
}

