using AIKernel.Abstractions.Execution;

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
    Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract);

    /// <summary>
    /// Orchestration Context を検証し、Attention 汚染を検出します。
    /// </summary>
    Task<AttentionAnalysis> AnalyzeAttentionAsync(OrchestrationContextDto contract);

    /// <summary>
    /// Material Context を正規化・構造化します。
    /// </summary>
    Task<MaterialContextDto> PreprocessMaterialAsync(MaterialContextDto material);

    /// <summary>
    /// Expression Context を推論後に適用可能な状態にします。
    /// </summary>
    Task<ExpressionContextDto> PrepareExpressionAsync(ExpressionContextDto expression);

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
