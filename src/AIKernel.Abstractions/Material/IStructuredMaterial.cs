namespace AIKernel.Abstractions.Material;

/// <summary>
/// 構造化された素材を表現するインターフェース。
/// 入力データの正規化と重み付けを保証します。
/// </summary>
public interface IStructuredMaterial
{
    /// <summary>
    /// 素材の元のコンテンツを取得します。
    /// </summary>
    string RawContent { get; }

    /// <summary>
    /// 正規化・クリーニングされたコンテンツを取得します。
    /// </summary>
    string NormalizedContent { get; }

    /// <summary>
    /// 素材の重要度・信頼度（0.0 ～ 1.0）を取得します。
    /// </summary>
    double Weight { get; }

    /// <summary>
    /// 素材の出典情報を取得します。
    /// </summary>
    SourceInfo SourceInfo { get; }
}
