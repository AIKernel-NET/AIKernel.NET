namespace AIKernel.Abstractions.Dsl;

using AIKernel.Dtos.Dsl;
using AIKernel.Vfs;

/// <summary>EN: Documentation for public API. JA: IDslRomStore contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslRomStore']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Dsl.IDslRomStore']" />
public interface IDslRomStore
{
    /// <summary>EN: Executes the SaveDslAsRomAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SaveDslAsRomAsync 操作を実行します。</summary>
    Task<DslRomMetadata> SaveDslAsRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        string jsonDsl,
        DateTimeOffset createdAtUtc,
        string? expectedRomHash = null,
        CancellationToken cancellationToken = default);

    /// <summary>EN: Executes the LoadDslRomAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LoadDslRomAsync 操作を実行します。</summary>
    Task<DslRomMetadata> LoadDslRomAsync(
        IVfsSession session,
        string @namespace,
        string name,
        DateTimeOffset createdAtUtc,
        string expectedRomHash,
        CancellationToken cancellationToken = default);
}
