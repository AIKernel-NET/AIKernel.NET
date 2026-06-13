namespace AIKernel.Abstractions.Execution;

/// <summary>
/// UC-02/UC-04/UC-09/UC-20/UC-22 に基づく契約です。
/// Polish フェーズの意味改変検出・検証の契約。
/// EPS-005（ハッシュ完全性）と EPS-F005（Logic Divergence Check）の実装基盤。
/// JA: IPolisherValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPolisherValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IPolisherValidator']" />
public interface IPolisherValidator
{
    /// <summary>
    /// Polish フェーズが Logic から逸脱しないことを検証します。
    /// EPS-005: フェーズ受け渡しデータのハッシュで完全性検証。
    /// EPS-F005: Logic Divergence Check - Structure の実行プランと論理乖離がないことを確認。
    /// JA: ValidateLogicPreservationAsync 操作を実行します。
    /// </summary>
    /// <param name="originalLogic">Structure フェーズの出力（RawLogic） JA: originalLogic パラメーターです。</param>
    /// <param name="polishedOutput">Polish フェーズの出力（最終テキスト） JA: polishedOutput パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>検証結果（論理保全性が確認されたか） JA: 結果を返します。</returns>
    Task<PolisherValidationResult> ValidateLogicPreservationAsync(
        RawLogic originalLogic,
        string polishedOutput,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 論理改変の詳細を分析します。
    /// 失敗時の監査に用います。
    /// JA: AnalyzeDivergenceAsync 操作を実行します。
    /// </summary>
    /// <param name="originalLogic">Structure 出力 JA: originalLogic パラメーターです。</param>
    /// <param name="polishedOutput">Polish 出力 JA: polishedOutput パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>改変の詳細分析 JA: 結果を返します。</returns>
    Task<LogicDivergenceAnalysis> AnalyzeDivergenceAsync(
        RawLogic originalLogic,
        string polishedOutput,
        CancellationToken cancellationToken = default);
}


