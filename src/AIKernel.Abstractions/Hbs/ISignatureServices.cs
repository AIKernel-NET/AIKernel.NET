using AIKernel.Dtos.Hbs;

namespace AIKernel.Abstractions.Hbs;

/// <summary>
/// EN: Signs deterministic payload references for hash-bound signature chains.
/// [EN] Documents this public package API member. [JA] ISignerService の公開契約を定義します。
/// </summary>
public interface ISignerService
{
    /// <summary>
    /// EN: Signs a payload reference.
    /// [EN] Documents this public package API member. [JA] SignAsync 操作を実行します。
    /// </summary>
    /// <param name="payload">EN: The payload reference or hash. JA: payload パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The signature result. JA: 結果を返します。</returns>
    ValueTask<SignatureResult> SignAsync(string payload, CancellationToken cancellationToken);
}

/// <summary>
/// EN: Verifies deterministic payload signatures.
/// [EN] Documents this public package API member. [JA] IVerifierService の公開契約を定義します。
/// </summary>
public interface IVerifierService
{
    /// <summary>
    /// EN: Verifies a payload signature.
    /// [EN] Documents this public package API member. [JA] VerifyAsync 操作を実行します。
    /// </summary>
    /// <param name="payload">EN: The payload reference or hash. JA: payload パラメーターです。</param>
    /// <param name="signature">EN: The signature value. JA: signature パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The verification result. JA: 結果を返します。</returns>
    ValueTask<VerifyResult> VerifyAsync(
        string payload,
        string signature,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Manages monotonic signature counters.
/// [EN] Documents this public package API member. [JA] ISignatureCounterStore の公開契約を定義します。
/// </summary>
public interface ISignatureCounterStore
{
    /// <summary>
    /// EN: Gets the current signature counter.
    /// [EN] Documents this public package API member. [JA] GetCounterAsync 操作を実行します。
    /// </summary>
    /// <param name="counterId">EN: The counter identifier. JA: counterId パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The signature counter. JA: 結果を返します。</returns>
    ValueTask<SignatureCounter> GetCounterAsync(string counterId, CancellationToken cancellationToken);

    /// <summary>
    /// EN: Advances the signature counter.
    /// [EN] Documents this public package API member. [JA] AdvanceCounterAsync 操作を実行します。
    /// </summary>
    /// <param name="counterId">EN: The counter identifier. JA: counterId パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The advanced signature counter. JA: 結果を返します。</returns>
    ValueTask<SignatureCounter> AdvanceCounterAsync(string counterId, CancellationToken cancellationToken);
}
