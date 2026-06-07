namespace AIKernel.Dtos.Control;

public sealed record ControlStateSnapshot(
    string ExecutionId,
    string GraphId,
    string NodeId,
    IReadOnlyDictionary<string, string> Metadata);
