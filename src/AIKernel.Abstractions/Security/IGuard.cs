namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard 判定契約を定義します。
/// </summary>
public interface IGuardEvaluator
{
    /// <summary>
    /// 実行可能性をチェックします。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="action">実行アクション</param>
    /// <param name="resource">対象リソース</param>
    /// <returns>実行可能な場合 true</returns>
    Task<bool> CanExecuteAsync(IPrincipal principal, string action, string resource);

    /// <summary>
    /// コンテキストへのアクセス権をチェックします。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="contract">コンテキスト契約</param>
    /// <returns>アクセス可能な場合 true</returns>
    Task<bool> CanAccessContextAsync(IPrincipal principal, UnifiedContextDto contract);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく resource access 判定契約を定義します。
/// </summary>
public interface IResourceAccessGuard
{
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
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard enforcement 契約を定義します。
/// Fail-Closed 境界では、判定不能または拒否された操作を実行してはなりません。
/// </summary>
public interface IGuardEnforcer
{
    /// <summary>
    /// Guard 判定を強制し、実行継続可否を GuardAction として返します。
    /// </summary>
    /// <param name="principal">実行主体</param>
    /// <param name="action">実行アクション</param>
    /// <param name="resource">対象リソース</param>
    /// <returns>強制結果</returns>
    Task<GuardAction> EnforceAsync(IPrincipal principal, string action, string resource);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard failure handling 契約を定義します。
/// Fail-Closed 境界では、継続不能な failure mode を成功扱いしてはなりません。
/// </summary>
public interface IGuardFailureHandler
{
    /// <summary>
    /// 指定された failure mode が発生した場合の処理を実行します。
    /// </summary>
    /// <param name="mode">Failure mode</param>
    /// <param name="context">コンテキスト</param>
    Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard 互換合成契約を定義します。
/// </summary>
public interface IGuard :
    IGuardEvaluator,
    IResourceAccessGuard,
    IGuardEnforcer,
    IGuardFailureHandler
{
}
