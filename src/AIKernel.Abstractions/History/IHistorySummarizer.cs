using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Material;

namespace AIKernel.Abstractions.History;

/// <summary>
/// UC-32 に基づく契約です。
/// 履歴を要約・投影するインターフェース。
/// EN: 履歴を単なるログではなく、再利用可能な素材または文脈として扱います。
/// EN: Documentation for public API. JA: IHistorySummarizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistorySummarizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.History.IHistorySummarizer']" />
public interface IHistorySummarizer
{
    /// <summary>
    /// EN: 履歴を素材として要約します。
    /// EN: Documentation for public API. JA: SummarizeAsMaterialAsync 操作を実行します。
    /// </summary>
    /// <param name="history">EN: Documentation for public API. JA: 履歴フラグメントのシーケンス history パラメーターです。</param>
    /// <param name="ct">EN: Documentation for public API. JA: キャンセルトークン ct パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 正規化された素材一覧 結果を返します。</returns>
    Task<IEnumerable<IStructuredMaterial>> SummarizeAsMaterialAsync(
        IEnumerable<ContextFragment> history,
        CancellationToken ct = default);

    /// <summary>
    /// EN: 履歴をコンテキストコレクションとして投影します。
    /// EN: Documentation for public API. JA: ProjectAsContextAsync 操作を実行します。
    /// </summary>
    /// <param name="history">EN: Documentation for public API. JA: 履歴フラグメントのシーケンス history パラメーターです。</param>
    /// <param name="policy">EN: Documentation for public API. JA: 投影ポリシー policy パラメーターです。</param>
    /// <param name="ct">EN: Documentation for public API. JA: キャンセルトークン ct パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 投影されたコンテキストコレクション 結果を返します。</returns>
    Task<IContextCollection> ProjectAsContextAsync(
        IEnumerable<ContextFragment> history,
        HistoryPolicy policy,
        CancellationToken ct = default);
}

