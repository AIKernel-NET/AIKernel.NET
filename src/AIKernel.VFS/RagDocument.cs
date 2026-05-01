namespace AIKernel.VFS;

/// <summary>
/// RAG ドキュメントを表現します。
/// </summary>
public sealed class RagDocument
{
    /// <summary>
    /// ドキュメントの一意識別子を取得または設定します。
    /// </summary>
    public required string DocumentId { get; init; }

    /// <summary>
    /// ドキュメントのタイトルを取得または設定します。
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// ドキュメントのコンテンツを取得または設定します。
    /// </summary>
    public required string Content { get; init; }

    /// <summary>
    /// ドキュメントのソースを取得または設定します。
    /// </summary>
    public string? Source { get; init; }

    /// <summary>
    /// 関連性スコアを取得または設定します（0.0-1.0）。
    /// </summary>
    public double RelevanceScore { get; init; }

    /// <summary>
    /// メタデータを取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Metadata { get; init; }
}
