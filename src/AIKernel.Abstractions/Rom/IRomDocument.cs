namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく契約です。
/// Relation-Oriented Markdown (ROM) ドキュメントの抽象化。
/// RCS-001: ROM 文書は entity.id と entity.type を持たなければならない（MUST）。
/// EN: RCS-002: [[id]] は解決可能な参照でなければならない（MUST）。
/// [EN] Documents this public package API member. [JA] IRomDocument の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomDocument']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomDocument']" />
public interface IRomDocument
{
    /// <summary>
    /// エンティティの ID。
    /// EN: RCS-001: entity.id 必須。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string EntityId { get; }

    /// <summary>
    /// エンティティの型。
    /// EN: RCS-001: entity.type 必須。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string EntityType { get; }

    /// <summary>
    /// ROM ドキュメントのバージョン。
    /// EN: SGS-006 の署名対象に含まれる。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// 本文（Markdown）。
    /// EN: RCS-003: 事実は bullet 形式で宣言的に記述される。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    string Body { get; }

    /// <summary>
    /// EN: YAML front matter のメタデータ。
    /// [EN] Documents this public package API member. [JA] このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyDictionary<string, string> Metadata { get; }

    /// <summary>
    /// ドキュメント内に含まれるすべての関係参照（[[id]]）。
    /// EN: RCS-002: 参照可能性の検証に用いる。
    /// [EN] Documents this public package API member. [JA] GetSemanticHashAsync 操作を実行します。
    /// </summary>
    IReadOnlyList<string> RelationReferences { get; }

    /// <summary>
    /// セマンティックハッシュを取得します。
    /// EN: RCS-004: 正規化後の Semantic Hash を算出できなければならない（MUST）。
    /// [EN] Documents this public package API member. [JA] GetSemanticHashAsync 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] ハッシュ値（例: "sha256:a1b2c3d4..."） 結果を返します。</returns>
    Task<string> GetSemanticHashAsync();

    /// <summary>
    /// ドキュメントを正規化された形式に変換します。
    /// EN: RCS-004 の正規化処理（Linguistic, Structural, Reference Anchoring）。
    /// [EN] Documents this public package API member. [JA] CanonicalizeAsync 操作を実行します。
    /// </summary>
    /// <returns>[EN] Documents this public package API member. [JA] 正規化されたドキュメント表現 結果を返します。</returns>
    Task<CanonicalizedRomDto> CanonicalizeAsync();
}

