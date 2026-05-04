using AIKernel.Enums;

namespace AIKernel.Dtos;

/// <summary>
/// 情報カテゴリとその値を表現する DTO です。
/// 
/// 参照: 1.CATEGORY_SEPARATION_PRINCIPLES.jp.md
/// </summary>
public sealed class InformationCategoryDto
{
    /// <summary>
    /// 情報のカテゴリを取得または設定します。
    /// </summary>
    public required InformationCategory Category { get; init; }

    /// <summary>
    /// カテゴリに属する値を取得または設定します。
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// 値の優先度を取得または設定します（高いほど優先）。
    /// </summary>
    public int Priority { get; init; } = 0;

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
