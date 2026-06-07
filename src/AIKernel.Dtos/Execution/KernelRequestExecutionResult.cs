namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;
using System.Collections.Immutable;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.KernelRequestExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.KernelRequestExecutionResult']" />
public sealed record KernelRequestExecutionResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ExecutionId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ExecutionId']" />
    public required string ExecutionId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Status']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Status']" />
    public required ExecutionStatus Status { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ProviderId']" />
    public required string ProviderId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ModelId']" />
    public required string ModelId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextSnapshotId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextSnapshotId']" />
    public required string ContextSnapshotId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextHash']" />
    public required string ContextHash { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.PromptHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.PromptHash']" />
    public required string PromptHash { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.OutputText']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.OutputText']" />
    public required string? OutputText { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Usage']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Usage']" />
    public required ExecutionUsage Usage { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Error']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Error']" />
    public required ExecutionError? Error { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.StartedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.StartedAtUtc']" />
    public required DateTimeOffset StartedAtUtc { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.CompletedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.CompletedAtUtc']" />
    public required DateTimeOffset CompletedAtUtc { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
