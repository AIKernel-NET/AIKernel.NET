namespace AIKernel.Dtos.Routing;

public sealed record ComputeShape(
    int BatchSize,
    int SequenceLength,
    int HiddenDimension);
