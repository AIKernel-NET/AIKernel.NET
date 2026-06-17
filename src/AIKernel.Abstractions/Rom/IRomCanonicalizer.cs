namespace AIKernel.Abstractions.Rom;

/// <summary>
/// EN: UC-01/UC-12 に基づく IRomCanonicalizer の契約を定義します。
/// [EN] Documents this public package API member. [JA] IRomCanonicalizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomCanonicalizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomCanonicalizer']" />
public interface IRomCanonicalizer
{
    /// <summary>EN: Executes the Canonicalize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Canonicalize 操作を実行します。</summary>
    CanonicalizedRomDto Canonicalize(IRomDocument document);

    /// <summary>EN: Executes the CanonicalizeAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CanonicalizeAsync 操作を実行します。</summary>
    Task<CanonicalizedRomDto> CanonicalizeAsync(IRomDocument document, CancellationToken cancellationToken = default);
}


