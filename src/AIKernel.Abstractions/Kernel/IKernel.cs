using AIKernel.Abstractions.Execution;

namespace AIKernel.Abstractions.Kernel;

/// <summary>
/// UC-09 に基づく契約です。
/// EN: カーネルのバージョン情報を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelVersionProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelVersionProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelVersionProvider']" />
public interface IKernelVersionProvider
{
    /// <summary>
    /// EN: カーネルのバージョンを取得します。
    /// [EN] Documents this public package API member. [JA] GetVersion 操作を実行します。
    /// </summary>
    string GetVersion();
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: 統合コンテキスト契約を実行する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelContextExecutor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelContextExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelContextExecutor']" />
public interface IKernelContextExecutor
{
    /// <summary>
    /// EN: 統合コンテキスト契約を処理します。
    /// [EN] Documents this public package API member. [JA] ExecuteAsync 操作を実行します。
    /// </summary>
    /// <param name="contract">[EN] Documents this public package API member. [JA] 処理する統合コンテキスト契約 contract パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 処理結果 結果を返します。</returns>
    Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract);
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: Attention 汚染を解析する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelAttentionAnalyzer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelAttentionAnalyzer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelAttentionAnalyzer']" />
public interface IKernelAttentionAnalyzer
{
    /// <summary>
    /// EN: Orchestration Context を検証し、Attention 汚染を検出します。
    /// [EN] Documents this public package API member. [JA] AnalyzeAttentionAsync 操作を実行します。
    /// </summary>
    Task<AttentionAnalysis> AnalyzeAttentionAsync(OrchestrationContextDto contract);
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: Material Context を正規化・構造化する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelMaterialPreprocessor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelMaterialPreprocessor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelMaterialPreprocessor']" />
public interface IKernelMaterialPreprocessor
{
    /// <summary>
    /// EN: Material Context を正規化・構造化します。
    /// [EN] Documents this public package API member. [JA] PreprocessMaterialAsync 操作を実行します。
    /// </summary>
    Task<MaterialContextDto> PreprocessMaterialAsync(MaterialContextDto material);
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: Expression Context を推論後に適用可能な状態にする capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelExpressionPreparer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelExpressionPreparer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelExpressionPreparer']" />
public interface IKernelExpressionPreparer
{
    /// <summary>
    /// EN: Expression Context を推論後に適用可能な状態にします。
    /// [EN] Documents this public package API member. [JA] PrepareExpressionAsync 操作を実行します。
    /// </summary>
    Task<ExpressionContextDto> PrepareExpressionAsync(ExpressionContextDto expression);
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: Provider Router を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelProviderRouterAccessor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelProviderRouterAccessor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelProviderRouterAccessor']" />
public interface IKernelProviderRouterAccessor
{
    /// <summary>
    /// EN: 複数の Provider を管理・ルーティングします。
    /// [EN] Documents this public package API member. [JA] GetProviderRouter 操作を実行します。
    /// </summary>
    IProviderRouter GetProviderRouter();
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: Guard を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelGuardAccessor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelGuardAccessor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelGuardAccessor']" />
public interface IKernelGuardAccessor
{
    /// <summary>
    /// EN: セキュリティポリシーを管理します。
    /// [EN] Documents this public package API member. [JA] GetGuard 操作を実行します。
    /// </summary>
    IGuard GetGuard();
}

/// <summary>
/// UC-09 に基づく契約です。
/// EN: PDP を公開する capability interface です。
/// [EN] Documents this public package API member. [JA] IKernelPdpAccessor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelPdpAccessor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernelPdpAccessor']" />
public interface IKernelPdpAccessor
{
    /// <summary>
    /// EN: ポリシー決定を行います。
    /// [EN] Documents this public package API member. [JA] GetPdp 操作を実行します。
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
/// EN: - Attention 汚染防止
/// [EN] Documents this public package API member. [JA] IKernel の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernel']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Kernel.IKernel']" />
public interface IKernel :
    IKernelVersionProvider,
    IKernelContextExecutor,
    IKernelAttentionAnalyzer,
    IKernelMaterialPreprocessor,
    IKernelExpressionPreparer,
    IKernelProviderRouterAccessor,
    IKernelGuardAccessor,
    IKernelPdpAccessor
{
}
