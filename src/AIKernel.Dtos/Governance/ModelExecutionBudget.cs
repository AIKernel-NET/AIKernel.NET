namespace AIKernel.Dtos.Governance;

/// <summary>
/// Provider budget envelope used by the computational complexity admission gate.
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.ModelExecutionBudget']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.ModelExecutionBudget']" />
public sealed record ModelExecutionBudget(
    string BudgetId,
    int ContextWindow,
    int OutputTokenBudget,
    IReadOnlyList<string> ExternalSolverAvailability,
    string? CalibratedErrorProfile,
    IReadOnlyDictionary<string, string> Metadata);
