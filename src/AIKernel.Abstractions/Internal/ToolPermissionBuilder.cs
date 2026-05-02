namespace AIKernel.Abstractions.Internal;

/// <summary>
/// ツール権限をフルエント API で構築するビルダーです。
/// Abstractions レイヤーの純度を保つため、このクラスはInternal名前空間に隠蔽されています。
/// 実装リポジトリから DI 経由で利用されることを想定しています。
/// </summary>
internal sealed class ToolPermissionBuilder
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

    /// <summary>
    /// デフォルトの IToolPermission 実装です。
    /// </summary>
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
