namespace AIKernel.Dtos.Routing;

/// <summary>
/// ModelCapacityVector の契約を定義します。
/// </summary>
public sealed record ModelCapacityVector
{
    public float StructuralIntegrity { get; init; }
    public float LinguisticFluidity { get; init; }
    public float ReasoningDepth { get; init; }
    public float Fidelity { get; init; }
    public float LatencyPerformance { get; init; }

    public ModelCapacityVector(
        float structuralIntegrity = 0f,
        float linguisticFluidity = 0f,
        float reasoningDepth = 0f,
        float fidelity = 0f,
        float latencyPerformance = 0f)
    {
        StructuralIntegrity = structuralIntegrity;
        LinguisticFluidity = linguisticFluidity;
        ReasoningDepth = reasoningDepth;
        Fidelity = fidelity;
        LatencyPerformance = latencyPerformance;
    }
}



