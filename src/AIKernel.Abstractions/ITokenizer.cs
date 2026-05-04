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
