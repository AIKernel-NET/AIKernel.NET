namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく契約です。
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
    IReadOnlyDictionary<string, string> Metadata { get; }

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
    Task<CanonicalizedRomDto> CanonicalizeAsync();
}

