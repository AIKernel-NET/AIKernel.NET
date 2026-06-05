namespace AIKernel.Dtos.Governance;

/// <summary>
/// Provider budget envelope used by the computational complexity admission gate.
/// </summary>
public sealed record ModelExecutionBudget(
    string BudgetId,
    int ContextWindow,
    int OutputTokenBudget,
    IReadOnlyList<string> ExternalSolverAvailability,
    string? CalibratedErrorProfile,
    IReadOnlyDictionary<string, string> Metadata);
