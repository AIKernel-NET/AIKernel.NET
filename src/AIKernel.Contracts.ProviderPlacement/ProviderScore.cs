namespace AIKernel.Dtos.Providers;

/// <summary>[EN] Meaning of a model score. [JA] モデルのスコアの意味。</summary>
public enum ScoreKind
{
    /// <summary>[EN] Raw model output. [JA] モデルの生出力。</summary>
    Raw,
    /// <summary>[EN] Probability in the range 0–1. [JA] 0〜1 の確率。</summary>
    Probability,
    /// <summary>[EN] Similarity. [JA] 類似度。</summary>
    Similarity,
    /// <summary>[EN] Distance, lower is better. [JA] 距離。小さいほど良い。</summary>
    Distance
}

/// <summary>[EN] Optional score bounds. [JA] 既知の場合に申告するスコア範囲。</summary>
public sealed record ScoreRange(double? Min, double? Max);

/// <summary>[EN] Raw score value with model semantics attached to the result. [JA] 結果に解釈規則を伴うスコア値。</summary>
public readonly record struct ProviderScore(double Value);

/// <summary>[EN] Model-defined interpretation of a score. [JA] モデルが定めるスコアの解釈規則。</summary>
public sealed record ScoreSemantics
{
    /// <summary>[EN] Interpretation of the score. [JA] スコアの意味。</summary>
    public required ScoreKind Kind { get; init; }
    /// <summary>[EN] Whether larger values rank first. [JA] 値が大きいものを上位とするか。</summary>
    public required bool HigherIsBetter { get; init; }
    /// <summary>[EN] Known output bounds. [JA] 既知の場合の出力範囲。</summary>
    public ScoreRange Range { get; init; } = new(null, null);
    /// <summary>[EN] Whether probability scores are calibrated. [JA] 確率スコアが較正済みか。</summary>
    public bool Calibrated { get; init; }
}

/// <summary>[EN] Score and zero-based original index. [JA] スコアと0起点の入力順。</summary>
public sealed record ScoredItem
{
    /// <summary>[EN] Zero-based index in the input. [JA] 0起点の入力位置。</summary>
    public required int Index { get; init; }
    /// <summary>[EN] Score returned by the model. [JA] モデルの出力スコア。</summary>
    public required ProviderScore Score { get; init; }
    /// <summary>[EN] Optional classification label. [JA] 分類時に使うラベル。</summary>
    public string? Label { get; init; }
}

/// <summary>[EN] Best-first scores with ties in input order. [JA] 良い順のスコア。同点は入力順。</summary>
public sealed record ScoredResult
{
    /// <summary>[EN] Score interpretation. [JA] スコアの解釈規則。</summary>
    public required ScoreSemantics Semantics { get; init; }
    /// <summary>[EN] Items in best-first order. [JA] 良い順に並べた結果。</summary>
    public required IReadOnlyList<ScoredItem> Items { get; init; }
}
