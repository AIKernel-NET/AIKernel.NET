namespace AIKernel.Abstractions.Rom;

/// <summary>
/// EN: UC-01/UC-12 および ROM Core 仕様に基づき、正準化済み ROM の意味ハッシュを計算・検証する契約を定義します。
/// EN: Documentation for public API. JA: ISemanticHasher の公開契約を定義します。
/// </summary>
/// <remarks>
/// 同一の <see cref="CanonicalizedRomDto"/> 入力に対して、常に同一のハッシュ値を返す決定論的挙動を保証する必要があります。
/// </remarks>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.ISemanticHasher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.ISemanticHasher']" />
public interface ISemanticHasher
{
    /// <summary>
    /// EN: 使用するハッシュアルゴリズム名を取得します。
    /// EN: Documentation for public API. JA: ComputeHash 操作を実行します。
    /// </summary>
    string Algorithm { get; }

    /// <summary>
    /// EN: 正準化済み ROM から意味ハッシュを計算します。
    /// EN: Documentation for public API. JA: ComputeHash 操作を実行します。
    /// </summary>
    /// <param name="canonicalized">EN: Documentation for public API. JA: 正準化済み ROM データ canonicalized パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 計算されたハッシュ値 結果を返します。</returns>
    string ComputeHash(CanonicalizedRomDto canonicalized);

    /// <summary>
    /// EN: 正準化済み ROM から意味ハッシュを非同期で計算します。
    /// EN: Documentation for public API. JA: ComputeHashAsync 操作を実行します。
    /// </summary>
    /// <param name="canonicalized">EN: Documentation for public API. JA: 正準化済み ROM データ canonicalized パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 計算されたハッシュ値 結果を返します。</returns>
    Task<string> ComputeHashAsync(CanonicalizedRomDto canonicalized, CancellationToken cancellationToken = default);

    /// <summary>
    /// EN: 正準化済み ROM のハッシュ値を検証します。
    /// EN: Documentation for public API. JA: VerifyHash 操作を実行します。
    /// </summary>
    /// <param name="canonicalized">EN: Documentation for public API. JA: 正準化済み ROM データ canonicalized パラメーターです。</param>
    /// <param name="expectedHash">EN: Documentation for public API. JA: 期待されるハッシュ値 expectedHash パラメーターです。</param>
    /// <returns>一致する場合は <see langword="true"/>、不一致の場合は <see langword="false"/>EN: Documentation for public API. JA: 。 結果を返します。</returns>
    bool VerifyHash(CanonicalizedRomDto canonicalized, string expectedHash);

    /// <summary>
    /// EN: 正準化済み ROM のハッシュ値を非同期で検証します。
    /// EN: Documentation for public API. JA: VerifyHashAsync 操作を実行します。
    /// </summary>
    /// <param name="canonicalized">EN: Documentation for public API. JA: 正準化済み ROM データ canonicalized パラメーターです。</param>
    /// <param name="expectedHash">EN: Documentation for public API. JA: 期待されるハッシュ値 expectedHash パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>一致する場合は <see langword="true"/>、不一致の場合は <see langword="false"/>EN: Documentation for public API. JA: 。 結果を返します。</returns>
    Task<bool> VerifyHashAsync(
        CanonicalizedRomDto canonicalized,
        string expectedHash,
        CancellationToken cancellationToken = default);
}


