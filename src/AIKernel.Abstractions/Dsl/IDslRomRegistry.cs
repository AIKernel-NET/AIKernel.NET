namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslRomRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslRomRegistry']" />
public interface IDslRomRegistry
{
    /// <summary>Executes the RegisterAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで RegisterAsync 操作を実行します。</summary>
    Task<DslRomMetadata> RegisterAsync(
        DslRomSnapshot snapshot,
        CancellationToken cancellationToken = default);

    /// <summary>Executes the Contains operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Contains 操作を実行します。</summary>
    bool Contains(string capabilityName);

    /// <summary>Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    Task<DslRomSnapshot> ResolveAsync(
        string capabilityName,
        CancellationToken cancellationToken = default);
}
