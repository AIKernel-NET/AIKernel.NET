namespace AIKernel.Dtos.Execution;

/// <summary>
/// Thought Artifact DTO。
/// EPS-001: IThoughtProcess は構造化成果物のみを出力しなければならない（MUST）。
/// Structure フェーズの出力を表現します。
/// </summary>
public sealed record ThoughtArtifactDto
{
    /// <summary>
    /// アーティファクトの一意識別子。
    /// </summary>
    public required string ArtifactId { get; init; }

    /// <summary>
    /// 推論パス（思考過程の記録）。
    /// EPS-F003: 必須項目欠落時は停止する。
    /// </summary>
    public required string ReasoningPath { get; init; }

    /// <summary>
    /// 結論（推論結果）。
    /// EPS-F003: 必須項目欠落時は停止する。
    /// </summary>
    public required string Conclusion { get; init; }

    /// <summary>
    /// 実行プラン（Generation 用の指示）。
    /// Generation フェーズがこれに従わなければならない（EPS-002）。
    /// Logic Divergence Check (EPS-F005) で検証される。
    /// </summary>
    public required string ExecutionPlan { get; init; }

    /// <summary>
    /// スキーマ定義（JSON Schema）。
    /// EPS-F001: スキーマ検証失敗時は停止する。
    /// </summary>
    public required string SchemaDefinition { get; init; }

    /// <summary>
    /// メタデータ（生成タイムスタンプ、モデル選定根拠など）。
    /// </summary>
    public IReadOnlyDictionary<string, object> Metadata { get; init; } = new Dictionary<string, object>();

    /// <summary>
    /// 生成タイムスタンプ。
    /// </summary>
    public required DateTime GeneratedAt { get; init; }

    /// <summary>
    /// 構造化成果物のハッシュ。
    /// EPS-005: フェーズ受け渡しデータはハッシュで完全性検証する。
    /// </summary>
    public string? IntegrityHash { get; init; }
}
