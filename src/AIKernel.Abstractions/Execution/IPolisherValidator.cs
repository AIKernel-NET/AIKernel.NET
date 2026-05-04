namespace AIKernel.Abstractions.Execution;

/// <summary>
/// Polish フェーズの意味改変検出・検証の契約。
/// EPS-005（ハッシュ完全性）と EPS-F005（Logic Divergence Check）の実装基盤。
/// </summary>
public interface IPolisherValidator
{
    /// <summary>
    /// Polish フェーズが Logic から逸脱しないことを検証します。
    /// EPS-005: フェーズ受け渡しデータのハッシュで完全性検証。
    /// EPS-F005: Logic Divergence Check - Structure の実行プランと論理乖離がないことを確認。
    /// </summary>
    /// <param name="originalLogic">Structure フェーズの出力（RawLogic）</param>
    /// <param name="polishedOutput">Polish フェーズの出力（最終テキスト）</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検証結果（論理保全性が確認されたか）</returns>
    Task<PolisherValidationResult> ValidateLogicPreservationAsync(
        RawLogic originalLogic,
        string polishedOutput,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 論理改変の詳細を分析します。
    /// 失敗時の監査に用います。
    /// </summary>
    /// <param name="originalLogic">Structure 出力</param>
    /// <param name="polishedOutput">Polish 出力</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>改変の詳細分析</returns>
    Task<LogicDivergenceAnalysis> AnalyzeDivergenceAsync(
        RawLogic originalLogic,
        string polishedOutput,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Polish バリデーション結果。
/// </summary>
public sealed record PolisherValidationResult
{
    /// <summary>
    /// 検証が成功したかどうか（論理が保全されているか）。
    /// </summary>
    public required bool IsValid { get; init; }

    /// <summary>
    /// 検証メッセージ。
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// 検出された違反項目。
    /// </summary>
    public IReadOnlyList<string> Violations { get; init; } = new List<string>();

    /// <summary>
    /// 論理の信頼スコア（0.0-1.0）。
    /// 完全に保全: 1.0, 軽微な表現改変: 0.8-0.99, 論理逸脱: < 0.5
    /// </summary>
    public double LogicIntegrityScore { get; init; }
}

/// <summary>
/// Logic Divergence 分析（EPS-F005）。
/// </summary>
public sealed record LogicDivergenceAnalysis
{
    /// <summary>
    /// 論理乖離が検出されたか。
    /// </summary>
    public required bool DivergenceDetected { get; init; }

    /// <summary>
    /// 乖離の種類（"semantic_change", "fact_alteration", "conclusion_shift" など）。
    /// </summary>
    public required string DivergenceType { get; init; }

    /// <summary>
    /// 乖離の詳細な説明。
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// 乖離の重要度（"critical", "high", "medium", "low"）。
    /// </summary>
    public required string Severity { get; init; }

    /// <summary>
    /// 改変されたテキスト片（元のロジックと異なる部分）。
    /// </summary>
    public IReadOnlyList<string> AlteredSegments { get; init; } = new List<string>();
}
