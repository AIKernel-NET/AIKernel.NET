namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: InitializationResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] InitializationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.InitializationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.InitializationResult']" />
public sealed record InitializationResult
{
    /// <summary>[EN] Documents this public package API member. [JA] IsInitialized を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.IsInitialized']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.IsInitialized']" />
    public required bool IsInitialized { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.Message']" />
    public required string Message { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Issues を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.InitializationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.InitializationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Issues { get; init; } = new List<string>();
    /// <summary>[EN] Documents this public package API member. [JA] PreExecutionContextHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.PreExecutionContextHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.InitializationResult.PreExecutionContextHash']" />
    public string? PreExecutionContextHash { get; init; }
}




