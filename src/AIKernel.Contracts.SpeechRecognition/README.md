# AIKernel speech recognition contracts

`ISpeechTranscriptionProvider` accepts one encoded audio input, either bytes or a caller-owned stream. It returns a `TranscriptionResult` with the original duration, resolved language, full text and, when requested, ordered segments relative to the start of the audio.

`ISpeechRecognitionProvider` adds lifecycle and placement metadata. Use the capability descriptor to discover the supported model, languages, formats, timestamp options and input limits. The caller retains ownership of any stream it passes to the provider.
