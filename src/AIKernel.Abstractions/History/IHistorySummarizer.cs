using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Material;

namespace AIKernel.Abstractions.History;

/// <summary>
/// UC-32 に基づく契約です。
/// 履歴を要約・投影するインターフェース。
/// 履歴を単なるログではなく、再利用可能な素材または文脈として扱います。
/// JA: IHistorySummarizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistorySummarizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistorySummarizer']" />
public interface IHistorySummarizer
{
    /// <summary>
    /// 履歴を素材として要約します。
    /// JA: SummarizeAsMaterialAsync 操作を実行します。
    /// </summary>
    /// <param name="history">履歴フラグメントのシーケンス JA: history パラメーターです。</param>
    /// <param name="ct">キャンセルトークン JA: ct パラメーターです。</param>
    /// <returns>正規化された素材一覧 JA: 結果を返します。</returns>
    Task<IEnumerable<IStructuredMaterial>> SummarizeAsMaterialAsync(
        IEnumerable<ContextFragment> history,
        CancellationToken ct = default);

    /// <summary>
    /// 履歴をコンテキストコレクションとして投影します。
    /// JA: ProjectAsContextAsync 操作を実行します。
    /// </summary>
    /// <param name="history">履歴フラグメントのシーケンス JA: history パラメーターです。</param>
    /// <param name="policy">投影ポリシー JA: policy パラメーターです。</param>
    /// <param name="ct">キャンセルトークン JA: ct パラメーターです。</param>
    /// <returns>投影されたコンテキストコレクション JA: 結果を返します。</returns>
    Task<IContextCollection> ProjectAsContextAsync(
        IEnumerable<ContextFragment> history,
        HistoryPolicy policy,
        CancellationToken ct = default);
}

