using AIKernel.Dtos.Contracts;

namespace AIKernel.Contracts;

/// <summary>
/// Applies a migration between two contract surfaces.
/// JA: IMigrationScript の公開契約を定義します。
/// </summary>
public interface IMigrationScript
{
    /// <summary>
    /// Applies migration from an old contract to a new contract.
    /// JA: ApplyAsync 操作を実行します。
    /// </summary>
    /// <param name="oldContract">The source contract metadata. JA: oldContract パラメーターです。</param>
    /// <param name="newContract">The target contract metadata. JA: newContract パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The migration result. JA: 結果を返します。</returns>
    ValueTask<MigrationResult> ApplyAsync(
        ContractMetadata oldContract,
        ContractMetadata newContract,
        CancellationToken cancellationToken);
}

/// <summary>
/// Compares two contract surfaces without applying migration.
/// JA: IContractComparer の公開契約を定義します。
/// </summary>
public interface IContractComparer
{
    /// <summary>
    /// Computes a contract diff.
    /// JA: Diff 操作を実行します。
    /// </summary>
    /// <param name="oldContract">The source contract metadata. JA: oldContract パラメーターです。</param>
    /// <param name="newContract">The target contract metadata. JA: newContract パラメーターです。</param>
    /// <returns>The contract diff. JA: 結果を返します。</returns>
    ContractDiff Diff(ContractMetadata oldContract, ContractMetadata newContract);
}
