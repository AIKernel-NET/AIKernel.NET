namespace AIKernel.Dtos.Execution;

/// <summary>[EN] Documents this public package API member. [JA] ExecutionOptions を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionOptions']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionOptions']" />
public sealed record ExecutionOptions
{
    /// <summary>[EN] Documents this public package API member. [JA] Temperature を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.Temperature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.Temperature']" />
    public required double Temperature { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] TopP を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.TopP']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.TopP']" />
    public required double TopP { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] MaxOutputTokens を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.MaxOutputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.MaxOutputTokens']" />
    public required int? MaxOutputTokens { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] StopSequences を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.StopSequences']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.StopSequences']" />
    public required IReadOnlyList<string> StopSequences { get; init; }
}
