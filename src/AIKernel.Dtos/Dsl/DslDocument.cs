namespace AIKernel.Dtos.Dsl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslDocument']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslDocument']" />
public sealed record DslDocument(PipelineNode Root);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineNode']" />
public abstract record PipelineNode(string Type);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineRootNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineRootNode']" />
public sealed record PipelineRootNode(
    IReadOnlyList<PipelineNode> Steps) : PipelineNode(DslNodeTypes.Pipeline);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.StepNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.StepNode']" />
public sealed record StepNode(
    string Name) : PipelineNode(DslNodeTypes.Step);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.CallCapabilityNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.CallCapabilityNode']" />
public sealed record CallCapabilityNode(
    string Name,
    IReadOnlyDictionary<string, string> Args) : PipelineNode(DslNodeTypes.CallCapability);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopNode']" />
public sealed record LoopNode(
    int MaxIterations,
    IReadOnlyList<PipelineNode> BodyNodes) : PipelineNode(DslNodeTypes.Loop);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopUntilNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopUntilNode']" />
public sealed record LoopUntilNode(
    TimeSpan Timeout,
    int MaxIterations,
    IReadOnlyList<PipelineNode> BodyNodes) : PipelineNode(DslNodeTypes.LoopUntil);

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.SuspendNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.SuspendNode']" />
public sealed record SuspendNode(
    string Reason) : PipelineNode(DslNodeTypes.Suspend);
