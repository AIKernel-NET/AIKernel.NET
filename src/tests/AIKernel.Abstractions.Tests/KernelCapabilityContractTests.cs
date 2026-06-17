using AIKernel.Abstractions.Kernel;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Rules;
using AIKernel.Abstractions.Security;
using AIKernel.Dtos.Kernel;
using KernelContextExecutor = AIKernel.Abstractions.Kernel.IKernelContextExecutor;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class KernelCapabilityContractTests
{
    /// <summary>
    /// EN: Executes CompositeKernelExposesGranularKernelCapabilities.
    /// EN: Documentation for public API. JA: CompositeKernelExposesGranularKernelCapabilities を実行します。
    /// </summary>
    [Fact]
    public void CompositeKernelExposesGranularKernelCapabilities()
    {
        IKernel kernel = new FullKernel();

        Assert.IsAssignableFrom<IKernelVersionProvider>(kernel);
        Assert.IsAssignableFrom<KernelContextExecutor>(kernel);
        Assert.IsAssignableFrom<IKernelAttentionAnalyzer>(kernel);
        Assert.IsAssignableFrom<IKernelMaterialPreprocessor>(kernel);
        Assert.IsAssignableFrom<IKernelExpressionPreparer>(kernel);
        Assert.IsAssignableFrom<IKernelProviderRouterAccessor>(kernel);
        Assert.IsAssignableFrom<IKernelGuardAccessor>(kernel);
        Assert.IsAssignableFrom<IKernelPdpAccessor>(kernel);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void KernelExecutorDoesNotExposeGovernanceAccessors()
    {
        KernelContextExecutor executor = new ExecuteOnlyKernel();

        Assert.False(executor is IKernelGuardAccessor);
        Assert.False(executor is IKernelPdpAccessor);
        Assert.False(executor is IKernelProviderRouterAccessor);
    }

    private sealed class ExecuteOnlyKernel : KernelContextExecutor
    {
        /// <summary>
        /// EN: Executes ExecuteAsync.
        /// EN: Documentation for public API. JA: ExecuteAsync を実行します。
        /// </summary>
        public Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<KernelExecutionResult>(null!);
        }
    }

    private sealed class FullKernel : IKernel
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public string GetVersion()
        {
            return "0.0.2";
        }
        /// <summary>
        /// EN: Executes ExecuteAsync.
        /// EN: Documentation for public API. JA: ExecuteAsync を実行します。
        /// </summary>

        public Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<KernelExecutionResult>(null!);
        }
        /// <summary>
        /// EN: Executes AnalyzeAttentionAsync.
        /// EN: Documentation for public API. JA: AnalyzeAttentionAsync を実行します。
        /// </summary>

        public Task<AttentionAnalysis> AnalyzeAttentionAsync(OrchestrationContextDto contract)
        {
            return Task.FromResult<AttentionAnalysis>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<MaterialContextDto> PreprocessMaterialAsync(MaterialContextDto material)
        {
            return Task.FromResult(material);
        }
        /// <summary>
        /// EN: Executes PrepareExpressionAsync.
        /// EN: Documentation for public API. JA: PrepareExpressionAsync を実行します。
        /// </summary>

        public Task<ExpressionContextDto> PrepareExpressionAsync(ExpressionContextDto expression)
        {
            return Task.FromResult(expression);
        }
        /// <summary>
        /// EN: Executes GetProviderRouter.
        /// EN: Documentation for public API. JA: GetProviderRouter を実行します。
        /// </summary>

        public IProviderRouter GetProviderRouter()
        {
            return null!;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public IGuard GetGuard()
        {
            return null!;
        }
        /// <summary>
        /// EN: Executes GetPdp.
        /// EN: Documentation for public API. JA: GetPdp を実行します。
        /// </summary>

        public IPdp GetPdp()
        {
            return null!;
        }
    }
}
