namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: PolisherValidationResult の契約を定義します。
/// EN: Documentation for public API. JA: PolisherValidationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PolisherValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PolisherValidationResult']" />
public sealed record PolisherValidationResult
{
    /// <summary>EN: Documentation for public API. JA: IsValid を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.IsValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.IsValid']" />
    public required bool IsValid { get; init; }
    /// <summary>EN: Documentation for public API. JA: Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.Message']" />
    public required string Message { get; init; }
    /// <summary>EN: Documentation for public API. JA: Violations を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.PolisherValidationResult.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.PolisherValidationResult.List&lt;string&gt;']" />
    public IReadOnlyList<string> Violations { get; init; } = new List<string>();
    /// <summary>EN: Documentation for public API. JA: LogicIntegrityScore を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.LogicIntegrityScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.PolisherValidationResult.LogicIntegrityScore']" />
    public double LogicIntegrityScore { get; init; }
}




