using AIKernel.Abstractions.Execution;
using AIKernel.Abstractions.Kernel;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Rules;
using AIKernel.Abstractions.Security;
using AIKernel.Dtos.Kernel;

namespace AIKernel.Abstractions.Tests;

public sealed class KernelCapabilityContractTests
{
    [Fact]
    public void CompositeKernelExposesGranularKernelCapabilities()
    {
        IKernel kernel = new FullKernel();

        Assert.IsAssignableFrom<IKernelVersionProvider>(kernel);
        Assert.IsAssignableFrom<IKernelExecutor>(kernel);
        Assert.IsAssignableFrom<IKernelAttentionAnalyzer>(kernel);
        Assert.IsAssignableFrom<IKernelMaterialPreprocessor>(kernel);
        Assert.IsAssignableFrom<IKernelExpressionPreparer>(kernel);
        Assert.IsAssignableFrom<IKernelProviderRouterAccessor>(kernel);
        Assert.IsAssignableFrom<IKernelGuardAccessor>(kernel);
        Assert.IsAssignableFrom<IKernelPdpAccessor>(kernel);
    }

    [Fact]
    public void KernelExecutorDoesNotExposeGovernanceAccessors()
    {
        IKernelExecutor executor = new ExecuteOnlyKernel();

        Assert.False(executor is IKernelGuardAccessor);
        Assert.False(executor is IKernelPdpAccessor);
        Assert.False(executor is IKernelProviderRouterAccessor);
    }

    private sealed class ExecuteOnlyKernel : IKernelExecutor
    {
        public Task<KernelExecutionResult> ExecuteAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<KernelExecutionResult>(null!);
        }
    }

    private sealed class FullKernel : IKernel
    {
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
