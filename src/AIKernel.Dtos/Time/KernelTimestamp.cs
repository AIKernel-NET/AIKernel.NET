namespace AIKernel.Dtos.Time;

/// <summary>
/// EN: Represents an AIKernel logical timestamp without binding callers to a concrete clock implementation.
/// EN: Documentation for public API. JA: KernelTimestamp の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Time.KernelTimestamp']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Time.KernelTimestamp']" />
public sealed record KernelTimestamp
{
    /// <summary>EN: Documentation for public API. JA: UtcDateTime を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.UtcDateTime']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.UtcDateTime']" />
    public required DateTimeOffset UtcDateTime { get; init; }

    /// <summary>EN: Documentation for public API. JA: LogicalCounter を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.LogicalCounter']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.LogicalCounter']" />
    public long? LogicalCounter { get; init; }

    /// <summary>EN: Documentation for public API. JA: SourceId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.SourceId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.SourceId']" />
    public string? SourceId { get; init; }

    /// <summary>EN: Documentation for public API. JA: Signature を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.Signature']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Time.KernelTimestamp.Signature']" />
    public string? Signature { get; init; }
}
