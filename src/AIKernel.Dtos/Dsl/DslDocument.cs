namespace AIKernel.Dtos.Dsl;

/// <summary>EN: Documentation for public API. JA: DslDocument を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslDocument']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.DslDocument']" />
public sealed record DslDocument(PipelineNode Root);

/// <summary>EN: Documentation for public API. JA: PipelineNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineNode']" />
public abstract record PipelineNode(string Type);

/// <summary>EN: Documentation for public API. JA: PipelineRootNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineRootNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.PipelineRootNode']" />
public sealed record PipelineRootNode(
    IReadOnlyList<PipelineNode> Steps) : PipelineNode(DslNodeTypes.Pipeline);

/// <summary>EN: Documentation for public API. JA: StepNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.StepNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.StepNode']" />
public sealed record StepNode(
    string Name) : PipelineNode(DslNodeTypes.Step);

/// <summary>EN: Documentation for public API. JA: CallCapabilityNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.CallCapabilityNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.CallCapabilityNode']" />
public sealed record CallCapabilityNode(
    string Name,
    IReadOnlyDictionary<string, string> Args) : PipelineNode(DslNodeTypes.CallCapability);

/// <summary>EN: Documentation for public API. JA: LoopNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopNode']" />
public sealed record LoopNode(
    int MaxIterations,
    IReadOnlyList<PipelineNode> BodyNodes) : PipelineNode(DslNodeTypes.Loop);

/// <summary>EN: Documentation for public API. JA: LoopUntilNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopUntilNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.LoopUntilNode']" />
public sealed record LoopUntilNode(
    TimeSpan Timeout,
    int MaxIterations,
    IReadOnlyList<PipelineNode> BodyNodes) : PipelineNode(DslNodeTypes.LoopUntil);

/// <summary>EN: Documentation for public API. JA: SuspendNode を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.SuspendNode']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Dsl.SuspendNode']" />
public sealed record SuspendNode(
    string Reason) : PipelineNode(DslNodeTypes.Suspend);
