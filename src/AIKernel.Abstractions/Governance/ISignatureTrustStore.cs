namespace AIKernel.Abstractions.Governance;

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// EN: 署名者の信頼状態を解決する capability interface です。
/// EN: Documentation for public API. JA: ISignerTrustResolver の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ISignerTrustResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ISignerTrustResolver']" />
public interface ISignerTrustResolver
{
    /// <summary>
    /// 署名者の信頼状態を解決します。
    /// EN: SGS-003, SGS-006 の実装基盤。
    /// EN: Documentation for public API. JA: ResolveTrustScoreAsync 操作を実行します。
    /// </summary>
    /// <param name="signerId">EN: Documentation for public API. JA: 署名者 ID signerId パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 信頼スコア（0.0-1.0）。0 未満はエラー/不信。1.0 は完全信頼。 結果を返します。</returns>
    /// <remarks>
    /// SGS-F005: タイムアウトや通信障害時は -1 を返し、呼び出し側は Deny とする。
    /// </remarks>
    Task<double> ResolveTrustScoreAsync(string signerId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// EN: 署名鍵の失効状態を確認する capability interface です。
/// EN: Documentation for public API. JA: IKeyRevocationChecker の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyRevocationChecker']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyRevocationChecker']" />
public interface IKeyRevocationChecker
{
    /// <summary>
    /// 署名鍵が失効しているかどうかを確認します。
    /// EN: SGS-006 の実装。
    /// EN: Documentation for public API. JA: IsKeyRevokedAsync 操作を実行します。
    /// </summary>
    /// <param name="keyId">EN: Documentation for public API. JA: 鍵 ID keyId パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 失効している場合は true 結果を返します。</returns>
    Task<bool> IsKeyRevokedAsync(string keyId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// EN: 署名鍵の有効期限を参照する capability interface です。
/// EN: Documentation for public API. JA: IKeyExpiryReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyExpiryReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyExpiryReader']" />
public interface IKeyExpiryReader
{
    /// <summary>
    /// 署名鍵の有効期限を取得します。
    /// EN: SGS-F004: Temporal Integrity Violation の検出に用いる。
    /// EN: Documentation for public API. JA: GetKeyExpiryAsync 操作を実行します。
    /// </summary>
    /// <param name="keyId">EN: Documentation for public API. JA: 鍵 ID keyId パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 有効期限（UTC）、失効していない場合のみ返される 結果を返します。</returns>
    Task<DateTime?> GetKeyExpiryAsync(string keyId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// EN: 署名者の証明書チェーンを検証する capability interface です。
/// EN: Documentation for public API. JA: ICertificateChainVerifier の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ICertificateChainVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ICertificateChainVerifier']" />
public interface ICertificateChainVerifier
{
    /// <summary>
    /// 署名者の証明書チェーンを検証します。
    /// EN: SGS-006: 信頼連鎖の検証。
    /// EN: Documentation for public API. JA: VerifyCertificateChainAsync 操作を実行します。
    /// </summary>
    /// <param name="signerId">EN: Documentation for public API. JA: 署名者 ID signerId パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 証明書チェーンが有効かどうか 結果を返します。</returns>
    Task<bool> VerifyCertificateChainAsync(string signerId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// EN: 信頼アンカー情報を参照する capability interface です。
/// EN: Documentation for public API. JA: ITrustedAnchorReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustedAnchorReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustedAnchorReader']" />
public interface ITrustedAnchorReader
{
    /// <summary>
    /// 信頼アンカー情報を取得します。
    /// EN: SGS-006: 信頼ルートの定義に用いる。
    /// EN: Documentation for public API. JA: GetTrustedAnchorsAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 信頼できるルートキー/認証局の ID リスト 結果を返します。</returns>
    Task<IReadOnlyList<string>> GetTrustedAnchorsAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// EN: Trust Store の到達性を確認する capability interface です。
/// EN: Documentation for public API. JA: ITrustStoreHealthProbe の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustStoreHealthProbe']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustStoreHealthProbe']" />
public interface ITrustStoreHealthProbe
{
    /// <summary>
    /// ストアへのアクセス可否を確認（ヘルスチェック）。
    /// EN: SGS-F005: 到達不能を検知するために使用。
    /// EN: Documentation for public API. JA: IsHealthyAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: ストアが到達可能でかつ正常に動作しているかどうか 結果を返します。</returns>
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 署名信頼ストアの互換合成 contract。
/// SGS-003: ISignatureTrustStore は署名者信頼/失効を判定しなければならない（MUST）。
/// SGS-006: 信頼連鎖の検証（Validation of Trust Chain）。
/// EN: SGS-F005: Trusted Anchor Unreachability: ISignatureTrustStore 到達不能時は Indeterminate として実行遮断する。
/// EN: Documentation for public API. JA: ISignatureTrustStore の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ISignatureTrustStore']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ISignatureTrustStore']" />
public interface ISignatureTrustStore :
    ISignerTrustResolver,
    IKeyRevocationChecker,
    IKeyExpiryReader,
    ICertificateChainVerifier,
    ITrustedAnchorReader,
    ITrustStoreHealthProbe
{
}
