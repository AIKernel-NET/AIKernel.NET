namespace AIKernel.Dtos.Routing;

/// <summary>
/// ComputeShape の契約を定義します。
/// </summary>
public sealed record ComputeShape(
    int BatchSize,
    int SequenceLength,
    int HiddenDimension);



