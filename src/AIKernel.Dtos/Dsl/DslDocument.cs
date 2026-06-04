namespace AIKernel.Dtos.Dsl;

public sealed record DslDocument(PipelineNode Root);

public abstract record PipelineNode(string Type);

public sealed record PipelineRootNode(
    IReadOnlyList<PipelineNode> Steps) : PipelineNode("Pipeline");

public sealed record StepNode(
    string Name) : PipelineNode("Step");

public sealed record CallCapabilityNode(
    string Name,
    IReadOnlyDictionary<string, string> Args) : PipelineNode("CallCapability");

public sealed record LoopNode(
    int MaxIterations,
    IReadOnlyList<PipelineNode> BodyNodes) : PipelineNode("Loop");

public sealed record LoopUntilNode(
    TimeSpan Timeout,
    int MaxIterations,
    IReadOnlyList<PipelineNode> BodyNodes) : PipelineNode("LoopUntil");

public sealed record SuspendNode(
    string Reason) : PipelineNode("Suspend");
