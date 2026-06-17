using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 素材（Material）契約を定義します。
/// RAG の断片や外部情報の取得・構造化を管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// EN: UC-21（マテリアル検疫とポリシー実行）
/// [EN] Documents this public package API member. [JA] IMaterialContract の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialContract']" />
public interface IMaterialContract
{
    /// <summary>
    /// EN: 素材層のコンテキストを取得します。
    /// [EN] Documents this public package API member. [JA] GetContext 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] Material コンテキスト 結果を返します。</returns>
    MaterialContextDto GetContext();

    /// <summary>
    /// EN: 取得元ソースを取得します。
    /// [EN] Documents this public package API member. [JA] GetSource 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 取得元ソース識別子 結果を返します。</returns>
    string GetSource();

    /// <summary>
    /// EN: 生のデータを取得します。
    /// [EN] Documents this public package API member. [JA] GetRawData 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 生データ 結果を返します。</returns>
    string GetRawData();

    /// <summary>
    /// 正規化されたデータを取得します。
    /// EN: 不要情報が除去されたバージョン。
    /// [EN] Documents this public package API member. [JA] GetNormalizedData 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 正規化済みデータ。未正規化の場合は null。 結果を返します。</returns>
    string? GetNormalizedData();

    /// <summary>
    /// EN: 構造化されたデータを取得します。
    /// [EN] Documents this public package API member. [JA] GetStructuredData 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 構造化データ。未構造化の場合は null。 結果を返します。</returns>
    IReadOnlyDictionary<string, object>? GetStructuredData();

    /// <summary>
    /// EN: 関連性スコアを取得します（0.0 ～ 1.0）。
    /// [EN] Documents this public package API member. [JA] GetRelevanceScore 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 関連性スコア 結果を返します。</returns>
    double GetRelevanceScore();
}

