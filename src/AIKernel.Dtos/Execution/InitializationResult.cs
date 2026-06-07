namespace AIKernel.Dtos.Execution;

/// <summary>
/// InitializationResult の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.InitializationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.InitializationResult']" />
public sealed record InitializationResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.IsInitialized']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.IsInitialized']" />
    public required bool IsInitialized { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.Message']" />
    public required string Message { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.InitializationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.InitializationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.PreExecutionContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.PreExecutionContextHash']" />
    public string? PreExecutionContextHash { get; init; }
}




