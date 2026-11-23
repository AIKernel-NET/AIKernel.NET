using AIKernel.Dtos.Providers.SpeechRecognition;

namespace AIKernel.Abstractions.Providers;

/// <summary>[EN] Batch audio transcription capability. [JA] 音声のバッチ文字起こし機能。</summary>
public interface ISpeechTranscriptionProvider
{
    /// <summary>[EN] Transcribes one audio input. [JA] 音声入力1件を書き起こします。</summary>
    Task<TranscriptionResult> TranscribeAsync(TranscriptionRequest request, CancellationToken cancellationToken = default);
}

/// <summary>[EN] Batch transcription with provider lifecycle and placement metadata. [JA] ライフサイクルと配置情報を含む文字起こし契約。</summary>
public interface ISpeechRecognitionProvider : IProvider, ISpeechTranscriptionProvider, IProviderCapabilityDescriptorSource
{
}
