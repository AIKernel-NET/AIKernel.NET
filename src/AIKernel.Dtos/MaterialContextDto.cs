using AIKernel.Enums;

namespace AIKernel.Dtos;

/// <summary>
/// MaterialContext のデータを表現する DTO です。
/// RAG の断片や外部情報を含み、必ず正規化・構造化して使用します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public sealed class MaterialContextDto
{
    /// <summary>
    /// 取得元ソースを取得または設定します。
    /// </summary>
    public required string Source { get; init; }

    /// <summary>
    /// 生の素材データを取得または設定します。
    /// </summary>
    public required string RawData { get; init; }

    /// <summary>
    /// 正規化されたデータを取得または設定します。
    /// 不要情報が除去されたバージョン。
    /// </summary>
    public string? NormalizedData { get; init; }

    /// <summary>
    /// 構造化されたデータを取得または設定します。
    /// 要素分解・抽象化・意味単位化されたバージョン。
    /// </summary>
    public Dictionary<string, object>? StructuredData { get; init; }

    /// <summary>
    /// 関連性スコアを取得または設定します（0.0 ～ 1.0）。
    /// </summary>
    public double RelevanceScore { get; init; } = 1.0;

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }

    /// <summary>
    /// 取得日時を取得または設定します。
    /// </summary>
    public DateTime RetrievedAt { get; init; } = DateTime.UtcNow;
}
