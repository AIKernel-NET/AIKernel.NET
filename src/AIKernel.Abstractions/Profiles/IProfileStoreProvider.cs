using AIKernel.Dtos.Profiles;

namespace AIKernel.Abstractions.Profiles;

/// <summary>
/// EN: Loads, saves, lists, versions, and validates profiles.
/// EN: Documentation for public API. JA: IProfileStoreProvider の公開契約を定義します。
/// </summary>
public interface IProfileStoreProvider
{
    /// <summary>
    /// EN: Loads a profile.
    /// EN: Documentation for public API. JA: LoadAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The load request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The load result. JA: 結果を返します。</returns>
    ValueTask<ProfileLoadResult> LoadAsync(
        ProfileLoadRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Saves a profile.
    /// EN: Documentation for public API. JA: SaveAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The save request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The save result. JA: 結果を返します。</returns>
    ValueTask<ProfileSaveResult> SaveAsync(
        ProfileSaveRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Lists profiles.
    /// EN: Documentation for public API. JA: ListAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The list request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The list result. JA: 結果を返します。</returns>
    ValueTask<ProfileListResult> ListAsync(
        ProfileListRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Gets a profile version.
    /// EN: Documentation for public API. JA: GetVersionAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The version request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The version result. JA: 結果を返します。</returns>
    ValueTask<ProfileVersionResult> GetVersionAsync(
        ProfileVersionRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// EN: Validates a profile.
    /// EN: Documentation for public API. JA: ValidateAsync 操作を実行します。
    /// </summary>
    /// <param name="request">EN: The validation request. JA: request パラメーターです。</param>
    /// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: The validation result. JA: 結果を返します。</returns>
    ValueTask<ProfileValidationResult> ValidateAsync(
        ProfileValidationRequest request,
        CancellationToken cancellationToken);
}
