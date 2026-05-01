using AIKernel.Contracts;
using AIKernel.Dtos;
using AIKernel.Enums;

namespace AIKernel.Abstractions;

/// <summary>
/// AIKernel のメインカーネルインターフェースを定義します。
/// Syscall レベルの、OS 的な中核機構です。
/// 
/// IKernel は以下を保証します：
/// - 情報カテゴリ分離
/// - コンテキスト隔離
/// - Contract-driven 実行
/// - Attention 汚染防止
/// </summary>
public interface IKernel
{
    /// <summary>
    /// カーネルのバージョンを取得します。
    /// </summary>
    string GetVersion();

    /// <summary>
    /// 統合コンテキスト契約を処理します。
    /// </summary>
    /// <param name="contract">処理する統合コンテキスト契約</param>
    /// <returns>処理結果</returns>
    Task<KernelExecutionResult> ExecuteAsync(IUnifiedContextContract contract);

    /// <summary>
    /// Orchestration Context を検証し、Attention 汚染を検出します。
    /// </summary>
    Task<AttentionAnalysis> AnalyzeAttentionAsync(IOrchestrationContract contract);

    /// <summary>
    /// Material Context を正規化・構造化します。
    /// </summary>
    Task<MaterialContextDto> PreprocessMaterialAsync(IMaterialContract material);

    /// <summary>
    /// Expression Context を推論後に適用可能な状態にします。
    /// </summary>
    Task<ExpressionContextDto> PrepareExpressionAsync(IExpressionContract expression);

    /// <summary>
    /// 複数の Provider を管理・ルーティングします。
    /// </summary>
    IProviderRouter GetProviderRouter();

    /// <summary>
    /// セキュリティポリシーを管理します。
    /// </summary>
    IGuard GetGuard();

    /// <summary>
    /// ポリシー決定を行います。
    /// </summary>
    IPdp GetPdp();
}

/// <summary>
/// Kernel 実行結果を表現します。
/// </summary>
public sealed class KernelExecutionResult
{
    /// <summary>
    /// 実行が成功したかどうかを取得します。
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// 実行結果のデータを取得します。
    /// </summary>
    public object? Data { get; init; }

    /// <summary>
    /// エラーメッセージを取得します。
    /// </summary>
    public string? Error { get; init; }

    /// <summary>
    /// 検出された failure modes を取得します。
    /// </summary>
    public List<FailureMode> FailureModes { get; init; } = new();

    /// <summary>
    /// 実行時間を取得します。
    /// </summary>
    public TimeSpan ExecutionTime { get; init; }
}

/// <summary>
/// Attention 分析結果を表現します。
/// </summary>
public sealed class AttentionAnalysis
{
    /// <summary>
    /// SNR（Signal-to-Noise Ratio）を取得します。
    /// </summary>
    public double SignalToNoiseRatio { get; init; }

    /// <summary>
    /// 検出された attention 汚染を取得します。
    /// </summary>
    public List<FailureMode> DetectedPollution { get; init; } = new();

    /// <summary>
    /// 推奨される改善方法を取得します。
    /// </summary>
    public List<string> Recommendations { get; init; } = new();

    /// <summary>
    /// リスクレベルを取得します（Low / Medium / High）。
    /// </summary>
    public string RiskLevel { get; init; } = "Low";
}
