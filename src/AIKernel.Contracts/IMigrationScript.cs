using AIKernel.Dtos.Contracts;

namespace AIKernel.Contracts;

/// <summary>
/// EN: Applies a migration between two contract surfaces.
/// [EN] Documents this public package API member. [JA] IMigrationScript の公開契約を定義します。
/// </summary>
public interface IMigrationScript
{
    /// <summary>
    /// EN: Applies migration from an old contract to a new contract.
    /// [EN] Documents this public package API member. [JA] ApplyAsync 操作を実行します。
    /// </summary>
    /// <param name="oldContract">EN: The source contract metadata. JA: oldContract パラメーターです。</param>
    /// <param name="newContract">EN: The target contract metadata. JA: newContract パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The migration result. JA: 結果を返します。</returns>
    ValueTask<MigrationResult> ApplyAsync(
        ContractMetadata oldContract,
        ContractMetadata newContract,
        CancellationToken cancellationToken);
}

/// <summary>
/// EN: Compares two contract surfaces without applying migration.
/// [EN] Documents this public package API member. [JA] IContractComparer の公開契約を定義します。
/// </summary>
public interface IContractComparer
{
    /// <summary>
    /// EN: Computes a contract diff.
    /// [EN] Documents this public package API member. [JA] Diff 操作を実行します。
    /// </summary>
    /// <param name="oldContract">EN: The source contract metadata. JA: oldContract パラメーターです。</param>
    /// <param name="newContract">EN: The target contract metadata. JA: newContract パラメーターです。</param>
    /// <returns>EN: The contract diff. JA: 結果を返します。</returns>
    ContractDiff Diff(ContractMetadata oldContract, ContractMetadata newContract);
}
