namespace AIKernel.Dtos.Execution;

/// <summary>EN: Documentation for public API. JA: KernelExecutionRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.KernelExecutionRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.KernelExecutionRequest']" />
public sealed record KernelExecutionRequest
{
    /// <summary>EN: Documentation for public API. JA: ContextSnapshotId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ContextSnapshotId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ContextSnapshotId']" />
    public required string ContextSnapshotId { get; init; }

    /// <summary>EN: Documentation for public API. JA: ContextHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ContextHash']" />
    public required string ContextHash { get; init; }

    /// <summary>EN: Documentation for public API. JA: ContextBlocks を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ContextBlocks']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ContextBlocks']" />
    public required IReadOnlyList<ContextPromptBlock> ContextBlocks { get; init; }

    /// <summary>EN: Documentation for public API. JA: UserInstruction を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.UserInstruction']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.UserInstruction']" />
    public required string UserInstruction { get; init; }

    /// <summary>EN: Documentation for public API. JA: PromptOptions を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.PromptOptions']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.PromptOptions']" />
    public required PromptGenerationOptions PromptOptions { get; init; }

    /// <summary>EN: Documentation for public API. JA: ExecutionOptions を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ExecutionOptions']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.ExecutionOptions']" />
    public required ExecutionOptions ExecutionOptions { get; init; }

    /// <summary>EN: Documentation for public API. JA: RequestedModelId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.RequestedModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelExecutionRequest.RequestedModelId']" />
    public string? RequestedModelId { get; init; }
}
