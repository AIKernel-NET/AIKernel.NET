namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく IRomCanonicalizer の契約を定義します。
/// </summary>
public interface IRomCanonicalizer
{
    CanonicalizedRomDto Canonicalize(IRomDocument document);

    Task<CanonicalizedRomDto> CanonicalizeAsync(IRomDocument document, CancellationToken cancellationToken = default);
}


