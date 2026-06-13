namespace AIKernel.Dtos.KernelContext;

/// <summary>
/// Budget の契約を定義します。
/// JA: Budget の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Budget']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.KernelContext.Budget']" />
public sealed record Budget(
    string BudgetId,
    string BudgetType,
    double Limit,
    double Used,
    string? Unit,
    string? ResetPeriod,
    DateTime? LastResetAt);


