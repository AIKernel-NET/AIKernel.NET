namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: ModificationContext の契約を定義します。
/// EN: Documentation for public API. JA: ModificationContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModificationContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModificationContext']" />
public sealed record ModificationContext
{
    /// <summary>EN: Documentation for public API. JA: Reason を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.Reason']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.Reason']" />
    public required string Reason { get; init; }
    /// <summary>EN: Documentation for public API. JA: TargetPhase を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.TargetPhase']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.TargetPhase']" />
    public required string TargetPhase { get; init; }
    /// <summary>EN: Documentation for public API. JA: ModificationData を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModificationData']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModificationData']" />
    public required string ModificationData { get; init; }
    /// <summary>EN: Documentation for public API. JA: ModifiedBy を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModifiedBy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModifiedBy']" />
    public required string ModifiedBy { get; init; }
}




