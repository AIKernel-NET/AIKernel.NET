using AIKernel.Dtos.Contracts;

namespace AIKernel.Contracts;

/// <summary>
/// Defines a contract validation surface without replacing existing context contracts.
/// JA: IContractSurface の公開契約を定義します。
/// </summary>
public interface IContractSurface
{
    /// <summary>
    /// Gets contract metadata including version and schema URI.
    /// JA: ValidateAsync 操作を実行します。
    /// </summary>
    ContractMetadata Metadata { get; }

    /// <summary>
    /// Validates a contract payload reference against this contract.
    /// JA: ValidateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The validation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The validation result. JA: 結果を返します。</returns>
    ValueTask<ContractValidationResult> ValidateAsync(
        ContractValidationRequest request,
        CancellationToken cancellationToken);
}
