namespace AIKernel.Abstractions;

/// <summary>
/// ツールアクセス権限を検証するためのインターフェースです。
/// IToolPermission の検証と評価を担当し、Abstractions レイヤーでは
/// インターフェース定義に徹します。具体的なビルダー実装は
/// 実装リポジトリで提供されます。
/// </summary>
public interface IToolAccessValidator
{
    /// <summary>
    /// ツール実行権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="toolName">ツール名</param>
    /// <returns>実行が許可されている場合は true</returns>
    bool CanExecuteTool(IToolPermission permission, string toolName);

    /// <summary>
    /// ファイル読み取り権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>読み取りが許可されている場合は true</returns>
    bool CanReadFile(IToolPermission permission, string filePath);

    /// <summary>
    /// ファイル書き込み権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>書き込みが許可されている場合は true</returns>
    bool CanWriteFile(IToolPermission permission, string filePath);

    /// <summary>
    /// ネットワークアクセス権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="host">ホスト名またはURL</param>
    /// <returns>アクセスが許可されている場合は true</returns>
    bool CanAccessNetwork(IToolPermission permission, string host);

    /// <summary>
    /// 環境変数アクセス権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="variableName">環境変数名</param>
    /// <returns>アクセスが許可されている場合は true</returns>
    bool CanAccessEnvironment(IToolPermission permission, string variableName);

    /// <summary>
    /// システムコマンド実行権限を検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="commandName">コマンド名</param>
    /// <returns>実行が許可されている場合は true</returns>
    bool CanExecuteSystemCommand(IToolPermission permission, string commandName);

    /// <summary>
    /// 権限が有効期限内かどうかを確認します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <returns>有効期限内の場合は true</returns>
    bool IsPermissionValid(IToolPermission permission);

    /// <summary>
    /// 権限がすべての制約条件を満たしているかどうかを検証します。
    /// </summary>
    /// <param name="permission">検証対象の権限</param>
    /// <param name="context">実行コンテキスト情報</param>
    /// <returns>すべての制約を満たしている場合は true</returns>
    bool ValidateConstraints(IToolPermission permission, Dictionary<string, object> context);
}
