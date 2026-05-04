using AIKernel.Dtos;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 推論（Orchestration）契約を定義します。
/// 目的、制約、抽象構造を含む不変な入力フォーマットです。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IOrchestrationContract
{
    /// <summary>
    /// 推論に必要なコンテキストを取得します。
    /// 例・文体・RAG は含まれていません。
    /// </summary>
    OrchestrationContextDto GetContext();

    /// <summary>
    /// 推論のための目的を取得します。
    /// </summary>
    string GetPurpose();

    /// <summary>
    /// 推論に課される制約条件を取得します。
    /// </summary>
    IReadOnlyList<string> GetConstraints();

    /// <summary>
    /// 推論の抽象構造を取得します。
    /// </summary>
    string GetStructure();

    /// <summary>
    /// 推論パターンを取得します。
    /// </summary>
    string? GetReasoningPattern();

    /// <summary>
    /// このコントラクトが有効であることを確認します。
    /// Attention 汚染の検出も行います。
    /// </summary>
    ValidationResult Validate();

    /// <summary>
    /// Signal-to-Noise Ratio（SNR）を計算します。
    /// </summary>
    double CalculateSignalToNoiseRatio();
}

/// <summary>
/// OrchestrationContract の検証結果を表現します。
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// 検証が成功したかどうかを取得します。
    /// </summary>
    public bool IsValid { get; init; }

    /// <summary>
    /// 検出されたエラーメッセージを取得します。
    /// </summary>
    public List<string> Errors { get; init; } = new();

    /// <summary>
    /// 警告メッセージを取得します。
    /// </summary>
    public List<string> Warnings { get; init; } = new();

    /// <summary>
    /// 検出された attention 汚染を取得します。
    /// </summary>
    public List<FailureMode> DetectedFailureModes { get; init; } = new();
}
