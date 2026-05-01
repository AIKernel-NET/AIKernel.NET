namespace AIKernel.Contracts;

/// <summary>
/// 検証結果契約を定義します。
/// コンテキストおよびポリシー検証の結果を表現します。
/// </summary>
public interface IValidationResult
{
    /// <summary>
    /// 検証が成功したかどうかを取得します。
    /// </summary>
    bool IsValid { get; }

    /// <summary>
    /// 検証エラーメッセージを取得します。
    /// </summary>
    IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// 検証警告メッセージを取得します。
    /// </summary>
    IReadOnlyList<string> Warnings { get; }

    /// <summary>
    /// 検証に要した時間（ミリ秒）を取得します。
    /// </summary>
    long ValidationTimeMs { get; }

    /// <summary>
    /// 検証に使用されたルールセットを取得します。
    /// </summary>
    string? RuleSet { get; }
}
