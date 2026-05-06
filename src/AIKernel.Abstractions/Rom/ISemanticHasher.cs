namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 および ROM Core 仕様に基づき、正準化済み ROM の意味ハッシュを計算・検証する契約を定義します。
/// </summary>
/// <remarks>
/// 同一の <see cref="CanonicalizedRomDto"/> 入力に対して、常に同一のハッシュ値を返す決定論的挙動を保証する必要があります。
/// </remarks>
public interface ISemanticHasher
{
    /// <summary>
    /// 使用するハッシュアルゴリズム名を取得します。
    /// </summary>
    string Algorithm { get; }

    /// <summary>
    /// 正準化済み ROM から意味ハッシュを計算します。
    /// </summary>
    /// <param name="canonicalized">正準化済み ROM データ</param>
    /// <returns>計算されたハッシュ値</returns>
    /// <exception cref="ArgumentNullException">引数が null の場合にスローされます。</exception>
    string ComputeHash(CanonicalizedRomDto canonicalized);

    /// <summary>
    /// 正準化済み ROM から意味ハッシュを非同期で計算します。
    /// </summary>
    /// <param name="canonicalized">正準化済み ROM データ</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>計算されたハッシュ値</returns>
    /// <exception cref="ArgumentNullException">引数が null の場合にスローされます。</exception>
    Task<string> ComputeHashAsync(CanonicalizedRomDto canonicalized, CancellationToken cancellationToken = default);

    /// <summary>
    /// 正準化済み ROM のハッシュ値を検証します。
    /// </summary>
    /// <param name="canonicalized">正準化済み ROM データ</param>
    /// <param name="expectedHash">期待されるハッシュ値</param>
    /// <returns>一致する場合は <see langword="true"/>、不一致の場合は <see langword="false"/>。</returns>
    bool VerifyHash(CanonicalizedRomDto canonicalized, string expectedHash);

    /// <summary>
    /// 正準化済み ROM のハッシュ値を非同期で検証します。
    /// </summary>
    /// <param name="canonicalized">正準化済み ROM データ</param>
    /// <param name="expectedHash">期待されるハッシュ値</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>一致する場合は <see langword="true"/>、不一致の場合は <see langword="false"/>。</returns>
    Task<bool> VerifyHashAsync(
        CanonicalizedRomDto canonicalized,
        string expectedHash,
        CancellationToken cancellationToken = default);
}


