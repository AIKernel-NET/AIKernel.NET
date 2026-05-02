namespace AIKernel.Abstractions;

using AIKernel.Abstractions.Models;

/// <summary>
/// トークナイザーインターフェースを定義します。
/// テキストトークン化と統計情報の管理を行います。
/// NPU環境での物理基数（パディング）対応に対応しています。
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

    /// <summary>
    /// 論理的なトークン数を物理基数に変換します。
    /// NPU最適化のためのパディングを考慮します。
    /// </summary>
    /// <param name="logicalTokenCount">論理的なトークン数</param>
    /// <param name="deviceType">デバイスタイプ（"NPU", "GPU", "CPU"等）</param>
    /// <returns>NPU最適化後の物理基数</returns>
    int GetPhysicalCardinality(int logicalTokenCount, string deviceType);

    /// <summary>
    /// 指定された物理基数でのパディング情報を取得します。
    /// </summary>
    /// <param name="logicalTokenCount">論理的なトークン数</param>
    /// <param name="physicalCardinality">物理基数</param>
    /// <returns>パディング情報</returns>
    PaddingInfo GetPaddingInfo(int logicalTokenCount, int physicalCardinality);
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

/// <summary>
/// パディング情報を表現するクラスです。
/// NPU最適化に必要な物理基数への調整情報を提供します。
/// </summary>
public sealed class PaddingInfo
{
    /// <summary>
    /// 論理的なトークン数を取得します。
    /// </summary>
    public required int LogicalTokenCount { get; init; }

    /// <summary>
    /// 物理基数（パディング後）を取得します。
    /// </summary>
    public required int PhysicalCardinality { get; init; }

    /// <summary>
    /// パディング量（追加トークン数）を取得します。
    /// </summary>
    public int PaddingAmount => PhysicalCardinality - LogicalTokenCount;

    /// <summary>
    /// パディング率（%）を取得します。
    /// </summary>
    public float PaddingPercentage => LogicalTokenCount > 0 
        ? (PaddingAmount * 100.0f) / LogicalTokenCount 
        : 0.0f;

    /// <summary>
    /// パディング方式を取得します。
    /// 例："AttentionMask", "ZeroPadding", "ReflectPadding"
    /// </summary>
    public string? PaddingMethod { get; init; }

    /// <summary>
    /// パディング前後のメモリ使用差分（バイト）を取得します。
    /// </summary>
    public long MemoryDifferenceBytes { get; init; }

    /// <summary>
    /// パディングが推奨される理由を取得します。
    /// </summary>
    public string? Rationale { get; init; }
}
