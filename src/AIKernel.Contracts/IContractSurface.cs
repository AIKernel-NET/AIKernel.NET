using AIKernel.Dtos.Contracts;

namespace AIKernel.Contracts;

/// <summary>
/// EN: Defines a contract validation surface without replacing existing context contracts.
/// [EN] Documents this public package API member. [JA] IContractSurface の公開契約を定義します。
/// </summary>
public interface IContractSurface
{
    /// <summary>
    /// EN: Gets contract metadata including version and schema URI.
    /// [EN] Documents this public package API member. [JA] ValidateAsync 操作を実行します。
    /// </summary>
    ContractMetadata Metadata { get; }

    /// <summary>
    /// EN: Validates a contract payload reference against this contract.
    /// [EN] Documents this public package API member. [JA] ValidateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The validation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The validation result. JA: 結果を返します。</returns>
    ValueTask<ContractValidationResult> ValidateAsync(
        ContractValidationRequest request,
        CancellationToken cancellationToken);
}
