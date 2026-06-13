namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Rule registry を管理します。
/// JA: IRuleRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleRegistry']" />
public interface IRuleRegistry
{
    /// <summary>
    /// ルールセットを登録します。
    /// JA: RegisterRuleAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子 JA: ruleId パラメーターです。</param>
    /// <param name="rule">ルール定義 JA: rule パラメーターです。</param>
    Task RegisterRuleAsync(string ruleId, IPromptRule rule);

    /// <summary>
    /// ルールセットを取得します。
    /// JA: GetRuleAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子 JA: ruleId パラメーターです。</param>
    /// <returns>ルール定義 JA: 結果を返します。</returns>
    Task<IPromptRule?> GetRuleAsync(string ruleId);

    /// <summary>
    /// ルールセットを削除します。
    /// JA: DeleteRuleAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子 JA: ruleId パラメーターです。</param>
    /// <returns>削除成功の可否 JA: 結果を返します。</returns>
    Task<bool> DeleteRuleAsync(string ruleId);

    /// <summary>
    /// すべて登録されているルールを取得します。
    /// JA: ListRulesAsync 操作を実行します。
    /// </summary>
    /// <returns>ルール一覧 JA: 結果を返します。</returns>
    Task<IReadOnlyList<IPromptRule>> ListRulesAsync();
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Rule evaluation を実行します。
/// JA: IRuleEvaluator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleEvaluator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleEvaluator']" />
public interface IRuleEvaluator
{
    /// <summary>
    /// ルールセットを評価します。
    /// JA: EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子 JA: ruleId パラメーターです。</param>
    /// <param name="context">評価コンテキスト JA: context パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>評価結果 JA: 結果を返します。</returns>
    Task<RuleEvaluationResult> EvaluateAsync(string ruleId, IReadOnlyDictionary<string, string> context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Prompt 生成前の rule validation を実行します。
/// JA: IPreExecutionRuleValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPreExecutionRuleValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPreExecutionRuleValidator']" />
public interface IPreExecutionRuleValidator
{
    /// <summary>
    /// プロンプト生成前のルール検証を実行します。
    /// JA: ValidatePrePromptAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子 JA: ruleId パラメーターです。</param>
    /// <param name="prepromptContext">プロンプト生成前コンテキスト JA: prepromptContext パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>検証結果 JA: 結果を返します。</returns>
    Task<RuleValidationResult> ValidatePrePromptAsync(string ruleId, IReadOnlyDictionary<string, string> prepromptContext, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// Prompt 生成後の rule validation を実行します。
/// JA: IPostExecutionRuleValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPostExecutionRuleValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPostExecutionRuleValidator']" />
public interface IPostExecutionRuleValidator
{
    /// <summary>
    /// プロンプト生成後のルール検証を実行します。
    /// JA: ValidatePostPromptAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">ルール一意識別子 JA: ruleId パラメーターです。</param>
    /// <param name="postpromptContext">プロンプト生成後コンテキスト JA: postpromptContext パラメーターです。</param>
    /// <param name="cancellationToken">キャンセルトークン JA: キャンセル通知を監視するトークンです。</param>
    /// <returns>検証結果 JA: 結果を返します。</returns>
    Task<RuleValidationResult> ValidatePostPromptAsync(string ruleId, IReadOnlyDictionary<string, string> postpromptContext, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// ルールエンジンを定義する互換合成インターフェースです。
/// JA: IRulesEngine の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRulesEngine']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRulesEngine']" />
public interface IRulesEngine :
    IProvider,
    IRuleRegistry,
    IRuleEvaluator,
    IPreExecutionRuleValidator,
    IPostExecutionRuleValidator
{
}
