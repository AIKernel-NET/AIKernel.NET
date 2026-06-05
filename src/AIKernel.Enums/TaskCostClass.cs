namespace AIKernel.Enums;

/// <summary>
/// Conservative computational cost class used by pre-inference admissibility gates.
/// </summary>
public enum TaskCostClass
{
    Unknown = 0,
    Trivial = 1,
    Linear = 2,
    PolynomialSmall = 3,
    PolynomialLarge = 4,
    Exponential = 5,
    StateExplosive = 6,
    VerificationHard = 7,
    SelfReferential = 8,
    Unbounded = 9
}
