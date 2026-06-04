namespace AIKernel.Dtos.Dsl;

public sealed record DslPipelineState(
    string PipelineId,
    string CurrentNode,
    int ExecutedNodeCount);
