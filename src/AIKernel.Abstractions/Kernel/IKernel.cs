using AIKernel.Abstractions.Execution;

namespace AIKernel.Abstractions.Kernel;

/// <summary>
/// UC-09 に基づく契約です。
/// カーネルのバージョン情報を公開する capability interface です。
/// </summary>
public interface IKernelVersionProvider
{
    /// <summary>
    /// カーネルのバージョンを取得します。
    /// </summary>
    string GetVersion();
}

/// <summary>
/// UC-09 に基づく契約です。
/// 統合コンテキスト契約を実行する capability interface です。
/// </summary>
public interface IKernelExecutor
{
    /// <summary>
    /// 統合コンテキスト契約を処理します。
    /// </summary>
    /// <param name="contract">処理する統合コンテキスト契約</param>
    /// <returns>処理結果</returns>
    Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract);
}

/// <summary>
/// UC-09 に基づく契約です。
/// Attention 汚染を解析する capability interface です。
/// </summary>
public interface IKernelAttentionAnalyzer
{
    /// <summary>
    /// Orchestration Context を検証し、Attention 汚染を検出します。
    /// </summary>
    Task<AttentionAnalysis> AnalyzeAttentionAsync(OrchestrationContextDto contract);
}

/// <summary>
/// UC-09 に基づく契約です。
/// Material Context を正規化・構造化する capability interface です。
/// </summary>
public interface IKernelMaterialPreprocessor
{
    /// <summary>
    /// Material Context を正規化・構造化します。
    /// </summary>
    Task<MaterialContextDto> PreprocessMaterialAsync(MaterialContextDto material);
}

/// <summary>
/// UC-09 に基づく契約です。
/// Expression Context を推論後に適用可能な状態にする capability interface です。
/// </summary>
public interface IKernelExpressionPreparer
{
    /// <summary>
    /// Expression Context を推論後に適用可能な状態にします。
    /// </summary>
    Task<ExpressionContextDto> PrepareExpressionAsync(ExpressionContextDto expression);
}

/// <summary>
/// UC-09 に基づく契約です。
/// Provider Router を公開する capability interface です。
/// </summary>
public interface IKernelProviderRouterAccessor
{
    /// <summary>
    /// 複数の Provider を管理・ルーティングします。
    /// </summary>
    IProviderRouter GetProviderRouter();
}

/// <summary>
/// UC-09 に基づく契約です。
/// Guard を公開する capability interface です。
/// </summary>
public interface IKernelGuardAccessor
{
    /// <summary>
    /// セキュリティポリシーを管理します。
    /// </summary>
    IGuard GetGuard();
}

/// <summary>
/// UC-09 に基づく契約です。
/// PDP を公開する capability interface です。
/// </summary>
public interface IKernelPdpAccessor
{
    /// <summary>
    /// ポリシー決定を行います。
    /// </summary>
    IPdp GetPdp();
}

/// <summary>
/// UC-09 に基づく契約です。
/// AIKernel のメインカーネルを定義する互換合成インターフェースです。
/// Syscall レベルの、OS 的な中核機構です。
/// 
/// IKernel は以下を保証します：
/// - 情報カテゴリ分離
/// - コンテキスト隔離
/// - Contract-driven 実行
/// - Attention 汚染防止
/// </summary>
public interface IKernel :
    IKernelVersionProvider,
    IKernelExecutor,
    IKernelAttentionAnalyzer,
    IKernelMaterialPreprocessor,
    IKernelExpressionPreparer,
    IKernelProviderRouterAccessor,
    IKernelGuardAccessor,
    IKernelPdpAccessor
{
}
