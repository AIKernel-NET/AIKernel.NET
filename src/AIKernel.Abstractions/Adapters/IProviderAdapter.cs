using AIKernel.Dtos.Adapters;

namespace AIKernel.Abstractions.Adapters;

/// <summary>
/// Binds and validates providers at an adapter boundary.
/// JA: IProviderAdapter の公開契約を定義します。
/// </summary>
public interface IProviderAdapter
{
    /// <summary>
    /// Describes the provider adapter.
    /// JA: DescribeAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The describe request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The provider adapter descriptor. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterDescriptor> DescribeAsync(
        ProviderAdapterDescribeRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Validates the provider adapter.
    /// JA: ValidateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The validation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The validation result. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterValidationResult> ValidateAsync(
        ProviderAdapterValidationRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Binds the provider adapter.
    /// JA: BindAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The bind request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The bind result. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterBindResult> BindAsync(
        ProviderAdapterBindRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Unbinds the provider adapter.
    /// JA: UnbindAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The unbind request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The unbind result. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterUnbindResult> UnbindAsync(
        ProviderAdapterUnbindRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets provider adapter binding state.
    /// JA: GetBindingStateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The state request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The binding state snapshot. JA: 結果を返します。</returns>
    ValueTask<ProviderAdapterStateSnapshot> GetBindingStateAsync(
        ProviderAdapterStateRequest request,
        CancellationToken cancellationToken);
}
