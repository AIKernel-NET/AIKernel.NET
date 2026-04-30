using AIKernel.Contracts;
using AIKernel.Enums;

namespace AIKernel.Abstractions;

/// <summary>
/// セキュリティ・アクセス制御を行う Guard を定義します。
/// </summary>
public interface IGuard
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
    Task<bool> CanAccessContextAsync(IPrincipal principal, IUnifiedContextContract contract);

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

    /// <summary>
    /// 指定された failure mode が発生した場合の処理を実行します。
    /// </summary>
    /// <param name="mode">Failure mode</param>
    /// <param name="context">コンテキスト</param>
    Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context);
}

/// <summary>
/// Guard が取るべきアクションを定義します。
/// </summary>
public enum GuardAction
{
    /// <summary>
    /// 実行を続行する
    /// </summary>
    Continue = 1,

    /// <summary>
    /// 実行を一時停止して警告を表示する
    /// </summary>
    Warn = 2,

    /// <summary>
    /// 実行をブロックする
    /// </summary>
    Block = 3,

    /// <summary>
    /// 代替戦略を試みる
    /// </summary>
    FallBack = 4
}

/// <summary>
/// 実行主体（プリンシパル）を表現します。
/// </summary>
public interface IPrincipal
{
    /// <summary>
    /// 主体の一意識別子を取得します。
    /// </summary>
    string GetId();

    /// <summary>
    /// 主体の名前を取得します。
    /// </summary>
    string GetName();

    /// <summary>
    /// 主体に付与されたロールを取得します。
    /// </summary>
    IReadOnlyList<string> GetRoles();

    /// <summary>
    /// 主体が特定のロールを持つかどうかを確認します。
    /// </summary>
    bool HasRole(string role);
}
