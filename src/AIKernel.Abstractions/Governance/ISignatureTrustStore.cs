namespace AIKernel.Abstractions.Governance;

/// <summary>
/// 署名信頼ストアの契約。
/// SGS-003: ISignatureTrustStore は署名者信頼/失効を判定しなければならない（MUST）。
/// SGS-006: 信頼連鎖の検証（Validation of Trust Chain）。
/// SGS-F005: Trusted Anchor Unreachability: ISignatureTrustStore 到達不能時は Indeterminate として実行遮断する。
/// </summary>
public interface ISignatureTrustStore
{
    /// <summary>
    /// 署名者の信頼状態を解決します。
    /// SGS-003, SGS-006 の実装基盤。
    /// </summary>
    /// <param name="signerId">署名者 ID</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>信頼スコア（0.0-1.0）。0 未満はエラー/不信。1.0 は完全信頼。</returns>
    /// <remarks>
    /// SGS-F005: タイムアウトや通信障害時は -1 を返し、呼び出し側は Deny とする。
    /// </remarks>
    Task<double> ResolveTrustScoreAsync(string signerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 署名鍵が失効しているかどうかを確認します。
    /// SGS-006 の実装。
    /// </summary>
    /// <param name="keyId">鍵 ID</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>失効している場合は true</returns>
    Task<bool> IsKeyRevokedAsync(string keyId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 署名鍵の有効期限を取得します。
    /// SGS-F004: Temporal Integrity Violation の検出に用いる。
    /// </summary>
    /// <param name="keyId">鍵 ID</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>有効期限（UTC）、失効していない場合のみ返される</returns>
    Task<DateTime?> GetKeyExpiryAsync(string keyId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 署名者の証明書チェーンを検証します。
    /// SGS-006: 信頼連鎖の検証。
    /// </summary>
    /// <param name="signerId">署名者 ID</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>証明書チェーンが有効かどうか</returns>
    Task<bool> VerifyCertificateChainAsync(string signerId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 信頼アンカー情報を取得します。
    /// SGS-006: 信頼ルートの定義に用いる。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>信頼できるルートキー/認証局の ID リスト</returns>
    Task<IReadOnlyList<string>> GetTrustedAnchorsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// ストアへのアクセス可否を確認（ヘルスチェック）。
    /// SGS-F005: 到達不能を検知するために使用。
    /// </summary>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>ストアが到達可能でかつ正常に動作しているかどうか</returns>
    Task<bool> IsHealthyAsync(CancellationToken cancellationToken = default);
}

/// <summary>
/// 信頼コンテキスト情報。
/// SGS-003 の検証結果を保持。
/// </summary>
public sealed record TrustContext
{
    /// <summary>
    /// 署名者 ID。
    /// </summary>
    public required string SignerId { get; init; }

    /// <summary>
    /// 信頼スコア（0.0-1.0）。
    /// </summary>
    public required double TrustScore { get; init; }

    /// <summary>
    /// 鍵が失効しているかどうか。
    /// </summary>
    public required bool IsKeyRevoked { get; init; }

    /// <summary>
    /// 鍵の有効期限。
    /// </summary>
    public DateTime? KeyExpiry { get; init; }

    /// <summary>
    /// 証明書チェーン検証結果。
    /// </summary>
    public required bool IsCertificateChainValid { get; init; }

    /// <summary>
    /// 信頼ストアが到達可能であるか。
    /// SGS-F005 対応。
    /// </summary>
    public required bool IsTrustStoreHealthy { get; init; }

    /// <summary>
    /// 検証タイムスタンプ。
    /// </summary>
    public required DateTime VerificationTimestamp { get; init; }

    /// <summary>
    /// 信頼判定が確定しているか（Indeterminate状態でないか）。
    /// SGS-F001: 判定不能は Deny とする。
    /// </summary>
    public bool IsDetermined => IsTrustStoreHealthy && TrustScore >= 0;
}
