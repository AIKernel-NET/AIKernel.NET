namespace AIKernel.Dtos.Context;

using AIKernel.Enums;

/// <summary>
/// ExpressionFragment の契約を定義します。
/// </summary>
public sealed class ExpressionFragment : ContextFragment
{
    public IReadOnlyList<string> Examples { get; init; } = Array.Empty<string>();
    public string StyleHints { get; init; } = string.Empty;
    public string Tone { get; init; } = string.Empty;
    public string LanguageTag { get; init; } = "ja-JP";

    public ExpressionFragment()
    {
        Category = ContextCategory.Expression;
    }
}



