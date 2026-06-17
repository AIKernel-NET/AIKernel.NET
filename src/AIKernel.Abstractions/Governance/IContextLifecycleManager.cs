namespace AIKernel.Abstractions.Governance;

using AIKernel.Dtos.Context;

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// コンテキストバッファの寿命管理と状態遷移を統治するインターフェースです。
/// EN: 履歴の忘却、圧縮、昇格などの戦略をOS レベルで標準化します。
/// [EN] Documents this public package API member. [JA] IContextLifecycleManager の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IContextLifecycleManager']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IContextLifecycleManager']" />
public interface IContextLifecycleManager
{
    /// <summary>
    /// Orchestration から Material へのコンテキスト昇格を実行します。
    /// EN: 推論フェーズが完了後、結果をマテリアル化されたコンテキストに昇格させます。
    /// [EN] Documents this public package API member. [JA] PromoteOrchestrationToMaterialAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">[EN] Documents this public package API member. [JA] 対象のコンテキスト集約 collection パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 昇格後のコンテキスト集約 結果を返します。</returns>
    Task<IContextCollection> PromoteOrchestrationToMaterialAsync(
        IContextCollection collection,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: 指定カテゴリのコンテキストフラグメントをクリアします。
    /// [EN] Documents this public package API member. [JA] ClearByCategoryAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">[EN] Documents this public package API member. [JA] 対象のコンテキスト集約 collection パラメーターです。</param>
    /// <param name="category">[EN] Documents this public package API member. [JA] クリア対象のカテゴリ category パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] クリア後のコンテキスト集約 結果を返します。</returns>
    Task<IContextCollection> ClearByCategoryAsync(
        IContextCollection collection,
        ContextCategory category,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: 期限切れまたは不要なコンテキストフラグメントを削除します。
    /// [EN] Documents this public package API member. [JA] PurgeExpiredFragmentsAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">[EN] Documents this public package API member. [JA] 対象のコンテキスト集約 collection パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 整理後のコンテキスト集約 結果を返します。</returns>
    Task<IContextCollection> PurgeExpiredFragmentsAsync(
        IContextCollection collection,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: コンテキストを圧縮し、冗長性を削減します。
    /// [EN] Documents this public package API member. [JA] CompressAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">[EN] Documents this public package API member. [JA] 対象のコンテキスト集約 collection パラメーターです。</param>
    /// <param name="compressionRatio">[EN] Documents this public package API member. [JA] 圧縮率（0.0 ~ 1.0） compressionRatio パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 圧縮後のコンテキスト集約 結果を返します。</returns>
    Task<IContextCollection> CompressAsync(
        IContextCollection collection,
        float compressionRatio = 0.7f,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: コンテキストを要約し、忘却戦略を適用します。
    /// [EN] Documents this public package API member. [JA] SummarizeAndForgetAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">[EN] Documents this public package API member. [JA] 対象のコンテキスト集約 collection パラメーターです。</param>
    /// <param name="policyType">[EN] Documents this public package API member. [JA] 忘却ポリシーの種類 policyType パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 要約後のコンテキスト集約 結果を返します。</returns>
    Task<IContextCollection> SummarizeAndForgetAsync(
        IContextCollection collection,
        string policyType,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: コンテキストのライフサイクル状態を確認します。
    /// [EN] Documents this public package API member. [JA] GetLifecycleStateAsync 操作を実行します。
    /// </summary>
    /// <param name="collection">[EN] Documents this public package API member. [JA] 対象のコンテキスト集約 collection パラメーターです。</param>
    /// <param name="cancellationToken">[EN] Documents this public package API member. [JA] キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] ライフサイクル状態情報 結果を返します。</returns>
    Task<ContextLifecycleState> GetLifecycleStateAsync(
        IContextCollection collection,
        CancellationToken cancellationToken = default);
}

