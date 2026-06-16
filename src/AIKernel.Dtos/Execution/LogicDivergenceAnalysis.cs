namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: LogicDivergenceAnalysis の契約を定義します。
/// EN: Documentation for public API. JA: LogicDivergenceAnalysis の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.LogicDivergenceAnalysis']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.LogicDivergenceAnalysis']" />
public sealed record LogicDivergenceAnalysis
{
    /// <summary>EN: Documentation for public API. JA: DivergenceDetected を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.DivergenceDetected']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.DivergenceDetected']" />
    public required bool DivergenceDetected { get; init; }
    /// <summary>EN: Documentation for public API. JA: DivergenceType を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.DivergenceType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.DivergenceType']" />
    public required string DivergenceType { get; init; }
    /// <summary>EN: Documentation for public API. JA: Description を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.Description']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.Description']" />
    public required string Description { get; init; }
    /// <summary>EN: Documentation for public API. JA: Severity を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.Severity']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.Severity']" />
    public required string Severity { get; init; }
    /// <summary>EN: Documentation for public API. JA: AlteredSegments を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.List&lt;string&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Execution.LogicDivergenceAnalysis.List&lt;string&gt;']" />
    public IReadOnlyList<string> AlteredSegments { get; init; } = new List<string>();
}




