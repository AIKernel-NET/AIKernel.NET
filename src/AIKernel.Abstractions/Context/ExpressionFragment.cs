namespace AIKernel.Abstractions.Context;

/// <summary>
/// Expression コンテキスト専用のフラグメント。
/// 推論後の整形・表現に必要な情報を保持します。
/// </summary>
public sealed class ExpressionFragment : ContextFragment
{
    /// <summary>
    /// 表現例の一覧を取得または設定します。
    /// </summary>
    public IReadOnlyList<string> Examples { get; init; } = Array.Empty<string>();

    /// <summary>
    /// スタイルのヒントを取得または設定します。
    /// </summary>
    public string StyleHints { get; init; } = string.Empty;

    /// <summary>
    /// トーン（語調）を取得または設定します。
    /// </summary>
    public string Tone { get; init; } = string.Empty;

    /// <summary>
    /// 言語タグ（例: "ja-JP", "en-US"）を取得または設定します。
    /// </summary>
    public string LanguageTag { get; init; } = "ja-JP";
}
