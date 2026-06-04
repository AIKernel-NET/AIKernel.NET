namespace AIKernel.Dtos.Dsl;

public sealed record DslPipelineExecutionContext(
    DslPipelineValue Input,
    DateTimeOffset StartedAtUtc);
