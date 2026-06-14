using AIKernel.Enums;

namespace AIKernel.Dtos.Capabilities;

/// <summary>
/// Contract-only manifest for a reusable external capability module.
/// JA: CapabilityModuleDescriptor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Capabilities.CapabilityModuleDescriptor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Capabilities.CapabilityModuleDescriptor']" />
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
