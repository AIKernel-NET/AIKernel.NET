using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// 統合されたコンテキストデータを表現する DTO です。
/// OrchestrationContext、ExpressionContext、MaterialContext を管理します。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public sealed class UnifiedContextDto
{
    /// <summary>
    /// コンテキストの一意識別子を取得または設定します。
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// OrchestrationContext を取得または設定します。
    /// </summary>
    public required OrchestrationContextDto Orchestration { get; init; }

    /// <summary>
    /// ExpressionContext を取得または設定します。
    /// </summary>
    public ExpressionContextDto? Expression { get; init; }

    /// <summary>
    /// MaterialContext を取得または設定します。
    /// </summary>
    public MaterialContextDto? Material { get; init; }

    /// <summary>
    /// SNR（Signal-to-Noise Ratio）を取得または設定します。
    /// </summary>
    public double SignalToNoiseRatio { get; init; } = 1.0;

    /// <summary>
    /// 発生した failure modes を取得または設定します。
    /// </summary>
    public List<FailureMode> DetectedFailureModes { get; init; } = new();

    /// <summary>
    /// 作成日時を取得または設定します。
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}


