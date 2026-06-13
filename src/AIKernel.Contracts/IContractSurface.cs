using AIKernel.Dtos.Contracts;

namespace AIKernel.Contracts;

/// <summary>
/// Defines a contract validation surface without replacing existing context contracts.
/// </summary>
public interface IContractSurface
{
    /// <summary>
    /// Gets contract metadata including version and schema URI.
    /// </summary>
    ContractMetadata Metadata { get; }

    /// <summary>
    /// Validates a contract payload reference against this contract.
    /// </summary>
    /// <param name="request">The validation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The validation result.</returns>
    ValueTask<ContractValidationResult> ValidateAsync(
        ContractValidationRequest request,
        CancellationToken cancellationToken);
}
