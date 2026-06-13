using AIKernel.Dtos.Hbs;

namespace AIKernel.Abstractions.Hbs;

/// <summary>
/// Signs deterministic payload references for hash-bound signature chains.
/// </summary>
public interface ISignerService
{
    /// <summary>
    /// Signs a payload reference.
    /// </summary>
    /// <param name="payload">The payload reference or hash.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The signature result.</returns>
    ValueTask<SignatureResult> SignAsync(string payload, CancellationToken cancellationToken);
}

/// <summary>
/// Verifies deterministic payload signatures.
/// </summary>
public interface IVerifierService
{
    /// <summary>
    /// Verifies a payload signature.
    /// </summary>
    /// <param name="payload">The payload reference or hash.</param>
    /// <param name="signature">The signature value.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The verification result.</returns>
    ValueTask<VerifyResult> VerifyAsync(
        string payload,
        string signature,
        CancellationToken cancellationToken);
}

/// <summary>
/// Manages monotonic signature counters.
/// </summary>
public interface ISignatureCounterStore
{
    /// <summary>
    /// Gets the current signature counter.
    /// </summary>
    /// <param name="counterId">The counter identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The signature counter.</returns>
    ValueTask<SignatureCounter> GetCounterAsync(string counterId, CancellationToken cancellationToken);

    /// <summary>
    /// Advances the signature counter.
    /// </summary>
    /// <param name="counterId">The counter identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The advanced signature counter.</returns>
    ValueTask<SignatureCounter> AdvanceCounterAsync(string counterId, CancellationToken cancellationToken);
}
