using AIKernel.Dtos.Contracts;

namespace AIKernel.Contracts;

/// <summary>
/// Applies a migration between two contract surfaces.
/// </summary>
public interface IMigrationScript
{
    /// <summary>
    /// Applies migration from an old contract to a new contract.
    /// </summary>
    /// <param name="oldContract">The source contract metadata.</param>
    /// <param name="newContract">The target contract metadata.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The migration result.</returns>
    ValueTask<MigrationResult> ApplyAsync(
        ContractMetadata oldContract,
        ContractMetadata newContract,
        CancellationToken cancellationToken);
}

/// <summary>
/// Compares two contract surfaces without applying migration.
/// </summary>
public interface IContractComparer
{
    /// <summary>
    /// Computes a contract diff.
    /// </summary>
    /// <param name="oldContract">The source contract metadata.</param>
    /// <param name="newContract">The target contract metadata.</param>
    /// <returns>The contract diff.</returns>
    ContractDiff Diff(ContractMetadata oldContract, ContractMetadata newContract);
}
