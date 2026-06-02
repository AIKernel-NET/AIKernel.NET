namespace AIKernel.Dtos.Kernel;

using System.Collections.Immutable;

public sealed record KernelTransactionSnapshot
{
    public required string TransactionId { get; init; }

    public required string InputHash { get; init; }

    public required string RootRomId { get; init; }

    public required string VfsProviderId { get; init; }

    public required string? RequestedModelId { get; init; }

    public required DateTimeOffset StartedAtUtc { get; init; }

    public required ImmutableDictionary<string, string> Metadata { get; init; }
}