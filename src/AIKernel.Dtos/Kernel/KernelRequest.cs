namespace AIKernel.Dtos.Kernel;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Execution;
using AIKernel.Dtos.Rom;
using AIKernel.Dtos.Vfs;
using System.Collections.Immutable;

public sealed record KernelRequest
{
    public required string Input { get; init; }

    public required RomId RootRomId { get; init; }

    public required string VfsProviderId { get; init; }

    public required VfsCredentials Credentials { get; init; }

    public required ContextAssemblyScope Scope { get; init; }

    public required PromptGenerationOptions PromptOptions { get; init; }

    public required ExecutionOptions ExecutionOptions { get; init; }

    public string? RequestedModelId { get; init; }

    public string? ParentSnapshotId { get; init; }

    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
