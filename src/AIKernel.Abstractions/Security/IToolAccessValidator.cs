namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく契約です。
/// ツール実行権限を検証するための capability interface です。
/// JA: IToolExecutionAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IToolExecutionAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IToolExecutionAccessValidator']" />
public interface IToolExecutionAccessValidator
{
    /// <summary>
    /// ツール実行権限を検証します。
    /// JA: CanExecuteTool 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="toolName">ツール名 JA: toolName パラメーターです。</param>
    /// <returns>実行が許可されている場合は true JA: 結果を返します。</returns>
    bool CanExecuteTool(IToolPermission permission, string toolName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ファイル読み取り権限を検証するための capability interface です。
/// JA: IFileReadAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileReadAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileReadAccessValidator']" />
public interface IFileReadAccessValidator
{
    /// <summary>
    /// ファイル読み取り権限を検証します。
    /// JA: CanReadFile 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="filePath">ファイルパス JA: filePath パラメーターです。</param>
    /// <returns>読み取りが許可されている場合は true JA: 結果を返します。</returns>
    bool CanReadFile(IToolPermission permission, string filePath);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ファイル書き込み権限を検証するための capability interface です。
/// JA: IFileWriteAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileWriteAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IFileWriteAccessValidator']" />
public interface IFileWriteAccessValidator
{
    /// <summary>
    /// ファイル書き込み権限を検証します。
    /// JA: CanWriteFile 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="filePath">ファイルパス JA: filePath パラメーターです。</param>
    /// <returns>書き込みが許可されている場合は true JA: 結果を返します。</returns>
    bool CanWriteFile(IToolPermission permission, string filePath);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ネットワークアクセス権限を検証するための capability interface です。
/// JA: INetworkAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.INetworkAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.INetworkAccessValidator']" />
public interface INetworkAccessValidator
{
    /// <summary>
    /// ネットワークアクセス権限を検証します。
    /// JA: CanAccessNetwork 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="host">ホスト名またはURL JA: host パラメーターです。</param>
    /// <returns>アクセスが許可されている場合は true JA: 結果を返します。</returns>
    bool CanAccessNetwork(IToolPermission permission, string host);
}

/// <summary>
/// UC-21 に基づく契約です。
/// 環境変数アクセス権限を検証するための capability interface です。
/// JA: IEnvironmentAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IEnvironmentAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IEnvironmentAccessValidator']" />
public interface IEnvironmentAccessValidator
{
    /// <summary>
    /// 環境変数アクセス権限を検証します。
    /// JA: CanAccessEnvironment 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="variableName">環境変数名 JA: variableName パラメーターです。</param>
    /// <returns>アクセスが許可されている場合は true JA: 結果を返します。</returns>
    bool CanAccessEnvironment(IToolPermission permission, string variableName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// システムコマンド実行権限を検証するための capability interface です。
/// JA: ISystemCommandAccessValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISystemCommandAccessValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.ISystemCommandAccessValidator']" />
public interface ISystemCommandAccessValidator
{
    /// <summary>
    /// システムコマンド実行権限を検証します。
    /// JA: CanExecuteSystemCommand 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="commandName">コマンド名 JA: commandName パラメーターです。</param>
    /// <returns>実行が許可されている場合は true JA: 結果を返します。</returns>
    bool CanExecuteSystemCommand(IToolPermission permission, string commandName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// 権限定義そのものの妥当性を検証するための capability interface です。
/// JA: IPermissionLifecycleValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionLifecycleValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionLifecycleValidator']" />
public interface IPermissionLifecycleValidator
{
    /// <summary>
    /// 権限が有効期限内かどうかを確認します。
    /// JA: IsPermissionValid 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <returns>有効期限内の場合は true JA: 結果を返します。</returns>
    bool IsPermissionValid(IToolPermission permission);
}

/// <summary>
/// UC-21 に基づく契約です。
/// 実行時コンテキストを含めた制約を検証するための capability interface です。
/// JA: IPermissionConstraintValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionConstraintValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Security.IPermissionConstraintValidator']" />
public interface IPermissionConstraintValidator
{
    /// <summary>
    /// 権限がすべての制約条件を満たしているかどうかを検証します。
    /// JA: ValidateConstraints 操作を実行します。
    /// </summary>
    /// <param name="permission">検証対象の権限 JA: permission パラメーターです。</param>
    /// <param name="context">実行コンテキスト情報 JA: context パラメーターです。</param>
    /// <returns>すべての制約を満たしている場合は true JA: 結果を返します。</returns>
    bool ValidateConstraints(IToolPermission permission, IReadOnlyDictionary<string, string> context);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ツールアクセス権限を検証するための互換合成インターフェースです。
/// IToolPermission の検証と評価を担当し、Abstractions レイヤーでは
/// インターフェース定義に徹します。具体的なビルダー実装は
/// 実装リポジトリで提供されます。
/// JA: IToolAccessValidator の公開契約を定義します。
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
