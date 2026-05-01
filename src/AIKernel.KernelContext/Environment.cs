namespace AIKernel.KernelContext;

/// <summary>
/// 環境情報を表現します。
/// 実行環境の設定と特性を定義します。
/// </summary>
public sealed class Environment
{
    /// <summary>
    /// 環境の一意識別子を取得または設定します。
    /// </summary>
    public required string EnvironmentId { get; init; }

    /// <summary>
    /// 環境の名前を取得または設定します。
    /// （例: "production", "staging", "development"）
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 地域を取得または設定します。
    /// </summary>
    public string? Region { get; init; }

    /// <summary>
    /// 環境変数を取得または設定します。
    /// </summary>
    public Dictionary<string, string>? Variables { get; init; }

    /// <summary>
    /// 構成設定を取得または設定します。
    /// </summary>
    public Dictionary<string, object>? Configuration { get; init; }

    /// <summary>
    /// 環境が本番環境かどうかを取得または設定します。
    /// </summary>
    public bool IsProduction { get; init; }
}
