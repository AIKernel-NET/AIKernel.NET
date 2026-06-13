using AIKernel.Abstractions.Kernel;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Rules;
using AIKernel.Abstractions.Security;
using AIKernel.Dtos.Kernel;
using KernelContextExecutor = AIKernel.Abstractions.Kernel.IKernelContextExecutor;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class KernelCapabilityContractTests
{
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
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
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
        public Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<KernelExecutionResult>(null!);
        }
    }

    private sealed class FullKernel : IKernel
    {
        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public string GetVersion()
        {
            return "0.0.2";
        }

        public Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<KernelExecutionResult>(null!);
        }

        public Task<AttentionAnalysis> AnalyzeAttentionAsync(OrchestrationContextDto contract)
        {
            return Task.FromResult<AttentionAnalysis>(null!);
        }

        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<MaterialContextDto> PreprocessMaterialAsync(MaterialContextDto material)
        {
            return Task.FromResult(material);
        }

        public Task<ExpressionContextDto> PrepareExpressionAsync(ExpressionContextDto expression)
        {
            return Task.FromResult(expression);
        }

        public IProviderRouter GetProviderRouter()
        {
            return null!;
        }

        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public IGuard GetGuard()
        {
            return null!;
        }

        public IPdp GetPdp()
        {
            return null!;
        }
    }
}
