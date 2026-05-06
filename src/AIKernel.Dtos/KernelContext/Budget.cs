namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Budget の契約を定義します。
/// </summary>
public sealed record Budget(
    string BudgetId,
    string BudgetType,
    double Limit,
    double Used,
    string? Unit,
    string? ResetPeriod,
    DateTime? LastResetAt);


