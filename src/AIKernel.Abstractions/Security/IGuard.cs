namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard 判定契約を定義します。
/// JA: IGuardEvaluator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEvaluator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEvaluator']" />
public interface IGuardEvaluator
{
    /// <summary>
    /// 実行可能性をチェックします。
    /// JA: CanExecuteAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">実行主体 JA: principal パラメーターです。</param>
    /// <param name="action">実行アクション JA: action パラメーターです。</param>
    /// <param name="resource">対象リソース JA: resource パラメーターです。</param>
    /// <returns>実行可能な場合 true JA: 結果を返します。</returns>
    Task<bool> CanExecuteAsync(IPrincipal principal, string action, string resource);

    /// <summary>
    /// コンテキストへのアクセス権をチェックします。
    /// JA: CanAccessContextAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">実行主体 JA: principal パラメーターです。</param>
    /// <param name="contract">コンテキスト契約 JA: contract パラメーターです。</param>
    /// <returns>アクセス可能な場合 true JA: 結果を返します。</returns>
    Task<bool> CanAccessContextAsync(IPrincipal principal, UnifiedContextDto contract);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく resource access 判定契約を定義します。
/// JA: IResourceAccessGuard の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IResourceAccessGuard']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IResourceAccessGuard']" />
public interface IResourceAccessGuard
{
    /// <summary>
    /// リソースの読み取り権をチェックします。
    /// JA: CanReadAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">実行主体 JA: principal パラメーターです。</param>
    /// <param name="resource">リソース JA: resource パラメーターです。</param>
    /// <returns>読み取り可能な場合 true JA: 結果を返します。</returns>
    Task<bool> CanReadAsync(IPrincipal principal, string resource);

    /// <summary>
    /// リソースの書き込み権をチェックします。
    /// JA: CanWriteAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">実行主体 JA: principal パラメーターです。</param>
    /// <param name="resource">リソース JA: resource パラメーターです。</param>
    /// <returns>書き込み可能な場合 true JA: 結果を返します。</returns>
    Task<bool> CanWriteAsync(IPrincipal principal, string resource);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard enforcement 契約を定義します。
/// Fail-Closed 境界では、判定不能または拒否された操作を実行してはなりません。
/// JA: IGuardEnforcer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEnforcer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEnforcer']" />
public interface IGuardEnforcer
{
    /// <summary>
    /// Guard 判定を強制し、実行継続可否を GuardAction として返します。
    /// JA: EnforceAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">実行主体 JA: principal パラメーターです。</param>
    /// <param name="action">実行アクション JA: action パラメーターです。</param>
    /// <param name="resource">対象リソース JA: resource パラメーターです。</param>
    /// <returns>強制結果 JA: 結果を返します。</returns>
    Task<GuardAction> EnforceAsync(IPrincipal principal, string action, string resource);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard failure handling 契約を定義します。
/// Fail-Closed 境界では、継続不能な failure mode を成功扱いしてはなりません。
/// JA: IGuardFailureHandler の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardFailureHandler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardFailureHandler']" />
public interface IGuardFailureHandler
{
    /// <summary>
    /// 指定された failure mode が発生した場合の処理を実行します。
    /// JA: OnFailureModeDetectedAsync 操作を実行します。
    /// </summary>
    /// <param name="mode">Failure mode JA: mode パラメーターです。</param>
    /// <param name="context">コンテキスト JA: context パラメーターです。</param>
    Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard 互換合成契約を定義します。
/// JA: IGuard の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuard']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuard']" />
public interface IGuard :
    IGuardEvaluator,
    IResourceAccessGuard,
    IGuardEnforcer,
    IGuardFailureHandler
{
}
