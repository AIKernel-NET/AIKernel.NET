namespace AIKernel.Dtos.Execution;

public sealed record PromptGenerationRequest(
    string ContextSnapshotId,
    string ContextHash,
    IReadOnlyList<ContextPromptBlock> ContextBlocks,
    string UserInstruction,
    ModelPromptCapability Capability,
    PromptGenerationOptions Options);
