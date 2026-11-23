namespace AIKernel.Dtos.Providers.SpeechRecognition;

/// <summary>[EN] Encoded audio input for batch transcription. [JA] バッチ文字起こし用の符号化済み音声入力。</summary>
public abstract record AudioSource
{
    private protected AudioSource() { }

    /// <summary>[EN] Audio file in memory. [JA] メモリ上の音声ファイル。</summary>
    public sealed record Bytes(ReadOnlyMemory<byte> Data, string MediaType) : AudioSource;

    /// <summary>[EN] Reads from the caller-owned stream's current position. [JA] 呼び出し元が所有するストリームの現在位置から読み取ります。</summary>
    public sealed record FromStream(Stream Content, string MediaType) : AudioSource;
}

/// <summary>[EN] Controls which timestamps are returned. [JA] 返すタイムスタンプの粒度。</summary>
public enum TimestampGranularity
{
    /// <summary>[EN] Full text only. [JA] 全文のみ。</summary>
    None,
    /// <summary>[EN] Time-aligned segments. [JA] 時刻付きの区間。</summary>
    Segment,
    /// <summary>[EN] Word or token alignment when advertised. [JA] 申告時のみ単語またはトークンの時刻。</summary>
    Word
}

/// <summary>[EN] Voice activity detection mode. [JA] 発話区間検出の使い方。</summary>
public enum VadMode
{
    /// <summary>[EN] Process the input as a whole. [JA] 入力全体を処理。</summary>
    Off,
    /// <summary>[EN] Use the provider's detector. [JA] Provider側の発話区間検出を利用。</summary>
    BuiltIn,
    /// <summary>[EN] Use caller-supplied speech regions. [JA] 呼び出し元が指定する発話区間を利用。</summary>
    External
}

/// <summary>[EN] A speech interval relative to the start of the input. [JA] 入力先頭からの発話区間。</summary>
public sealed record SpeechRegion(TimeSpan Start, TimeSpan End);

/// <summary>[EN] Request to transcribe one audio input. [JA] 音声入力1件の文字起こし要求。</summary>
public sealed record TranscriptionRequest
{
    /// <summary>[EN] Encoded input audio. [JA] 符号化済みの入力音声。</summary>
    public required AudioSource Audio { get; init; }
    /// <summary>[EN] Model ID or null for the default. [JA] モデルID。未指定時は既定。</summary>
    public string? ModelId { get; init; }
    /// <summary>[EN] BCP 47 language tag or null for automatic detection. [JA] BCP 47の言語タグ。未指定時は自動判定。</summary>
    public string? Language { get; init; }
    /// <summary>[EN] Timestamp granularity, defaulting to Segment. [JA] タイムスタンプの粒度。既定はSegment。</summary>
    public TimestampGranularity? Timestamps { get; init; }
    /// <summary>[EN] Required VAD mode or null for the default. [JA] VAD方式。未指定時は既定。</summary>
    public VadMode? Vad { get; init; }
    /// <summary>[EN] Input intervals for External VAD. [JA] 外部VADで使う入力区間。</summary>
    public IReadOnlyList<SpeechRegion>? SpeechRegions { get; init; }
}

/// <summary>[EN] Time-aligned text when word alignment is requested and supported. [JA] 対応時に指定できる単語とその時刻。</summary>
public sealed record TranscriptionWord
{
    /// <summary>[EN] Recognized token or word. [JA] 認識した語またはトークン。</summary>
    public required string Text { get; init; }
    /// <summary>[EN] Start relative to the input. [JA] 入力先頭からの開始時刻。</summary>
    public required TimeSpan Start { get; init; }
    /// <summary>[EN] End relative to the input. [JA] 入力先頭からの終了時刻。</summary>
    public required TimeSpan End { get; init; }
}

/// <summary>[EN] A segment with timing relative to the original audio start. [JA] 入力音声先頭からの時刻を持つ認識区間。</summary>
public sealed record TranscriptionSegment
{
    /// <summary>[EN] Zero-based sequence number. [JA] 0起点の連番。</summary>
    public required int Index { get; init; }
    /// <summary>[EN] Start of the segment. [JA] 区間の開始時刻。</summary>
    public required TimeSpan Start { get; init; }
    /// <summary>[EN] End of the segment. [JA] 区間の終了時刻。</summary>
    public required TimeSpan End { get; init; }
    /// <summary>[EN] Recognized text for this segment. [JA] この区間の認識結果。</summary>
    public required string Text { get; init; }
    /// <summary>[EN] Alignment details for Word granularity. [JA] Word粒度を選択した場合の語ごとの時刻。</summary>
    public IReadOnlyList<TranscriptionWord>? Words { get; init; }
}

/// <summary>[EN] Transcribed text and timing for one input. [JA] 音声入力1件の認識結果と時刻。</summary>
public sealed record TranscriptionResult
{
    /// <summary>[EN] Executing provider ID. [JA] 実行したProviderのID。</summary>
    public required string ProviderId { get; init; }
    /// <summary>[EN] Resolved model ID. [JA] 使ったモデルID。</summary>
    public required string ModelId { get; init; }
    /// <summary>[EN] Resolved language, if known. [JA] 指定または検出された言語。判定できない場合はnull。</summary>
    public string? Language { get; init; }
    /// <summary>[EN] Original input duration. [JA] 元の入力音声の長さ。</summary>
    public required TimeSpan Duration { get; init; }
    /// <summary>[EN] Full recognized text. [JA] 認識した全文。</summary>
    public required string Text { get; init; }
    /// <summary>[EN] Time-ordered segments, empty for None granularity or silence. [JA] 時刻順の区間。粒度がNoneの場合や無音時は空。</summary>
    public required IReadOnlyList<TranscriptionSegment> Segments { get; init; }
}

/// <summary>[EN] Speech recognition error codes shared between hosts and providers. [JA] ホストとProviderで共有する音声認識エラーコード。</summary>
public static class SpeechRecognitionErrorCodes
{
    /// <summary>[EN] Invalid or damaged encoded audio. [JA] 壊れた音声または不正な音声データ。</summary>
    public const string DecodeFailed = "asr.decode_failed";
    /// <summary>[EN] Language not supported by the provider. [JA] Providerが未対応の言語。</summary>
    public const string UnsupportedLanguage = "asr.unsupported_language";
}
