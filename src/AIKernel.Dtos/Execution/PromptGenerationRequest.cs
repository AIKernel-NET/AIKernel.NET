namespace AIKernel.Dtos.Execution;

/// <summary>[EN] Documents this public package API member. [JA] PromptGenerationRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PromptGenerationRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.PromptGenerationRequest']" />
public sealed record PromptGenerationRequest(
    string ContextSnapshotId,
    string ContextHash,
    IReadOnlyList<ContextPromptBlock> ContextBlocks,
    string UserInstruction,
    ModelPromptCapability Capability,
    PromptGenerationOptions Options);
