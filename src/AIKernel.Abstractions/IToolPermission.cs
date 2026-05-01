namespace AIKernel.Abstractions;

/// <summary>
/// ツール実行権限を定義します。
/// セキュリティコンテキストに基づいた権限管理を行います。
/// </summary>
public interface IToolPermission
{
    /// <summary>
    /// 権限の一意識別子を取得します。
    /// </summary>
    string PermissionId { get; }

    /// <summary>
    /// ツール実行を許可しているかどうかを確認します。
    /// </summary>
    bool CanExecuteTool { get; }

    /// <summary>
    /// ファイル読み取り権限があるかどうかを確認します。
    /// </summary>
    bool CanReadFiles { get; }

    /// <summary>
    /// ファイル書き込み権限があるかどうかを確認します。
    /// </summary>
    bool CanWriteFiles { get; }

    /// <summary>
    /// ネットワークアクセス権限があるかどうかを確認します。
    /// </summary>
    bool CanAccessNetwork { get; }

    /// <summary>
    /// 環境変数アクセス権限があるかどうかを確認します。
    /// </summary>
    bool CanAccessEnvironment { get; }

    /// <summary>
    /// システムコマンド実行権限があるかどうかを確認します。
    /// </summary>
    bool CanExecuteSystemCommands { get; }

    /// <summary>
    /// 特定のリソースへのアクセス権限を確認します。
    /// </summary>
    /// <param name="resourcePath">リソースパス</param>
    /// <returns>アクセス権限がある場合は true</returns>
    bool HasResourceAccess(string resourcePath);

    /// <summary>
    /// 権限の有効期限を取得します。
    /// </summary>
    DateTime? ExpiresAt { get; }

    /// <summary>
    /// 権限の有効期限が切れているかどうかを確認します。
    /// </summary>
    bool IsExpired { get; }

    /// <summary>
    /// 権限の制約条件を取得します。
    /// </summary>
    IReadOnlyList<PermissionConstraint> Constraints { get; }
}

/// <summary>
/// 権限の制約条件を表現します。
/// </summary>
public sealed class PermissionConstraint
{
    /// <summary>
    /// 制約の種類を取得または設定します。
    /// </summary>
    public required string ConstraintType { get; init; }

    /// <summary>
    /// 制約の値を取得または設定します。
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// 制約の説明を取得または設定します。
    /// </summary>
    public string? Description { get; init; }
}

/// <summary>
/// ツール権限ビルダーを提供します。
/// </summary>
public sealed class ToolPermissionBuilder
{
    private bool _canExecuteTool = false;
    private bool _canReadFiles = false;
    private bool _canWriteFiles = false;
    private bool _canAccessNetwork = false;
    private bool _canAccessEnvironment = false;
    private bool _canExecuteSystemCommands = false;
    private DateTime? _expiresAt = null;
    private readonly List<PermissionConstraint> _constraints = new();
    private readonly HashSet<string> _allowedPaths = new();

    /// <summary>
    /// ツール実行権限を付与します。
    /// </summary>
    public ToolPermissionBuilder AllowToolExecution()
    {
        _canExecuteTool = true;
        return this;
    }

    /// <summary>
    /// ファイル読み取り権限を付与します。
    /// </summary>
    public ToolPermissionBuilder AllowFileReading(params string[] paths)
    {
        _canReadFiles = true;
        foreach (var path in paths)
        {
            _allowedPaths.Add(path);
        }
        return this;
    }

    /// <summary>
    /// ファイル書き込み権限を付与します。
    /// </summary>
    public ToolPermissionBuilder AllowFileWriting(params string[] paths)
    {
        _canWriteFiles = true;
        foreach (var path in paths)
        {
            _allowedPaths.Add(path);
        }
        return this;
    }

    /// <summary>
    /// ネットワークアクセス権限を付与します。
    /// </summary>
    public ToolPermissionBuilder AllowNetworkAccess()
    {
        _canAccessNetwork = true;
        return this;
    }

    /// <summary>
    /// 環境変数アクセス権限を付与します。
    /// </summary>
    public ToolPermissionBuilder AllowEnvironmentAccess()
    {
        _canAccessEnvironment = true;
        return this;
    }

    /// <summary>
    /// システムコマンド実行権限を付与します。
    /// </summary>
    public ToolPermissionBuilder AllowSystemCommands()
    {
        _canExecuteSystemCommands = true;
        return this;
    }

    /// <summary>
    /// 権限の有効期限を設定します。
    /// </summary>
    public ToolPermissionBuilder WithExpiration(DateTime expiresAt)
    {
        _expiresAt = expiresAt;
        return this;
    }

    /// <summary>
    /// 権限に制約条件を追加します。
    /// </summary>
    public ToolPermissionBuilder AddConstraint(string constraintType, string value, string? description = null)
    {
        _constraints.Add(new PermissionConstraint
        {
            ConstraintType = constraintType,
            Value = value,
            Description = description
        });
        return this;
    }

    /// <summary>
    /// 権限オブジェクトをビルドします。
    /// </summary>
    public IToolPermission Build()
    {
        return new DefaultToolPermission(
            _canExecuteTool,
            _canReadFiles,
            _canWriteFiles,
            _canAccessNetwork,
            _canAccessEnvironment,
            _canExecuteSystemCommands,
            _expiresAt,
            _constraints,
            _allowedPaths);
    }

    private sealed class DefaultToolPermission : IToolPermission
    {
        private readonly HashSet<string> _allowedPaths;

        public string PermissionId { get; } = Guid.NewGuid().ToString();
        public bool CanExecuteTool { get; }
        public bool CanReadFiles { get; }
        public bool CanWriteFiles { get; }
        public bool CanAccessNetwork { get; }
        public bool CanAccessEnvironment { get; }
        public bool CanExecuteSystemCommands { get; }
        public DateTime? ExpiresAt { get; }
        public IReadOnlyList<PermissionConstraint> Constraints { get; }

        public bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value < DateTime.UtcNow;

        public DefaultToolPermission(
            bool canExecuteTool,
            bool canReadFiles,
            bool canWriteFiles,
            bool canAccessNetwork,
            bool canAccessEnvironment,
            bool canExecuteSystemCommands,
            DateTime? expiresAt,
            List<PermissionConstraint> constraints,
            HashSet<string> allowedPaths)
        {
            CanExecuteTool = canExecuteTool;
            CanReadFiles = canReadFiles;
            CanWriteFiles = canWriteFiles;
            CanAccessNetwork = canAccessNetwork;
            CanAccessEnvironment = canAccessEnvironment;
            CanExecuteSystemCommands = canExecuteSystemCommands;
            ExpiresAt = expiresAt;
            Constraints = constraints.AsReadOnly();
            _allowedPaths = allowedPaths;
        }

        public bool HasResourceAccess(string resourcePath)
        {
            if (_allowedPaths.Count == 0)
                return true; // 制限がない場合はアクセス許可

            return _allowedPaths.Any(allowed =>
                resourcePath.StartsWith(allowed, StringComparison.OrdinalIgnoreCase));
        }
    }
}
