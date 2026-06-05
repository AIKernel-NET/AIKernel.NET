namespace AIKernel.Enums;

/// <summary>
/// Identifies a pre-inference admissibility gate that may emit replay evidence.
/// </summary>
public enum AdmissibilityGateKind
{
    Unknown = 0,
    PromptOverride = 1,
    CapabilityAdmission = 2,
    CriticalOperation = 3,
    ComputationalComplexity = 4,
    PolicyDecision = 5,
    ContextIntegrity = 6,
    RuntimeInvariant = 7
}
