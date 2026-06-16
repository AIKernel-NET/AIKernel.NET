namespace AIKernel.Abstractions.Material;

/// <summary>
/// EN: UC-21（マテリアル検疫とポリシー実行）に基づき、素材の事前スキャンと信頼評価を行う契約を定義します。
/// EN: Documentation for public API. JA: IMaterialScanner の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IMaterialScanner']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Material.IMaterialScanner']" />
public interface IMaterialScanner
{
    /// <summary>
    /// EN: 生素材をスキャンし、検出事項を返します。
    /// EN: Documentation for public API. JA: ScanAsync 操作を実行します。
    /// </summary>
    /// <param name="rawMaterial">EN: Documentation for public API. JA: スキャン対象の生素材 rawMaterial パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 検出事項の一覧 結果を返します。</returns>
    ValueTask<IReadOnlyList<string>> ScanAsync(
        string rawMaterial,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: 生素材の信頼コンテキストを評価します。
    /// EN: Documentation for public API. JA: EvaluateTrustAsync 操作を実行します。
    /// </summary>
    /// <param name="rawMaterial">EN: Documentation for public API. JA: 評価対象の生素材 rawMaterial パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 信頼評価結果 結果を返します。</returns>
    ValueTask<TrustContext> EvaluateTrustAsync(
        string rawMaterial,
        CancellationToken cancellationToken = default);
}


