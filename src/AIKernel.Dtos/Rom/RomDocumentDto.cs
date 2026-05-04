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

/// <summary>
/// ROM エンティティメタデータ DTO。
/// RCS-001 の entity.id, entity.type, version を表現。
/// </summary>
public sealed record RomEntityMetadataDto
{
    /// <summary>
    /// エンティティ ID。
    /// RCS-001: MUST - 必須。
    /// RCS-F001: 欠落時は ROM 無効。
    /// </summary>
    public required string EntityId { get; init; }

    /// <summary>
    /// エンティティ型。
    /// RCS-001: MUST - 必須。
    /// RCS-F001: 欠落時は ROM 無効。
    /// RCS-F004: Type Consistency 検証でプロパティ定義と照合される。
    /// </summary>
    public required string EntityType { get; init; }

    /// <summary>
    /// ドキュメントバージョン。
    /// RCS-001: MUST - 必須。
    /// SGS-006: Canonical Signing Payload に含まれる。
    /// </summary>
    public required string Version { get; init; }

    /// <summary>
    /// その他の YAML メタデータ。
    /// </summary>
    public IReadOnlyDictionary<string, object> AdditionalMetadata { get; init; } = new Dictionary<string, object>();
}

/// <summary>
/// ROM 関係 DTO。
/// RCS-006: 関係性の記述様式（Property, Action, Quantitative）。
/// </summary>
public sealed record RomRelationDto
{
    /// <summary>
    /// 関係の型（"property", "action", "quantitative"）。
    /// RCS-006: 3 形式に対応。
    /// </summary>
    public required string RelationType { get; init; }

    /// <summary>
    /// 関係名またはプロパティ名（例: "author", "executes"）。
    /// </summary>
    public required string RelationName { get; init; }

    /// <summary>
    /// 対象参照 ID（例: "[[user.tky]]"）。
    /// RCS-002: 解決可能な参照でなければならない。
    /// </summary>
    public string? TargetReference { get; init; }

    /// <summary>
    /// 数値関係（quantitative 型の場合）。
    /// RCS-006: 例: 0.95
    /// </summary>
    public double? NumericValue { get; init; }

    /// <summary>
    /// テキスト値（property 型の場合）。
    /// </summary>
    public string? TextValue { get; init; }
}

/// <summary>
/// 正規化済み ROM ドキュメント DTO。
/// RCS-004: Canonicalization の成果物。
/// ハッシュ計算に用いられる。
/// </summary>
public sealed record CanonicalizedRomDto
{
    /// <summary>
    /// 正規化されたエンティティメタデータ。
    /// </summary>
    public required RomEntityMetadataDto NormalizedMetadata { get; init; }

    /// <summary>
    /// 正規化されたボディ。
    /// RCS-004 Linguistic Normalization: 全角/半角、大文字/小文字、冗長な助詞表現を正規化。
    /// </summary>
    public required string NormalizedBody { get; init; }

    /// <summary>
    /// 正規化済み関係リスト（ソート済み）。
    /// RCS-004 Structural Sorting: 同一見出しレベル内を文字列ソート。
    /// </summary>
    public IReadOnlyList<RomRelationDto> NormalizedRelations { get; init; } = new List<RomRelationDto>();

    /// <summary>
    /// 完全修飾参照に置換された関係。
    /// RCS-004 Reference Anchoring: [[entity.id]] を namespace.project.id へ置換。
    /// </summary>
    public IReadOnlyList<ResolvedRomRelationDto> ResolvedRelations { get; init; } = new List<ResolvedRomRelationDto>();

    /// <summary>
    /// 正規化タイムスタンプ。
    /// </summary>
    public required DateTime CanonicalizedAt { get; init; }
}

/// <summary>
/// 解決済み ROM 関係 DTO。
/// RCS-004 Reference Anchoring の成果物。
/// </summary>
public sealed record ResolvedRomRelationDto
{
    /// <summary>
    /// 元の参照（[[id]]）。
    /// </summary>
    public required string OriginalReference { get; init; }

    /// <summary>
    /// 解決後の完全修飾 ID。
    /// 例: "namespace.project.user.id"
    /// </summary>
    public required string FullyQualifiedId { get; init; }

    /// <summary>
    /// 関係の型。
    /// </summary>
    public required string RelationType { get; init; }
}
