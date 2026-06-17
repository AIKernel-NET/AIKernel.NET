namespace AIKernel.Abstractions.Material;

/// <summary>
/// UC-21 に基づく契約です。
/// 構造化された素材を表現するインターフェース。
/// EN: 入力データの正規化と重み付けを保証します。
/// [EN] Documents this public package API member. [JA] IStructuredMaterial の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IStructuredMaterial']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IStructuredMaterial']" />
public interface IStructuredMaterial
{
    /// <summary>
    /// EN: 素材の元のコンテンツを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string RawContent { get; }

    /// <summary>
    /// EN: 正規化・クリーニングされたコンテンツを取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string NormalizedContent { get; }

    /// <summary>
    /// EN: 素材の重要度・信頼度（0.0 ～ 1.0）を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    double Weight { get; }

    /// <summary>
    /// EN: 素材の出典情報を取得します。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    SourceInfo SourceInfo { get; }
}

