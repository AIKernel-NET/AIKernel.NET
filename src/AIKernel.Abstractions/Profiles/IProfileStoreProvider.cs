using AIKernel.Dtos.Profiles;

namespace AIKernel.Abstractions.Profiles;

/// <summary>
/// Loads, saves, lists, versions, and validates profiles.
/// JA: IProfileStoreProvider の公開契約を定義します。
/// </summary>
public interface IProfileStoreProvider
{
    /// <summary>
    /// Loads a profile.
    /// JA: LoadAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The load request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The load result. JA: 結果を返します。</returns>
    ValueTask<ProfileLoadResult> LoadAsync(
        ProfileLoadRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Saves a profile.
    /// JA: SaveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The save request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The save result. JA: 結果を返します。</returns>
    ValueTask<ProfileSaveResult> SaveAsync(
        ProfileSaveRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Lists profiles.
    /// JA: ListAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The list request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The list result. JA: 結果を返します。</returns>
    ValueTask<ProfileListResult> ListAsync(
        ProfileListRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Gets a profile version.
    /// JA: GetVersionAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The version request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The version result. JA: 結果を返します。</returns>
    ValueTask<ProfileVersionResult> GetVersionAsync(
        ProfileVersionRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Validates a profile.
    /// JA: ValidateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">The validation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>The validation result. JA: 結果を返します。</returns>
    ValueTask<ProfileValidationResult> ValidateAsync(
        ProfileValidationRequest request,
        CancellationToken cancellationToken);
}
