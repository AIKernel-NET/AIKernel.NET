namespace AIKernel.Abstractions.Execution;

using AIKernel.Abstractions.Providers;
using AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IKernelExecutor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Execution.IKernelExecutor']" />
public interface IKernelExecutor
{
    /// <summary>Executes the ExecuteAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExecuteAsync 操作を実行します。</summary>
    Task<KernelRequestExecutionResult> ExecuteAsync(
        IModelProvider provider,
        KernelExecutionRequest request,
        CancellationToken cancellationToken = default);
}
