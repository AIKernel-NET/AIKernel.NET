namespace AIKernel.Abstractions.Material;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づき、素材の事前スキャンと信頼評価を行う契約を定義します。
/// </summary>
public interface IMaterialScanner
{
    /// <summary>
    /// 生素材をスキャンし、検出事項を返します。
    /// </summary>
    /// <param name="rawMaterial">スキャン対象の生素材</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検出事項の一覧</returns>
    /// <exception cref="ArgumentException">入力素材が空の場合にスローされます。</exception>
    /// <exception cref="UnauthorizedAccessException">危険な素材が検出された場合にスローされます。</exception>
    ValueTask<IReadOnlyList<string>> ScanAsync(
        string rawMaterial,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 生素材の信頼コンテキストを評価します。
    /// </summary>
    /// <param name="rawMaterial">評価対象の生素材</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>信頼評価結果</returns>
    /// <exception cref="InvalidOperationException">信頼評価に必要な検証基盤が利用できない場合にスローされます。</exception>
    ValueTask<TrustContext> EvaluateTrustAsync(
        string rawMaterial,
        CancellationToken cancellationToken = default);
}


