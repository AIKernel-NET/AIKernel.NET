namespace AIKernel.Dtos.Providers.Embedding;

/// <summary>[EN] Discriminated embedding input. [JA] 判別可能な埋め込み入力。</summary>
public abstract record EmbeddingInput
{
    private EmbeddingInput() { }

    /// <summary>[EN] Text to embed. [JA] 埋め込むテキスト。</summary>
    public sealed record Text(string Value) : EmbeddingInput;

    /// <summary>[EN] Image bytes and media type. [JA] 画像のバイト列とメディアタイプ。</summary>
    public sealed record Image(ReadOnlyMemory<byte> Data, string MediaType) : EmbeddingInput;

    /// <summary>[EN] Audio bytes and media type. [JA] 音声のバイト列とメディアタイプ。</summary>
    public sealed record Audio(ReadOnlyMemory<byte> Data, string MediaType) : EmbeddingInput;

    /// <summary>[EN] Flat list of parts forming one input. [JA] 1件の入力を構成する非入れ子のパーツ。</summary>
    public sealed record Multimodal(IReadOnlyList<EmbeddingInput> Parts) : EmbeddingInput;
}
