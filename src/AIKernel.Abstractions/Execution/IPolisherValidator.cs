namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// Polish フェーズの意味改変検出・検証の契約。
/// EN: EPS-005（ハッシュ完全性）と EPS-F005（Logic Divergence Check）の実装基盤。
/// EN: Documentation for public API. JA: IPolisherValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPolisherValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPolisherValidator']" />
public interface IPolisherValidator
{
    /// <summary>
    /// Polish フェーズが Logic から逸脱しないことを検証します。
    /// EPS-005: フェーズ受け渡しデータのハッシュで完全性検証。
    /// EN: EPS-F005: Logic Divergence Check - Structure の実行プランと論理乖離がないことを確認。
    /// EN: Documentation for public API. JA: ValidateLogicPreservationAsync 操作を実行します。
    /// </summary>
    /// <param name="originalLogic">EN: Documentation for public API. JA: Structure フェーズの出力（RawLogic） originalLogic パラメーターです。</param>
    /// <param name="polishedOutput">EN: Documentation for public API. JA: Polish フェーズの出力（最終テキスト） polishedOutput パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 検証結果（論理保全性が確認されたか） 結果を返します。</returns>
    Task<PolisherValidationResult> ValidateLogicPreservationAsync(
        RawLogic originalLogic,
        string polishedOutput,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 論理改変の詳細を分析します。
    /// EN: 失敗時の監査に用います。
    /// EN: Documentation for public API. JA: AnalyzeDivergenceAsync 操作を実行します。
    /// </summary>
    /// <param name="originalLogic">EN: Documentation for public API. JA: Structure 出力 originalLogic パラメーターです。</param>
    /// <param name="polishedOutput">EN: Documentation for public API. JA: Polish 出力 polishedOutput パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 改変の詳細分析 結果を返します。</returns>
    Task<LogicDivergenceAnalysis> AnalyzeDivergenceAsync(
        RawLogic originalLogic,
        string polishedOutput,
        CancellationToken cancellationToken = default);
}


