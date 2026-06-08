namespace AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionOptions']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ExecutionOptions']" />
public sealed record ExecutionOptions
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.Temperature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.Temperature']" />
    public required double Temperature { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.TopP']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.TopP']" />
    public required double TopP { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.MaxOutputTokens']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.MaxOutputTokens']" />
    public required int? MaxOutputTokens { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.StopSequences']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ExecutionOptions.StopSequences']" />
    public required IReadOnlyList<string> StopSequences { get; init; }
}
