using AIKernel.Enums;

namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// Contract-only manifest for a reusable external capability module.
/// </summary>
public sealed record CapabilityModuleDescriptor(
    string CapabilityId,
    string Name,
    CapabilityModuleKind Kind,
    CapabilityInvocationMode InvocationMode,
    string Version,
    string? EntryPoint,
    string? ArtifactUri,
    string? ArtifactHash,
    IReadOnlyList<string> ProvidedOperations,
    IReadOnlyList<string> RequiredPermissions,
    IReadOnlyDictionary<string, string> Metadata);
