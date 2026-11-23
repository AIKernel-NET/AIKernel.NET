namespace AIKernel.Dtos.Providers.SpeechRecognition;

/// <summary>[EN] PCM format for streaming-capable providers. [JA] ストリーミング対応Provider用のPCM形式。</summary>
public sealed record PcmFormat
{
    /// <summary>[EN] Samples per second per channel. [JA] チャネルごとのサンプル周波数。</summary>
    public required int SampleRate { get; init; }
    /// <summary>[EN] Channel count. [JA] チャネル数。</summary>
    public required int Channels { get; init; }
    /// <summary>[EN] Sample encoding, such as s16le. [JA] s16leなどのサンプル形式。</summary>
    public required string SampleFormat { get; init; }
}

/// <summary>[EN] Speech recognition capabilities for one provider. [JA] 音声認識Providerが申告する機能。</summary>
public sealed record SpeechRecognitionCapabilityExtension : ProviderCapabilityExtension
{
    /// <inheritdoc />
    public override ProviderKind Kind => ProviderKind.SpeechRecognition;

    /// <inheritdoc />
    public override IReadOnlyList<string> Features
    {
        get
        {
            var features = new List<string>();
            if (AcceptedPcmFormats.Count > 0) features.Add("asr.streaming");
            if (TimestampGranularities.Contains(TimestampGranularity.Word)) features.Add("asr.timestamp.word");
            if (SupportsLanguageDetection) features.Add("asr.language_detection");
            if (VadModes.Contains(VadMode.BuiltIn)) features.Add("asr.vad.builtin");
            if (VadModes.Contains(VadMode.External)) features.Add("asr.vad.external");
            return features.AsReadOnly();
        }
    }

    /// <summary>[EN] Supported BCP 47 language tags. [JA] サポートするBCP 47言語タグ。</summary>
    public required IReadOnlyList<string> Languages { get; init; }
    /// <summary>[EN] Whether the model can detect a language. [JA] 言語自動判定に対応するか。</summary>
    public required bool SupportsLanguageDetection { get; init; }
    /// <summary>[EN] Supported timestamp options. [JA] 対応するタイムスタンプの粒度。</summary>
    public required IReadOnlyList<TimestampGranularity> TimestampGranularities { get; init; }
    /// <summary>[EN] Accepted media types for encoded audio. [JA] バッチ入力で受け付けるメディアタイプ。</summary>
    public required IReadOnlyList<string> AcceptedMediaTypes { get; init; }
    /// <summary>[EN] Streaming input formats, when supported. [JA] ストリーミング対応時のPCM形式。</summary>
    public IReadOnlyList<PcmFormat> AcceptedPcmFormats { get; init; } = [];
    /// <summary>[EN] Supported voice activity detection options. [JA] 対応するVADモード。</summary>
    public required IReadOnlyList<VadMode> VadModes { get; init; }
    /// <summary>[EN] Whether streaming supports partial events. [JA] ストリーミングの途中結果に対応するか。</summary>
    public bool SupportsPartials { get; init; }
    /// <summary>[EN] Optional maximum duration for one batch input. [JA] バッチ入力1件の最大音声長。</summary>
    public TimeSpan? MaxAudioDuration { get; init; }
}
