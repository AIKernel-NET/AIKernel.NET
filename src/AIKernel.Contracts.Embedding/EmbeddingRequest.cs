namespace AIKernel.Dtos.Providers.Embedding;

/// <summary>[EN] Requested embedding output forms. [JA] 要求する埋め込みの形式。</summary>
[Flags]
public enum EmbeddingOutputKind
{
    /// <summary>[EN] No output forms. [JA] 出力形式なし。</summary>
    None = 0,
    /// <summary>[EN] Dense floating-point vector. [JA] 密な浮動小数点ベクトル。</summary>
    Dense = 1,
    /// <summary>[EN] Sparse vector. [JA] 疎ベクトル。</summary>
    Sparse = 2
}

/// <summary>[EN] Semantic role of an input in retrieval. [JA] 検索における入力の用途。</summary>
public enum EmbeddingPurpose
{
    /// <summary>[EN] Search query. [JA] 検索クエリ。</summary>
    Query,
    /// <summary>[EN] Searchable document or passage. [JA] 検索対象の文書またはパッセージ。</summary>
    Document
}

/// <summary>[EN] Embedding request with optional model defaults. [JA] モデル既定値を指定できる埋め込み要求。</summary>
public sealed record EmbeddingRequest
{
    /// <summary>[EN] Non-empty ordered input batch. [JA] 1件以上の順序付き入力。</summary>
    public required IReadOnlyList<EmbeddingInput> Inputs { get; init; }
    /// <summary>[EN] Model identifier or null for the default. [JA] モデルID。未指定時は既定。</summary>
    public string? ModelId { get; init; }
    /// <summary>[EN] Output forms or null for the default. [JA] 出力形式。未指定時は既定。</summary>
    public EmbeddingOutputKind? OutputKinds { get; init; }
    /// <summary>[EN] Dense dimensions or null for full length. [JA] 密ベクトルの次元数。未指定時は全長。</summary>
    public int? Dimensions { get; init; }
    /// <summary>[EN] Dense L2 normalization or null for the default. [JA] 密ベクトルのL2正規化。未指定時は既定。</summary>
    public bool? Normalize { get; init; }
    /// <summary>[EN] Query or document purpose, or null for the configured default. [JA] 検索クエリまたは文書の用途。未指定時は設定の既定値。</summary>
    public EmbeddingPurpose? Purpose { get; init; }
}
