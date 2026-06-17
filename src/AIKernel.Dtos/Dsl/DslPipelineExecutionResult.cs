namespace AIKernel.Dtos.Dsl;

using System.Collections.Immutable;
using AIKernel.Dtos.Execution;
using AIKernel.Enums;

/// <summary>[EN] Documents this public package API member. [JA] DslPipelineExecutionResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineExecutionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslPipelineExecutionResult']" />
public sealed record DslPipelineExecutionResult
{
    /// <summary>[EN] Documents this public package API member. [JA] Status を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.Status']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.Status']" />
    public required ExecutionStatus Status { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] State を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.State']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.State']" />
    public required DslPipelineState State { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Output を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.Output']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.Output']" />
    public required DslPipelineValue Output { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Error を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.Error']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.Error']" />
    public required ExecutionError? Error { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ReplayLogCount を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.ReplayLogCount']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.ReplayLogCount']" />
    public required int ReplayLogCount { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ReplayLogHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.ReplayLogHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.ReplayLogHash']" />
    public required string ReplayLogHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Dsl.DslPipelineExecutionResult.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; } =
        ImmutableDictionary<string, string>.Empty;
}
