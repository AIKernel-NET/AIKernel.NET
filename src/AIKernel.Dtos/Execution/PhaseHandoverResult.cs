namespace AIKernel.Dtos.Execution;

public sealed record PhaseHandoverResult(
    bool IsValid,
    string Message,
    IReadOnlyList<string> Issues,
    IReadOnlyList<string> Warnings);
