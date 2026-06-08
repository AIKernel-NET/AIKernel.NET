namespace AIKernel.Abstractions.Capabilities;

using AIKernel.Dtos.Capabilities;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Capabilities.ICapabilityModuleRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Capabilities.ICapabilityModuleRegistry']" />
public interface ICapabilityModuleRegistry
{
    /// <summary>Executes the RegisterAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterAsync 操作を実行します。</summary>
    ValueTask RegisterAsync(
        CapabilityModuleDescriptor descriptor,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    ValueTask<CapabilityModuleDescriptor?> ResolveAsync(
        string capabilityId,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the ListAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ListAsync 操作を実行します。</summary>
    ValueTask<IReadOnlyList<CapabilityModuleDescriptor>> ListAsync(
        CancellationToken cancellationToken = default);
}
