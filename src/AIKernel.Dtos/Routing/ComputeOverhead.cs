namespace AIKernel.Dtos.Routing;

/// <summary>
/// EN: ComputeOverhead の契約を定義します。
/// EN: Documentation for public API. JA: ComputeOverhead の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ComputeOverhead']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ComputeOverhead']" />
public sealed record ComputeOverhead(
    long MemoryOverheadMb,
    long AdditionalFlops,
    float LatencyOverheadMs);



