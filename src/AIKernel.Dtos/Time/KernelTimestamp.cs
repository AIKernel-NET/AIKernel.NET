namespace AIKernel.Dtos.Time;

/// <summary>
/// Represents an AIKernel logical timestamp without binding callers to a concrete clock implementation.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Time.KernelTimestamp']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Time.KernelTimestamp']" />
public sealed record KernelTimestamp
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.UtcDateTime']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.UtcDateTime']" />
    public required DateTimeOffset UtcDateTime { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.LogicalCounter']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.LogicalCounter']" />
    public long? LogicalCounter { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.SourceId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.SourceId']" />
    public string? SourceId { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.Signature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.Signature']" />
    public string? Signature { get; init; }
}
