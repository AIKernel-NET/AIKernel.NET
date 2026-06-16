namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく契約です。
/// EN: ツール実行権限を検証するための capability interface です。
/// EN: Documentation for public API. JA: IToolExecutionAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IToolExecutionAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IToolExecutionAccessValidator']" />
public interface IToolExecutionAccessValidator
{
    /// <summary>
    /// EN: ツール実行権限を検証します。
    /// EN: Documentation for public API. JA: CanExecuteTool 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="toolName">EN: Documentation for public API. JA: ツール名 toolName パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 実行が許可されている場合は true 結果を返します。</returns>
    bool CanExecuteTool(IToolPermission permission, string toolName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: ファイル読み取り権限を検証するための capability interface です。
/// EN: Documentation for public API. JA: IFileReadAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileReadAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileReadAccessValidator']" />
public interface IFileReadAccessValidator
{
    /// <summary>
    /// EN: ファイル読み取り権限を検証します。
    /// EN: Documentation for public API. JA: CanReadFile 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="filePath">EN: Documentation for public API. JA: ファイルパス filePath パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 読み取りが許可されている場合は true 結果を返します。</returns>
    bool CanReadFile(IToolPermission permission, string filePath);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: ファイル書き込み権限を検証するための capability interface です。
/// EN: Documentation for public API. JA: IFileWriteAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileWriteAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileWriteAccessValidator']" />
public interface IFileWriteAccessValidator
{
    /// <summary>
    /// EN: ファイル書き込み権限を検証します。
    /// EN: Documentation for public API. JA: CanWriteFile 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="filePath">EN: Documentation for public API. JA: ファイルパス filePath パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 書き込みが許可されている場合は true 結果を返します。</returns>
    bool CanWriteFile(IToolPermission permission, string filePath);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: ネットワークアクセス権限を検証するための capability interface です。
/// EN: Documentation for public API. JA: INetworkAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.INetworkAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.INetworkAccessValidator']" />
public interface INetworkAccessValidator
{
    /// <summary>
    /// EN: ネットワークアクセス権限を検証します。
    /// EN: Documentation for public API. JA: CanAccessNetwork 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="host">EN: Documentation for public API. JA: ホスト名またはURL host パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: アクセスが許可されている場合は true 結果を返します。</returns>
    bool CanAccessNetwork(IToolPermission permission, string host);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: 環境変数アクセス権限を検証するための capability interface です。
/// EN: Documentation for public API. JA: IEnvironmentAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IEnvironmentAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IEnvironmentAccessValidator']" />
public interface IEnvironmentAccessValidator
{
    /// <summary>
    /// EN: 環境変数アクセス権限を検証します。
    /// EN: Documentation for public API. JA: CanAccessEnvironment 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="variableName">EN: Documentation for public API. JA: 環境変数名 variableName パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: アクセスが許可されている場合は true 結果を返します。</returns>
    bool CanAccessEnvironment(IToolPermission permission, string variableName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: システムコマンド実行権限を検証するための capability interface です。
/// EN: Documentation for public API. JA: ISystemCommandAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISystemCommandAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISystemCommandAccessValidator']" />
public interface ISystemCommandAccessValidator
{
    /// <summary>
    /// EN: システムコマンド実行権限を検証します。
    /// EN: Documentation for public API. JA: CanExecuteSystemCommand 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="commandName">EN: Documentation for public API. JA: コマンド名 commandName パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 実行が許可されている場合は true 結果を返します。</returns>
    bool CanExecuteSystemCommand(IToolPermission permission, string commandName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: 権限定義そのものの妥当性を検証するための capability interface です。
/// EN: Documentation for public API. JA: IPermissionLifecycleValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionLifecycleValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionLifecycleValidator']" />
public interface IPermissionLifecycleValidator
{
    /// <summary>
    /// EN: 権限が有効期限内かどうかを確認します。
    /// EN: Documentation for public API. JA: IsPermissionValid 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 有効期限内の場合は true 結果を返します。</returns>
    bool IsPermissionValid(IToolPermission permission);
}

/// <summary>
/// UC-21 に基づく契約です。
/// EN: 実行時コンテキストを含めた制約を検証するための capability interface です。
/// EN: Documentation for public API. JA: IPermissionConstraintValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionConstraintValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionConstraintValidator']" />
public interface IPermissionConstraintValidator
{
    /// <summary>
    /// EN: 権限がすべての制約条件を満たしているかどうかを検証します。
    /// EN: Documentation for public API. JA: ValidateConstraints 操作を実行します。
    /// </summary>
    /// <param name="permission">EN: Documentation for public API. JA: 検証対象の権限 permission パラメーターです。</param>
    /// <param name="context">EN: Documentation for public API. JA: 実行コンテキスト情報 context パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: すべての制約を満たしている場合は true 結果を返します。</returns>
    bool ValidateConstraints(IToolPermission permission, IReadOnlyDictionary<string, string> context);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ツールアクセス権限を検証するための互換合成インターフェースです。
/// IToolPermission の検証と評価を担当し、Abstractions レイヤーでは
/// インターフェース定義に徹します。具体的なビルダー実装は
/// EN: 実装リポジトリで提供されます。
/// EN: Documentation for public API. JA: IToolAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IToolAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IToolAccessValidator']" />
public interface IToolAccessValidator :
    IToolExecutionAccessValidator,
    IFileReadAccessValidator,
    IFileWriteAccessValidator,
    INetworkAccessValidator,
    IEnvironmentAccessValidator,
    ISystemCommandAccessValidator,
    IPermissionLifecycleValidator,
    IPermissionConstraintValidator
{
}
