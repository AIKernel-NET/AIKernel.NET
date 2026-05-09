using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 素材（Material）契約を定義します。
/// RAG の断片や外部情報の取得・構造化を管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// UC-21（マテリアル検疫とポリシー実行）
/// </summary>
public interface IMaterialContract
{
    /// <summary>
    /// 素材層のコンテキストを取得します。
    /// </summary>
    /// <returns>Material コンテキスト</returns>
    MaterialContextDto GetContext();

    /// <summary>
    /// 取得元ソースを取得します。
    /// </summary>
    /// <returns>取得元ソース識別子</returns>
    string GetSource();

    /// <summary>
    /// 生のデータを取得します。
    /// </summary>
    /// <returns>生データ</returns>
    string GetRawData();

    /// <summary>
    /// 正規化されたデータを取得します。
    /// 不要情報が除去されたバージョン。
    /// </summary>
    /// <returns>正規化済みデータ。未正規化の場合は null。</returns>
    string? GetNormalizedData();

    /// <summary>
    /// 構造化されたデータを取得します。
    /// </summary>
    /// <returns>構造化データ。未構造化の場合は null。</returns>
    IReadOnlyDictionary<string, object>? GetStructuredData();

    /// <summary>
    /// 関連性スコアを取得します（0.0 ～ 1.0）。
    /// </summary>
    /// <returns>関連性スコア</returns>
    double GetRelevanceScore();
}

