namespace AIKernel.Dtos.Execution;

/// <summary>
/// PhaseHandoverResult の契約を定義します。
/// </summary>
public sealed record PhaseHandoverResult(
    bool IsValid,
    string Message,
    IReadOnlyList<string> Issues,
    IReadOnlyList<string> Warnings);



