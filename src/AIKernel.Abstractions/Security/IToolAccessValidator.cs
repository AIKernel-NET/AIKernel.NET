namespace AIKernel.Abstractions.Security;

/// <summary>
/// UC-21 に基づく契約です。
/// ツール実行権限を検証するための capability interface です。
/// </summary>
public interface IToolExecutionAccessValidator
{
    /// <summary>
    /// ツール実行権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="toolName">ツール名</param>
    /// <returns>実行が許可されている場合は true</returns>
    bool CanExecuteTool(IToolPermission permission, string toolName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ファイル読み取り権限を検証するための capability interface です。
/// </summary>
public interface IFileReadAccessValidator
{
    /// <summary>
    /// ファイル読み取り権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>読み取りが許可されている場合は true</returns>
    bool CanReadFile(IToolPermission permission, string filePath);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ファイル書き込み権限を検証するための capability interface です。
/// </summary>
public interface IFileWriteAccessValidator
{
    /// <summary>
    /// ファイル書き込み権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>書き込みが許可されている場合は true</returns>
    bool CanWriteFile(IToolPermission permission, string filePath);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ネットワークアクセス権限を検証するための capability interface です。
/// </summary>
public interface INetworkAccessValidator
{
    /// <summary>
    /// ネットワークアクセス権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="host">ホスト名またはURL</param>
    /// <returns>アクセスが許可されている場合は true</returns>
    bool CanAccessNetwork(IToolPermission permission, string host);
}

/// <summary>
/// UC-21 に基づく契約です。
/// 環境変数アクセス権限を検証するための capability interface です。
/// </summary>
public interface IEnvironmentAccessValidator
{
    /// <summary>
    /// 環境変数アクセス権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="variableName">環境変数名</param>
    /// <returns>アクセスが許可されている場合は true</returns>
    bool CanAccessEnvironment(IToolPermission permission, string variableName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// システムコマンド実行権限を検証するための capability interface です。
/// </summary>
public interface ISystemCommandAccessValidator
{
    /// <summary>
    /// システムコマンド実行権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="commandName">コマンド名</param>
    /// <returns>実行が許可されている場合は true</returns>
    bool CanExecuteSystemCommand(IToolPermission permission, string commandName);
}

/// <summary>
/// UC-21 に基づく契約です。
/// 権限定義そのものの妥当性を検証するための capability interface です。
/// </summary>
public interface IPermissionLifecycleValidator
{
    /// <summary>
    /// 権限が有効期限内かどうかを確認します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <returns>有効期限内の場合は true</returns>
    bool IsPermissionValid(IToolPermission permission);
}

/// <summary>
/// UC-21 に基づく契約です。
/// 実行時コンテキストを含めた制約を検証するための capability interface です。
/// </summary>
public interface IPermissionConstraintValidator
{
    /// <summary>
    /// 権限がすべての制約条件を満たしているかどうかを検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="context">実行コンテキスト情報</param>
    /// <returns>すべての制約を満たしている場合は true</returns>
    bool ValidateConstraints(IToolPermission permission, IReadOnlyDictionary<string, string> context);
}

/// <summary>
/// UC-21 に基づく契約です。
/// ツールアクセス権限を検証するための互換合成インターフェースです。
/// IToolPermission の検証と評価を担当し、Abstractions レイヤーでは
/// インターフェース定義に徹します。具体的なビルダー実装は
/// 実装リポジトリで提供されます。
/// </summary>
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
