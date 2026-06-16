using AIKernel.Dtos.Adapters;

namespace AIKernel.Abstractions.Adapters;

/// <summary>
/// EN: Binds and validates providers at an adapter boundary.
/// EN: Documentation for public API. JA: IProviderAdapter の公開契約を定義します。
/// </summary>
public interface IProviderAdapter
{
    /// <summary>
    /// EN: Describes the provider adapter.
    /// EN: Documentation for public API. JA: DescribeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The describe request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The provider adapter descriptor. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterDescriptor> DescribeAsync(
        ProviderAdapterDescribeRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Validates the provider adapter.
    /// EN: Documentation for public API. JA: ValidateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The validation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The validation result. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterValidationResult> ValidateAsync(
        ProviderAdapterValidationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Binds the provider adapter.
    /// EN: Documentation for public API. JA: BindAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The bind request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The bind result. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterBindResult> BindAsync(
        ProviderAdapterBindRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Unbinds the provider adapter.
    /// EN: Documentation for public API. JA: UnbindAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The unbind request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The unbind result. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterUnbindResult> UnbindAsync(
        ProviderAdapterUnbindRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets provider adapter binding state.
    /// EN: Documentation for public API. JA: GetBindingStateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The state request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The binding state snapshot. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterStateSnapshot> GetBindingStateAsync(
        ProviderAdapterStateRequest request,
        CancellationToken cancellationToken);
}
