using AIKernel.Dtos.Context;
using AIKernel.Abstractions.Material;

namespace AIKernel.Abstractions.History;

/// <summary>
/// 履歴を要約・投影するインターフェース。
/// 履歴を単なるログではなく、再利用可能な素材または文脈として扱います。
/// </summary>
public interface IHistorySummarizer
{
    /// <summary>
    /// 履歴を素材として要約します。
    /// </summary>
    /// <param name="history">履歴フラグメントのシーケンス</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>正規化された素材一覧</returns>
    Task<IEnumerable<IStructuredMaterial>> SummarizeAsMaterialAsync(
        IEnumerable<ContextFragment> history,
        CancellationToken ct = default);

    /// <summary>
    /// 履歴をコンテキストコレクションとして投影します。
    /// </summary>
    /// <param name="history">履歴フラグメントのシーケンス</param>
    /// <param name="policy">投影ポリシー</param>
    /// <param name="ct">キャンセルトークン</param>
    /// <returns>投影されたコンテキストコレクション</returns>
    Task<IContextCollection> ProjectAsContextAsync(
        IEnumerable<ContextFragment> history,
        HistoryPolicy policy,
        CancellationToken ct = default);
}
