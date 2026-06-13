using AIKernel.Dtos.Hbs;

namespace AIKernel.Abstractions.Hbs;

/// <summary>
/// Signs deterministic payload references for hash-bound signature chains.
/// JA: ISignerService の公開契約を定義します。
/// </summary>
public interface ISignerService
{
    /// <summary>
    /// Signs a payload reference.
    /// JA: SignAsync 操作を実行します。
    /// </summary>
    /// <param name="payload">The payload reference or hash. JA: payload パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The signature result. JA: 結果を返します。</returns>
    ValueTask<SignatureResult> SignAsync(string payload, CancellationToken cancellationToken);
}

/// <summary>
/// Verifies deterministic payload signatures.
/// JA: IVerifierService の公開契約を定義します。
/// </summary>
public interface IVerifierService
{
    /// <summary>
    /// Verifies a payload signature.
    /// JA: VerifyAsync 操作を実行します。
    /// </summary>
    /// <param name="payload">The payload reference or hash. JA: payload パラメーターです。</param>
    /// <param name="signature">The signature value. JA: signature パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The verification result. JA: 結果を返します。</returns>
    ValueTask<VerifyResult> VerifyAsync(
        string payload,
        string signature,
        CancellationToken cancellationToken);
}

/// <summary>
/// Manages monotonic signature counters.
/// JA: ISignatureCounterStore の公開契約を定義します。
/// </summary>
public interface ISignatureCounterStore
{
    /// <summary>
    /// Gets the current signature counter.
    /// JA: GetCounterAsync 操作を実行します。
    /// </summary>
    /// <param name="counterId">The counter identifier. JA: counterId パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The signature counter. JA: 結果を返します。</returns>
    ValueTask<SignatureCounter> GetCounterAsync(string counterId, CancellationToken cancellationToken);

    /// <summary>
    /// Advances the signature counter.
    /// JA: AdvanceCounterAsync 操作を実行します。
    /// </summary>
    /// <param name="counterId">The counter identifier. JA: counterId パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The advanced signature counter. JA: 結果を返します。</returns>
    ValueTask<SignatureCounter> AdvanceCounterAsync(string counterId, CancellationToken cancellationToken);
}
