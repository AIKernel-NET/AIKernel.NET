namespace AIKernel.Abstractions.Material;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づき、素材の事前スキャンと信頼評価を行う契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IMaterialScanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IMaterialScanner']" />
public interface IMaterialScanner
{
    /// <summary>
    /// 生素材をスキャンし、検出事項を返します。
    /// </summary>
    /// <param name="rawMaterial">スキャン対象の生素材</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検出事項の一覧</returns>
    ValueTask<IReadOnlyList<string>> ScanAsync(
        string rawMaterial,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 生素材の信頼コンテキストを評価します。
    /// </summary>
    /// <param name="rawMaterial">評価対象の生素材</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>信頼評価結果</returns>
    ValueTask<TrustContext> EvaluateTrustAsync(
        string rawMaterial,
        CancellationToken cancellationToken = default);
}


