namespace AIKernel.Dtos.Routing;

/// <summary>
/// ComputeShape の契約を定義します。
/// JA: ComputeShape の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ComputeShape']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ComputeShape']" />
public sealed record ComputeShape(
    int BatchSize,
    int SequenceLength,
    int HiddenDimension);



