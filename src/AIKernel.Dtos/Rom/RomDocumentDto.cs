namespace AIKernel.Dtos.Rom;

/// <summary>
/// ROM ドキュメント DTO。
/// RCS-001: ROM 文書は entity.id と entity.type を持たなければならない（MUST）。
/// </summary>
public sealed record RomDocumentDto
{
    /// <summary>
    /// YAML front matter のメタデータ。
    /// RCS-001: entity.id, entity.type, version を必ず含む。
    /// </summary>
    public required RomEntityMetadataDto EntityMetadata { get; init; }

    /// <summary>
    /// Markdown 本文。
    /// RCS-003: 事実は bullet 形式で宣言的に記述される。
    /// </summary>
    public required string Body { get; init; }

    /// <summary>
    /// 本文内に含まれる関係参照（[[id]]）のリスト。
    /// RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
    /// </summary>
    public IReadOnlyList<string> RelationReferences { get; init; } = new List<string>();

    /// <summary>
    /// セマンティックハッシュ。
    /// RCS-004: 正規化後の Semantic Hash。
    /// SGS-005, SGS-006 の署名対象に含まれる。
    /// </summary>
    public string? SemanticHash { get; init; }

    /// <summary>
    /// ドキュメント生成タイムスタンプ。
    /// </summary>
    public required DateTime CreatedAt { get; init; }

    /// <summary>
    /// ドキュメント最終更新タイムスタンプ。
    /// </summary>
    public DateTime? UpdatedAt { get; init; }
}
