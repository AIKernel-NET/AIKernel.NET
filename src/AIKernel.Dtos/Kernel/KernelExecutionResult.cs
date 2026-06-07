using AIKernel.Enums;

namespace AIKernel.Dtos.Kernel;

/// <summary>
/// KernelExecutionResult の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.KernelExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.KernelExecutionResult']" />
public sealed record KernelExecutionResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.Success']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.Success']" />
    public required bool Success { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.Data']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.Data']" />
    public string? Data { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.Error']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.Error']" />
    public string? Error { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Kernel.KernelExecutionResult.List&lt;FailureMode&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Kernel.KernelExecutionResult.List&lt;FailureMode&gt;']" />
    public IReadOnlyList<FailureMode> FailureModes { get; init; } = new List<FailureMode>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.ExecutionTime']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelExecutionResult.ExecutionTime']" />
    public required TimeSpan ExecutionTime { get; init; }
}



