namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard 契約を定義します。
/// </summary>
public interface IGuard
{
    /// <summary>
    /// 実行可能性をチェックします。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="action">実行アクション</param>
    /// <param name="resource">対象リソース</param>
    /// <returns>実行可能な場合 true</returns>
    /// <exception cref="ArgumentException">action または resource が不正な場合にスローされます。</exception>
    Task<bool> CanExecuteAsync(IPrincipal principal, string action, string resource);

    /// <summary>
    /// コンテキストへのアクセス権をチェックします。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="contract">コンテキスト契約</param>
    /// <returns>アクセス可能な場合 true</returns>
    /// <exception cref="ArgumentNullException">principal または contract が null の場合にスローされます。</exception>
    Task<bool> CanAccessContextAsync(IPrincipal principal, UnifiedContextDto contract);

    /// <summary>
    /// リソースの読み取り権をチェックします。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="resource">リソース</param>
    /// <returns>読み取り可能な場合 true</returns>
    Task<bool> CanReadAsync(IPrincipal principal, string resource);

    /// <summary>
    /// リソースの書き込み権をチェックします。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="resource">リソース</param>
    /// <returns>書き込み可能な場合 true</returns>
    Task<bool> CanWriteAsync(IPrincipal principal, string resource);

    /// <summary>
    /// 指定された failure mode が発生した場合の処理を実行します。
    /// </summary>
    /// <param name="mode">Failure mode</param>
    /// <param name="context">コンテキスト</param>
    /// <exception cref="InvalidOperationException">Fail-Closed ポリシーにより継続不能と判定された場合にスローされます。</exception>
    Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context);
}


