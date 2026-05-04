namespace AIKernel.Abstractions.Rom;

/// <summary>
/// Relation-Oriented Markdown (ROM) ドキュメントの抽象化。
/// RCS-001: ROM 文書は entity.id と entity.type を持たなければならない（MUST）。
/// RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
/// </summary>
public interface IRomDocument
{
    /// <summary>
    /// エンティティの ID。
    /// RCS-001: entity.id 必須。
    /// </summary>
    string EntityId { get; }

    /// <summary>
    /// エンティティの型。
    /// RCS-001: entity.type 必須。
    /// </summary>
    string EntityType { get; }

    /// <summary>
    /// ROM ドキュメントのバージョン。
    /// SGS-006 の署名対象に含まれる。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// 本文（Markdown）。
    /// RCS-003: 事実は bullet 形式で宣言的に記述される。
    /// </summary>
    string Body { get; }

    /// <summary>
    /// YAML front matter のメタデータ。
    /// </summary>
    IReadOnlyDictionary<string, object> Metadata { get; }

    /// <summary>
    /// ドキュメント内に含まれるすべての関係参照（[[id]]）。
    /// RCS-002: 参照可能性の検証に用いる。
    /// </summary>
    IReadOnlyList<string> RelationReferences { get; }

    /// <summary>
    /// セマンティックハッシュを取得します。
    /// RCS-004: 正規化後の Semantic Hash を算出できなければならない（MUST）。
    /// </summary>
    /// <returns>ハッシュ値（例: "sha256:a1b2c3d4..."）</returns>
    Task<string> GetSemanticHashAsync();

    /// <summary>
    /// ドキュメントを正規化された形式に変換します。
    /// RCS-004 の正規化処理（Linguistic, Structural, Reference Anchoring）。
    /// </summary>
    /// <returns>正規化されたドキュメント表現</returns>
    Task<CanonicalizedRomDocument> CanonicalizeAsync();
}

/// <summary>
/// 正規化された ROM ドキュメント。
/// RCS-004: 正規化後のセマンティックハッシュを生成するために使用される。
/// </summary>
public sealed record CanonicalizedRomDocument
{
    /// <summary>
    /// 正規化された entity ID。
    /// </summary>
    public required string NormalizedEntityId { get; init; }

    /// <summary>
    /// 正規化されたメタデータ（ソート済み）。
    /// RCS-004 Structural Sorting: 同一見出しレベル内の bullet 集合を文字列ソート。
    /// </summary>
    public required IReadOnlyDictionary<string, string> NormalizedMetadata { get; init; }

    /// <summary>
    /// 正規化されたボディ。
    /// RCS-004 Linguistic Normalization: 全角/半角の統一、大文字/小文字の統一。
    /// </summary>
    public required string NormalizedBody { get; init; }

    /// <summary>
    /// 完全修飾参照に置換された関係リスト。
    /// RCS-004 Reference Anchoring: [[entity.id]] を namespace.project.id へ置換。
    /// </summary>
    public IReadOnlyList<ResolvedRelation> ResolvedRelations { get; init; } = new List<ResolvedRelation>();

    /// <summary>
    /// この正規化の生成タイムスタンプ。
    /// </summary>
    public required DateTime CanonicalizedAt { get; init; }
}

/// <summary>
/// 解決済みの関係参照。
/// RCS-004 Reference Anchoring の成果物。
/// </summary>
public sealed record ResolvedRelation
{
    /// <summary>
    /// 元の参照（[[id]]）。
    /// </summary>
    public required string OriginalReference { get; init; }

    /// <summary>
    /// 解決後の完全修飾 ID。
    /// 例: "namespace.project.id"
    /// </summary>
    public required string ResolvedId { get; init; }

    /// <summary>
    /// 参照の型（"property", "action", "quantitative"）。
    /// RCS-006 の 3 形式に対応。
    /// </summary>
    public required string RelationType { get; init; }
}
