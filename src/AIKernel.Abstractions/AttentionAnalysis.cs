namespace AIKernel.Abstractions;

public sealed class AttentionAnalysis
{
    public double SignalToNoiseRatio { get; init; }
    public List<FailureMode> DetectedPollution { get; init; } = new();
    public List<string> Recommendations { get; init; } = new();
    public string RiskLevel { get; init; } = "Low";
}
