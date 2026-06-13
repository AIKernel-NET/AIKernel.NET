namespace AIKernel.Abstractions.Governance;

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 署名者の信頼状態を解決する capability interface です。
/// JA: ISignerTrustResolver の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ISignerTrustResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ISignerTrustResolver']" />
public interface ISignerTrustResolver
{
    /// <summary>
    /// 署名者の信頼状態を解決します。
    /// SGS-003, SGS-006 の実装基盤。
    /// JA: ResolveTrustScoreAsync 操作を実行します。
    /// </summary>
    /// <param name="signerId">署名者 ID JA: signerId パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>信頼スコア（0.0-1.0）。0 未満はエラー/不信。1.0 は完全信頼。 JA: 結果を返します。</returns>
    /// <remarks>
    /// SGS-F005: タイムアウトや通信障害時は -1 を返し、呼び出し側は Deny とする。
    /// </remarks>
    Task<double> ResolveTrustScoreAsync(string signerId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 署名鍵の失効状態を確認する capability interface です。
/// JA: IKeyRevocationChecker の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyRevocationChecker']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyRevocationChecker']" />
public interface IKeyRevocationChecker
{
    /// <summary>
    /// 署名鍵が失効しているかどうかを確認します。
    /// SGS-006 の実装。
    /// JA: IsKeyRevokedAsync 操作を実行します。
    /// </summary>
    /// <param name="keyId">鍵 ID JA: keyId パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>失効している場合は true JA: 結果を返します。</returns>
    Task<bool> IsKeyRevokedAsync(string keyId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 署名鍵の有効期限を参照する capability interface です。
/// JA: IKeyExpiryReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyExpiryReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IKeyExpiryReader']" />
public interface IKeyExpiryReader
{
    /// <summary>
    /// 署名鍵の有効期限を取得します。
    /// SGS-F004: Temporal Integrity Violation の検出に用いる。
    /// JA: GetKeyExpiryAsync 操作を実行します。
    /// </summary>
    /// <param name="keyId">鍵 ID JA: keyId パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>有効期限（UTC）、失効していない場合のみ返される JA: 結果を返します。</returns>
    Task<DateTime?> GetKeyExpiryAsync(string keyId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 署名者の証明書チェーンを検証する capability interface です。
/// JA: ICertificateChainVerifier の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ICertificateChainVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ICertificateChainVerifier']" />
public interface ICertificateChainVerifier
{
    /// <summary>
    /// 署名者の証明書チェーンを検証します。
    /// SGS-006: 信頼連鎖の検証。
    /// JA: VerifyCertificateChainAsync 操作を実行します。
    /// </summary>
    /// <param name="signerId">署名者 ID JA: signerId パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>証明書チェーンが有効かどうか JA: 結果を返します。</returns>
    Task<bool> VerifyCertificateChainAsync(string signerId, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 信頼アンカー情報を参照する capability interface です。
/// JA: ITrustedAnchorReader の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustedAnchorReader']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustedAnchorReader']" />
public interface ITrustedAnchorReader
{
    /// <summary>
    /// 信頼アンカー情報を取得します。
    /// SGS-006: 信頼ルートの定義に用いる。
    /// JA: GetTrustedAnchorsAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>信頼できるルートキー/認証局の ID リスト JA: 結果を返します。</returns>
    Task<IReadOnlyList<string>> GetTrustedAnchorsAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// Trust Store の到達性を確認する capability interface です。
/// JA: ITrustStoreHealthProbe の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustStoreHealthProbe']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ITrustStoreHealthProbe']" />
public interface ITrustStoreHealthProbe
{
    /// <summary>
    /// ストアへのアクセス可否を確認（ヘルスチェック）。
    /// SGS-F005: 到達不能を検知するために使用。
    /// JA: IsHealthyAsync 操作を実行します。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>ストアが到達可能でかつ正常に動作しているかどうか JA: 結果を返します。</returns>
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-06/UC-32 に基づく契約です。
/// 署名信頼ストアの互換合成 contract。
/// SGS-003: ISignatureTrustStore は署名者信頼/失効を判定しなければならない（MUST）。
/// SGS-006: 信頼連鎖の検証（Validation of Trust Chain）。
/// SGS-F005: Trusted Anchor Unreachability: ISignatureTrustStore 到達不能時は Indeterminate として実行遮断する。
/// JA: ISignatureTrustStore の公開契約を定義します。
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
