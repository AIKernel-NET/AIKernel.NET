namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Rule registry を管理します。
/// </summary>
public interface IRuleRegistry
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
    /// すべて登録されているルールを取得します。
    /// </summary>
    /// <returns>ルール一覧</returns>
    Task<IReadOnlyList<IPromptRule>> ListRulesAsync();
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Rule evaluation を実行します。
/// </summary>
public interface IRuleEvaluator
{
    /// <summary>
    /// ルールセットを評価します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="context">評価コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>評価結果</returns>
    Task<RuleEvaluationResult> EvaluateAsync(string ruleId, IReadOnlyDictionary<string, string> context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Prompt 生成前の rule validation を実行します。
/// </summary>
public interface IPreExecutionRuleValidator
{
    /// <summary>
    /// プロンプト生成前のルール検証を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="prepromptContext">プロンプト生成前コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検証結果</returns>
    Task<RuleValidationResult> ValidatePrePromptAsync(string ruleId, IReadOnlyDictionary<string, string> prepromptContext, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Prompt 生成後の rule validation を実行します。
/// </summary>
public interface IPostExecutionRuleValidator
{
    /// <summary>
    /// プロンプト生成後のルール検証を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子</param>
    /// <param name="postpromptContext">プロンプト生成後コンテキスト</param>
    /// <param name="cancellationToken">キャンセルトークン</param>
    /// <returns>検証結果</returns>
    Task<RuleValidationResult> ValidatePostPromptAsync(string ruleId, IReadOnlyDictionary<string, string> postpromptContext, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// ルールエンジンを定義する互換合成インターフェースです。
/// </summary>
public interface IRulesEngine :
    IProvider,
    IRuleRegistry,
    IRuleEvaluator,
    IPreExecutionRuleValidator,
    IPostExecutionRuleValidator
{
}
