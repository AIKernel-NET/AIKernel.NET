namespace AIKernel.Dtos.Control;

public sealed record ControlEnvelope(
    string ControlId,
    string Operation,
    IReadOnlyDictionary<string, string> Metadata);
