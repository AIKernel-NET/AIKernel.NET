namespace AIKernel.Dtos.Providers.Embedding;

/// <summary>[EN] Sparse vector with ascending unique vocabulary indices. [JA] 昇順・重複なしの語彙インデックスを持つ疎ベクトル。</summary>
public sealed record SparseEmbedding
{
    /// <summary>[EN] Nonzero positions. [JA] 非ゼロ要素の位置。</summary>
    public required IReadOnlyList<int> Indices { get; init; }
    /// <summary>[EN] Values in the same order as the indices. [JA] インデックス順の値。</summary>
    public required IReadOnlyList<float> Values { get; init; }
}

/// <summary>[EN] Vector corresponding to one original input. [JA] 元の入力1件に対応するベクトル。</summary>
public sealed record EmbeddingVector
{
    /// <summary>[EN] Zero-based position in the request. [JA] 要求内の0起点の位置。</summary>
    public required int Index { get; init; }
    /// <summary>[EN] Dense output when requested. [JA] 要求した場合の密ベクトル。</summary>
    public float[]? Dense { get; init; }
    /// <summary>[EN] Sparse output when requested. [JA] 要求した場合の疎ベクトル。</summary>
    public SparseEmbedding? Sparse { get; init; }
}

/// <summary>[EN] Ordered embeddings with the resolved model and output options. [JA] 解決済みのモデル・出力設定と順序付きベクトル。</summary>
public sealed record EmbeddingResult
{
    /// <summary>[EN] Executing provider ID. [JA] 実行したProviderのID。</summary>
    public required string ProviderId { get; init; }
    /// <summary>[EN] Model ID used for all items. [JA] 全入力に使用したモデルID。</summary>
    public required string ModelId { get; init; }
    /// <summary>[EN] Actual dense dimension. [JA] 密ベクトルの実際の次元数。</summary>
    public int? Dimensions { get; init; }
    /// <summary>[EN] Whether dense output is L2 normalized. [JA] 密ベクトルをL2正規化したか。</summary>
    public bool? Normalized { get; init; }
    /// <summary>[EN] Actual sparse vocabulary dimension. [JA] 疎ベクトルの語彙空間の次元数。</summary>
    public int? SparseDimension { get; init; }
    /// <summary>[EN] Exactly one result per input in index order. [JA] 入力1件につき結果1件を入力順で格納。</summary>
    public required IReadOnlyList<EmbeddingVector> Items { get; init; }
}
