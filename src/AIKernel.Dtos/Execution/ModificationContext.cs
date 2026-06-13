namespace AIKernel.Dtos.Execution;

/// <summary>
/// ModificationContext の契約を定義します。
/// JA: ModificationContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModificationContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.ModificationContext']" />
public sealed record ModificationContext
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.Reason']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.Reason']" />
    public required string Reason { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.TargetPhase']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.TargetPhase']" />
    public required string TargetPhase { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModificationData']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModificationData']" />
    public required string ModificationData { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModifiedBy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.ModificationContext.ModifiedBy']" />
    public required string ModifiedBy { get; init; }
}




