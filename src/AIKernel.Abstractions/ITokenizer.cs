namespace AIKernel.Abstractions;

/// <summary>
/// トークナイザーインターフェースを定義します。
/// テキストトークン化と統計情報の管理を行います。
/// </summary>
public interface ITokenizer
{
    /// <summary>
    /// トークナイザーのプロファイルIDを取得します。
    /// </summary>
    string TokenizerProfileId { get; }

    /// <summary>
    /// トークナイザーの名前を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// テキストをトークン化します。
    /// </summary>
    /// <param name="text">トークン化するテキスト</param>
    /// <returns>トークンリスト</returns>
    IReadOnlyList<Token> Tokenize(string text);

    /// <summary>
    /// テキストのトークン数を計算します。
    /// </summary>
    /// <param name="text">テキスト</param>
    /// <returns>トークン数</returns>
    int CountTokens(string text);

    /// <summary>
    /// トークンをテキストにデコードします。
    /// </summary>
    /// <param name="tokens">トークンリスト</param>
    /// <returns>デコードされたテキスト</returns>
    string Decode(IReadOnlyList<Token> tokens);

    /// <summary>
    /// トークナイザーの統計情報を取得します。
    /// </summary>
    /// <returns>統計情報</returns>
    TokenizerStatistics GetStatistics();

    /// <summary>
    /// トークナイザーが特定のモデルをサポートしているかどうかを確認します。
    /// </summary>
    /// <param name="modelName">モデル名</param>
    /// <returns>サポートしている場合は true</returns>
    bool SupportsModel(string modelName);
}

/// <summary>
/// トークを表現します。
/// </summary>
public sealed class Token
{
    /// <summary>
    /// トークンの値を取得または設定します。
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// トークンIDを取得または設定します。
    /// </summary>
    public required int TokenId { get; init; }

    /// <summary>
    /// トークンの開始位置を取得または設定します。
    /// </summary>
    public int StartPosition { get; init; }

    /// <summary>
    /// トークンの終了位置を取得または設定します。
    /// </summary>
    public int EndPosition { get; init; }

    /// <summary>
    /// トークンの種類を取得または設定します。
    /// </summary>
    public string? TokenType { get; init; }
}

/// <summary>
/// トークナイザーの統計情報を表現します。
/// </summary>
public sealed class TokenizerStatistics
{
    /// <summary>
    /// 語彙サイズを取得または設定します。
    /// </summary>
    public required int VocabularySize { get; init; }

    /// <summary>
    /// サポートされているモデル一覧を取得または設定します。
    /// </summary>
    public IReadOnlyList<string> SupportedModels { get; init; } = Array.Empty<string>();

    /// <summary>
    /// トークナイザーのバージョンを取得または設定します。
    /// </summary>
    public string? Version { get; init; }

    /// <summary>
    /// 平均トークン長を取得または設定します。
    /// </summary>
    public double AverageTokenLength { get; init; }

    /// <summary>
    /// 最大トークン長を取得または設定します。
    /// </summary>
    public int MaxTokenLength { get; init; }
}
