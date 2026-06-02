namespace AIKernel.Dtos.Execution;

using AIKernel.Abstractions.Context;

public sealed record PromptGenerationRequest(
    IContextSnapshot ContextSnapshot,
    string UserInstruction,
    ModelPromptCapability Capability,
    PromptGenerationOptions Options);
