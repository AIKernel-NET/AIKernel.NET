namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく IROMCanonicalizer の契約を定義します。
/// </summary>
public interface IROMCanonicalizer
{
    CanonicalizedRomDto Canonicalize(IRomDocument document);

    Task<CanonicalizedRomDto> CanonicalizeAsync(IRomDocument document, CancellationToken cancellationToken = default);
}


