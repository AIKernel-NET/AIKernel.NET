namespace AIKernel.Abstractions;

/// <summary>
/// ルールエンジンを定義します。
/// PromptRulesを評価し、プロンプト生成前後のポリシーチェックを実行します。
/// </summary>
public interface IRulesEngine : IProvider
{
    /// <summary>
    /// ルールセットを登録します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="rule">ルール定義</param>
    Task RegisterRuleAsync(string ruleId, IPromptRule rule);

    /// <summary>
    /// ルールセットを取得します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <returns>ルール定義</returns>
    Task<IPromptRule?> GetRuleAsync(string ruleId);

    /// <summary>
    /// ルールセットを削除します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <returns>削除成功の可否</returns>
    Task<bool> DeleteRuleAsync(string ruleId);

    /// <summary>
    /// ルールセットを評価します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="context">評価コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>評価結果</returns>
    Task<RuleEvaluationResult> EvaluateAsync(string ruleId, IReadOnlyDictionary<string, string> context, CancellationToken cancellationToken = default);

    /// <summary>
    /// プロンプト生成前のルール検証を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="prepromptContext">プロンプト生成前コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検証結果</returns>
    Task<RuleValidationResult> ValidatePrePromptAsync(string ruleId, IReadOnlyDictionary<string, string> prepromptContext, CancellationToken cancellationToken = default);

    /// <summary>
    /// プロンプト生成後のルール検証を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="postpromptContext">プロンプト生成後コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検証結果</returns>
    Task<RuleValidationResult> ValidatePostPromptAsync(string ruleId, IReadOnlyDictionary<string, string> postpromptContext, CancellationToken cancellationToken = default);

    /// <summary>
    /// すべて登録されているルールを取得します。
    /// </summary>
    /// <returns>ルール一覧</returns>
    Task<IReadOnlyList<IPromptRule>> ListRulesAsync();
}

/// <summary>
/// PromptRuleを定義します。
/// 署名付きMarkdown形式のプロンプト生成ルール。
/// </summary>
public interface IPromptRule
{
    /// <summary>
    /// ルールの一意識別子を取得します。
    /// </summary>
    string RuleId { get; }

    /// <summary>
    /// ルール名を取得します。
    /// </summary>
    string Name { get; }

    /// <summary>
    /// ルール説明を取得します。
    /// </summary>
    string Description { get; }

    /// <summary>
    /// ルール内容（Markdown形式）を取得します。
    /// </summary>
    string Content { get; }

    /// <summary>
    /// ルール適用スコープを取得します。
    /// </summary>
    RuleScope Scope { get; }

    /// <summary>
    /// ルールバージョンを取得します。
    /// </summary>
    string Version { get; }

    /// <summary>
    /// ルールの署名を取得します。
    /// </summary>
    string Signature { get; }

    /// <summary>
    /// ルール作成日時を取得します。
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// ルール更新日時を取得します。
    /// </summary>
    DateTime UpdatedAt { get; }

    /// <summary>
    /// ルールが有効かどうかを取得します。
    /// </summary>
    bool IsActive { get; }

    /// <summary>
    /// ルール作成者を取得します。
    /// </summary>
    string CreatedBy { get; }

    /// <summary>
    /// ルール更新者を取得します。
    /// </summary>
    string? UpdatedBy { get; }

    /// <summary>
    /// タグのリストを取得します。
    /// </summary>
    IReadOnlyList<string> Tags { get; }

    /// <summary>
    /// ルール優先度を取得します（0-100）。
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// ルールが有効期限を持つかどうかを確認します。
    /// </summary>
    DateTime? ExpiresAt { get; }

    /// <summary>
    /// ルールメタデータを取得します。
    /// </summary>
    IReadOnlyDictionary<string, string>? Metadata { get; }
}
