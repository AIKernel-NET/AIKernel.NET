namespace AIKernel.Dtos.Tokenization;

public sealed class Token
{
    public required string Value { get; init; }
    public required int TokenId { get; init; }
    public int StartPosition { get; init; }
    public int EndPosition { get; init; }
    public string? TokenType { get; init; }
}

