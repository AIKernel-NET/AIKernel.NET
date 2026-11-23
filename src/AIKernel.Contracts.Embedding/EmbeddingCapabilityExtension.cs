namespace AIKernel.Dtos.Providers.Embedding;

/// <summary>[EN] Embedding-specific model and output capabilities. [JA] 埋め込み固有のモデル・出力機能。</summary>
public sealed record EmbeddingCapabilityExtension : ProviderCapabilityExtension
{
    /// <inheritdoc />
    public override ProviderKind Kind => ProviderKind.Embedding;

    /// <inheritdoc />
    public override IReadOnlyList<string> Features
    {
        get
        {
            var features = new List<string>();
            if (SupportedOutputKinds.HasFlag(EmbeddingOutputKind.Dense)) features.Add("embedding.dense");
            if (SupportedOutputKinds.HasFlag(EmbeddingOutputKind.Sparse)) features.Add("embedding.sparse");
            if (SupportsMatryoshka) features.Add("embedding.mrl");
            if (SupportsNormalizeOption) features.Add("embedding.normalize_option");
            if (MultimodalCombinableModalities.Count > 0) features.Add("embedding.multimodal");
            return features.AsReadOnly();
        }
    }

    /// <summary>[EN] Supported outputs. [JA] 対応する出力形式。</summary>
    public required EmbeddingOutputKind SupportedOutputKinds { get; init; }
    /// <summary>[EN] Default outputs. [JA] 既定の出力形式。</summary>
    public required EmbeddingOutputKind DefaultOutputKinds { get; init; }
    /// <summary>[EN] Full dense dimension. [JA] 密ベクトルの全次元数。</summary>
    public int? DefaultDimensions { get; init; }
    /// <summary>[EN] Whether truncation is supported by the model. [JA] モデルが次元切り詰めに対応するか。</summary>
    public required bool SupportsMatryoshka { get; init; }
    /// <summary>[EN] Discrete supported MRL dimensions. [JA] MRL対応の離散的な次元数。</summary>
    public IReadOnlyList<int> MatryoshkaDimensions { get; init; } = [];
    /// <summary>[EN] Lowest dimension in a supported continuous MRL range. [JA] 連続的なMRL対応範囲の最小次元数。</summary>
    public int? MinMatryoshkaDimension { get; init; }
    /// <summary>[EN] Whether normalization is selectable. [JA] 正規化の指定に対応するか。</summary>
    public required bool SupportsNormalizeOption { get; init; }
    /// <summary>[EN] Effective default normalization. [JA] 実際の既定の正規化設定。</summary>
    public required bool DefaultNormalize { get; init; }
    /// <summary>[EN] Sparse vocabulary dimension, when supported. [JA] 疎ベクトル対応時の語彙次元数。</summary>
    public int? SparseDimension { get; init; }
    /// <summary>[EN] Modalities allowed in a combined input. [JA] 組み合わせ可能なモダリティ。</summary>
    public IReadOnlyList<ProviderModality> MultimodalCombinableModalities { get; init; } = [];
    /// <summary>[EN] Supported media types per modality. [JA] モダリティ別に対応するメディアタイプ。</summary>
    public IReadOnlyDictionary<ProviderModality, IReadOnlyList<string>> AcceptedMediaTypes { get; init; } =
        new System.Collections.ObjectModel.ReadOnlyDictionary<ProviderModality, IReadOnlyList<string>>(
            new Dictionary<ProviderModality, IReadOnlyList<string>>());
    /// <summary>[EN] Supported retrieval purposes. [JA] 対応する検索用途。</summary>
    public IReadOnlyList<EmbeddingPurpose> SupportedPurposes { get; init; } = [];
    /// <summary>[EN] Default retrieval purpose, if used. [JA] 用途を扱う場合の既定値。</summary>
    public EmbeddingPurpose? DefaultPurpose { get; init; }
}
