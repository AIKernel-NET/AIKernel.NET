namespace AIKernel.Dtos.Execution;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PromptGenerationRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PromptGenerationRequest']" />
public sealed record PromptGenerationRequest(
    string ContextSnapshotId,
    string ContextHash,
    IReadOnlyList<ContextPromptBlock> ContextBlocks,
    string UserInstruction,
    ModelPromptCapability Capability,
    PromptGenerationOptions Options);
