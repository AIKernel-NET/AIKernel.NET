namespace AIKernel.Dtos.Tokenization;

/// <summary>
/// TokenizerStatistics の契約を定義します。
/// </summary>
public sealed class TokenizerStatistics
{
    public required int VocabularySize { get; init; }
    public IReadOnlyList<string> SupportedModels { get; init; } = Array.Empty<string>();
    public string? Version { get; init; }
    public double AverageTokenLength { get; init; }
    public int MaxTokenLength { get; init; }
}




