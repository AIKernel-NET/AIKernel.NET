namespace AIKernel.Dtos.Execution;

public sealed record ModelMessage(
    string Role,
    string Content);
