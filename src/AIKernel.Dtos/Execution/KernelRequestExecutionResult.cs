namespace AIKernel.Dtos.Execution;

using AIKernel.Enums;
using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] KernelRequestExecutionResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.KernelRequestExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.KernelRequestExecutionResult']" />
public sealed record KernelRequestExecutionResult
{
    /// <summary>[EN] Documents this public package API member. [JA] ExecutionId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ExecutionId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ExecutionId']" />
    public required string ExecutionId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Status を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Status']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Status']" />
    public required ExecutionStatus Status { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ProviderId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ProviderId']" />
    public required string ProviderId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ModelId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ModelId']" />
    public required string ModelId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ContextSnapshotId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextSnapshotId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextSnapshotId']" />
    public required string ContextSnapshotId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ContextHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.ContextHash']" />
    public required string ContextHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] PromptHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.PromptHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.PromptHash']" />
    public required string PromptHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] OutputText を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.OutputText']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.OutputText']" />
    public required string? OutputText { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Usage を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Usage']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Usage']" />
    public required ExecutionUsage Usage { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Error を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Error']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.Error']" />
    public required ExecutionError? Error { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] StartedAtUtc を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.StartedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.StartedAtUtc']" />
    public required DateTimeOffset StartedAtUtc { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] CompletedAtUtc を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.CompletedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.CompletedAtUtc']" />
    public required DateTimeOffset CompletedAtUtc { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.KernelRequestExecutionResult.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
