namespace AIKernel.Abstractions.Security;

/// <summary>
/// EN: UC-21（マテリアル検疫とポリシー実行）に基づく Guard 判定契約を定義します。
/// [EN] Documents this public package API member. [JA] IGuardEvaluator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEvaluator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEvaluator']" />
public interface IGuardEvaluator
{
    /// <summary>
    /// EN: 実行可能性をチェックします。
    /// [EN] Documents this public package API member. [JA] CanExecuteAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">[EN] Documents this public package API member. [JA] 実行主体 principal パラメーターです。</param>
    /// <param name="action">[EN] Documents this public package API member. [JA] 実行アクション action パラメーターです。</param>
    /// <param name="resource">[EN] Documents this public package API member. [JA] 対象リソース resource パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 実行可能な場合 true 結果を返します。</returns>
    Task<bool> CanExecuteAsync(IPrincipal principal, string action, string resource);

    /// <summary>
    /// EN: コンテキストへのアクセス権をチェックします。
    /// [EN] Documents this public package API member. [JA] CanAccessContextAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">[EN] Documents this public package API member. [JA] 実行主体 principal パラメーターです。</param>
    /// <param name="contract">[EN] Documents this public package API member. [JA] コンテキスト契約 contract パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] アクセス可能な場合 true 結果を返します。</returns>
    Task<bool> CanAccessContextAsync(IPrincipal principal, UnifiedContextDto contract);
}

/// <summary>
/// EN: UC-21（マテリアル検疫とポリシー実行）に基づく resource access 判定契約を定義します。
/// [EN] Documents this public package API member. [JA] IResourceAccessGuard の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IResourceAccessGuard']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IResourceAccessGuard']" />
public interface IResourceAccessGuard
{
    /// <summary>
    /// EN: リソースの読み取り権をチェックします。
    /// [EN] Documents this public package API member. [JA] CanReadAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">[EN] Documents this public package API member. [JA] 実行主体 principal パラメーターです。</param>
    /// <param name="resource">[EN] Documents this public package API member. [JA] リソース resource パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 読み取り可能な場合 true 結果を返します。</returns>
    Task<bool> CanReadAsync(IPrincipal principal, string resource);

    /// <summary>
    /// EN: リソースの書き込み権をチェックします。
    /// [EN] Documents this public package API member. [JA] CanWriteAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">[EN] Documents this public package API member. [JA] 実行主体 principal パラメーターです。</param>
    /// <param name="resource">[EN] Documents this public package API member. [JA] リソース resource パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 書き込み可能な場合 true 結果を返します。</returns>
    Task<bool> CanWriteAsync(IPrincipal principal, string resource);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard enforcement 契約を定義します。
/// EN: Fail-Closed 境界では、判定不能または拒否された操作を実行してはなりません。
/// [EN] Documents this public package API member. [JA] IGuardEnforcer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEnforcer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardEnforcer']" />
public interface IGuardEnforcer
{
    /// <summary>
    /// EN: Guard 判定を強制し、実行継続可否を GuardAction として返します。
    /// [EN] Documents this public package API member. [JA] EnforceAsync 操作を実行します。
    /// </summary>
    /// <param name="principal">[EN] Documents this public package API member. [JA] 実行主体 principal パラメーターです。</param>
    /// <param name="action">[EN] Documents this public package API member. [JA] 実行アクション action パラメーターです。</param>
    /// <param name="resource">[EN] Documents this public package API member. [JA] 対象リソース resource パラメーターです。</param>
    /// <returns>[EN] Documents this public package API member. [JA] 強制結果 結果を返します。</returns>
    Task<GuardAction> EnforceAsync(IPrincipal principal, string action, string resource);
}

/// <summary>
/// UC-21（マテリアル検疫とポリシー実行）に基づく Guard failure handling 契約を定義します。
/// EN: Fail-Closed 境界では、継続不能な failure mode を成功扱いしてはなりません。
/// [EN] Documents this public package API member. [JA] IGuardFailureHandler の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardFailureHandler']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IGuardFailureHandler']" />
public interface IGuardFailureHandler
{
    /// <summary>
    /// EN: 指定された failure mode が発生した場合の処理を実行します。
    /// [EN] Documents this public package API member. [JA] OnFailureModeDetectedAsync 操作を実行します。
    /// </summary>
    /// <param name="mode">EN: Failure mode JA: mode パラメーターです。</param>
    /// <param name="context">[EN] Documents this public package API member. [JA] コンテキスト context パラメーターです。</param>
    Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context);
}

/// <summary>
/// EN: UC-21（マテリアル検疫とポリシー実行）に基づく Guard 互換合成契約を定義します。
/// [EN] Documents this public package API member. [JA] IGuard の公開契約を定義します。
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
