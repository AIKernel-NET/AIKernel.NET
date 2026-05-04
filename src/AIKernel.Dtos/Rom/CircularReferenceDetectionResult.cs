namespace AIKernel.Dtos.Rom;

public sealed record CircularReferenceDetectionResult
{
    public required bool CircularReferencesDetected { get; init; }
    public required string Message { get; init; }
    public IReadOnlyList<IReadOnlyList<string>> CircularChains { get; init; } = new List<IReadOnlyList<string>>();
    public bool MayTriggerInferenceLoop { get; init; }
}

