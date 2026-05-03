namespace AIKernel.Abstractions.Material;

/// <summary>
/// 素材の出典情報を表現します。
/// </summary>
public sealed class SourceInfo
{
    /// <summary>
    /// 出典の一意識別子を取得または設定します。
    /// </summary>
    public required string SourceId { get; init; }

    /// <summary>
    /// 出典の型（例: "database", "api", "file", "user_input"）を取得または設定します。
    /// </summary>
    public required string SourceType { get; init; }

    /// <summary>
    /// 素材が収集された日時を取得または設定します。
    /// </summary>
    public required DateTimeOffset CollectedAt { get; init; }

    /// <summary>
    /// 出典に関する追加のメタデータを取得または設定します。
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}
