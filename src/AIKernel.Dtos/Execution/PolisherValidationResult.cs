namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: PolisherValidationResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] PolisherValidationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PolisherValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PolisherValidationResult']" />
public sealed record PolisherValidationResult
{
    /// <summary>[EN] Documents this public package API member. [JA] IsValid を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.IsValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.IsValid']" />
    public required bool IsValid { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.Message']" />
    public required string Message { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Violations を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.PolisherValidationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.PolisherValidationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Violations { get; init; } = new List<string>();
    /// <summary>[EN] Documents this public package API member. [JA] LogicIntegrityScore を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.LogicIntegrityScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.LogicIntegrityScore']" />
    public double LogicIntegrityScore { get; init; }
}




