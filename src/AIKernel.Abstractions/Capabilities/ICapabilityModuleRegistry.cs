namespace AIKernel.Abstractions.Capabilities;

using AIKernel.Dtos.Capabilities;

public interface ICapabilityModuleRegistry
{
    ValueTask RegisterAsync(
        CapabilityModuleDescriptor descriptor,
        CancellationToken cancellationToken = default);

    ValueTask<CapabilityModuleDescriptor?> ResolveAsync(
        string capabilityId,
        CancellationToken cancellationToken = default);

    ValueTask<IReadOnlyList<CapabilityModuleDescriptor>> ListAsync(
        CancellationToken cancellationToken = default);
}
