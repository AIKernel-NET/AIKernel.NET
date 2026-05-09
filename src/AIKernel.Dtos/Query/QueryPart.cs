namespace AIKernel.Dtos.Query;

using System.Collections.Immutable;

/// <summary>
/// Phase 1 の Query Processing によって生成される、意味的に独立した query fragment を表します。
/// </summary>
public sealed record QueryPart
{
    /// <summary>
    /// QueryPart の一意識別子を取得します。
    /// </summary>
    public required string QueryPartId { get; init; }

    /// <summary>
    /// 元 query から分割または補間された query text を取得します。
    /// </summary>
    public required string Text { get; init; }

    /// <summary>
    /// 元 query 内での安定した順序を取得します。
    /// </summary>
    public required int Order { get; init; }

    /// <summary>
    /// 元 query 全体を識別する任意の ID を取得します。
    /// </summary>
    public string? ParentQueryId { get; init; }

    /// <summary>
    /// この QueryPart の意味的な役割を取得します。
    /// </summary>
    public string? Role { get; init; }

    /// <summary>
    /// ルーティングや監査に使う追加メタデータを取得します。
    /// </summary>
    public ImmutableDictionary<string, string> Metadata { get; init; } = ImmutableDictionary<string, string>.Empty;
}
