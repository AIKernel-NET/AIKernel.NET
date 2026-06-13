namespace AIKernel.Dtos.Routing;

/// <summary>
/// ModelCapacityVector の契約を定義します。
/// JA: ModelCapacityVector の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ModelCapacityVector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Routing.ModelCapacityVector']" />
public sealed record ModelCapacityVector
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.StructuralIntegrity']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.StructuralIntegrity']" />
    public float StructuralIntegrity { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.LinguisticFluidity']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.LinguisticFluidity']" />
    public float LinguisticFluidity { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.ReasoningDepth']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.ReasoningDepth']" />
    public float ReasoningDepth { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.Fidelity']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.Fidelity']" />
    public float Fidelity { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.LatencyPerformance']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Routing.ModelCapacityVector.LatencyPerformance']" />
    public float LatencyPerformance { get; init; }

    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Routing.ModelCapacityVector.#ctor']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Routing.ModelCapacityVector.#ctor']" />
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



