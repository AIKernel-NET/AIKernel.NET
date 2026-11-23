namespace AIKernel.Dtos.Providers.Reranking;

/// <summary>[EN] One text candidate. [JA] テキスト候補1件。</summary>
public sealed record RerankCandidate(string Text);

/// <summary>[EN] Reranking request with one query and ordered candidates. [JA] クエリ1件と順序付き候補を持つ再順位付け要求。</summary>
public sealed record RerankRequest
{
    /// <summary>[EN] Non-empty query. [JA] 空でないクエリ。</summary>
    public required string Query { get; init; }

    /// <summary>[EN] Non-empty candidate list in original order. [JA] 入力順の候補リスト。1件以上。</summary>
    public required IReadOnlyList<RerankCandidate> Candidates { get; init; }

    /// <summary>[EN] Model ID or null to use the provider default. [JA] モデルID。未指定時はProviderの既定モデル。</summary>
    public string? ModelId { get; init; }

    /// <summary>[EN] Results to return, between 1 and the candidate count, or null for all. [JA] 返す件数。1以上、候補数以下。未指定時は全件。</summary>
    public int? TopK { get; init; }
}

/// <summary>[EN] Reranked input indices and scores. [JA] 再順位付け後の入力位置とスコア。</summary>
public sealed record RerankResult
{
    /// <summary>[EN] Executing provider ID. [JA] 実行したProviderのID。</summary>
    public required string ProviderId { get; init; }

    /// <summary>[EN] Model ID used to score the candidates. [JA] 候補の採点に使ったモデルID。</summary>
    public required string ModelId { get; init; }

    /// <summary>[EN] Best-first scores with zero-based original indices and null labels. [JA] 上位順のスコア。入力位置は0起点で、ラベルはnull。</summary>
    public required ScoredResult Scores { get; init; }
}

/// <summary>[EN] Reranker scoring semantics and input limits. [JA] 再順位付けのスコアの意味と入力上限。</summary>
public sealed record RerankerCapabilityExtension : ProviderCapabilityExtension
{
    /// <inheritdoc />
    public override ProviderKind Kind => ProviderKind.Reranker;

    /// <summary>[EN] Same score interpretation as the result. [JA] 結果と共通のスコアの解釈規則。</summary>
    public required ScoreSemantics ScoreSemantics { get; init; }

    /// <summary>[EN] Query length limit in the descriptor's item length unit. [JA] 候補長と同じ単位のクエリ上限。</summary>
    public long? MaxQueryLength { get; init; }

    /// <summary>[EN] Combined query and candidate length limit. [JA] クエリと候補を組にした場合の長さ上限。</summary>
    public long? MaxPairLength { get; init; }

    /// <summary>[EN] Optional scoring method description. [JA] 採点方式の説明。</summary>
    public string? ScoringMethod { get; init; }
}
