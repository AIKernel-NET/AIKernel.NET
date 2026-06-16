namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// EN: Rule registry を管理します。
/// EN: Documentation for public API. JA: IRuleRegistry の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleRegistry']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleRegistry']" />
public interface IRuleRegistry
{
    /// <summary>
    /// EN: ルールセットを登録します。
    /// EN: Documentation for public API. JA: RegisterRuleAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">EN: Documentation for public API. JA: ルール一意識別子 ruleId パラメーターです。</param>
    /// <param name="rule">EN: Documentation for public API. JA: ルール定義 rule パラメーターです。</param>
    Task RegisterRuleAsync(string ruleId, IPromptRule rule);

    /// <summary>
    /// EN: ルールセットを取得します。
    /// EN: Documentation for public API. JA: GetRuleAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">EN: Documentation for public API. JA: ルール一意識別子 ruleId パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: ルール定義 結果を返します。</returns>
    Task<IPromptRule?> GetRuleAsync(string ruleId);

    /// <summary>
    /// EN: ルールセットを削除します。
    /// EN: Documentation for public API. JA: DeleteRuleAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">EN: Documentation for public API. JA: ルール一意識別子 ruleId パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 削除成功の可否 結果を返します。</returns>
    Task<bool> DeleteRuleAsync(string ruleId);

    /// <summary>
    /// EN: すべて登録されているルールを取得します。
    /// EN: Documentation for public API. JA: ListRulesAsync 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: ルール一覧 結果を返します。</returns>
    Task<IReadOnlyList<IPromptRule>> ListRulesAsync();
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// EN: Rule evaluation を実行します。
/// EN: Documentation for public API. JA: IRuleEvaluator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleEvaluator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IRuleEvaluator']" />
public interface IRuleEvaluator
{
    /// <summary>
    /// EN: ルールセットを評価します。
    /// EN: Documentation for public API. JA: EvaluateAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">EN: Documentation for public API. JA: ルール一意識別子 ruleId パラメーターです。</param>
    /// <param name="context">EN: Documentation for public API. JA: 評価コンテキスト context パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 評価結果 結果を返します。</returns>
    Task<RuleEvaluationResult> EvaluateAsync(string ruleId, IReadOnlyDictionary<string, string> context, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// EN: Prompt 生成前の rule validation を実行します。
/// EN: Documentation for public API. JA: IPreExecutionRuleValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPreExecutionRuleValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPreExecutionRuleValidator']" />
public interface IPreExecutionRuleValidator
{
    /// <summary>
    /// EN: プロンプト生成前のルール検証を実行します。
    /// EN: Documentation for public API. JA: ValidatePrePromptAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">EN: Documentation for public API. JA: ルール一意識別子 ruleId パラメーターです。</param>
    /// <param name="prepromptContext">EN: Documentation for public API. JA: プロンプト生成前コンテキスト prepromptContext パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 検証結果 結果を返します。</returns>
    Task<RuleValidationResult> ValidatePrePromptAsync(string ruleId, IReadOnlyDictionary<string, string> prepromptContext, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// EN: Prompt 生成後の rule validation を実行します。
/// EN: Documentation for public API. JA: IPostExecutionRuleValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPostExecutionRuleValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPostExecutionRuleValidator']" />
public interface IPostExecutionRuleValidator
{
    /// <summary>
    /// EN: プロンプト生成後のルール検証を実行します。
    /// EN: Documentation for public API. JA: ValidatePostPromptAsync 操作を実行します。
    /// </summary>
    /// <param name="ruleId">EN: Documentation for public API. JA: ルール一意識別子 ruleId パラメーターです。</param>
    /// <param name="postpromptContext">EN: Documentation for public API. JA: プロンプト生成後コンテキスト postpromptContext パラメーターです。</param>
    /// <param name="cancellationToken">EN: Documentation for public API. JA: キャンセルトークン キャンセル通知を監視するトークンです。</param>
    /// <returns>EN: Documentation for public API. JA: 検証結果 結果を返します。</returns>
    Task<RuleValidationResult> ValidatePostPromptAsync(string ruleId, IReadOnlyDictionary<string, string> postpromptContext, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-11/UC-12/UC-13 に基づく契約です。
/// EN: ルールエンジンを定義する互換合成インターフェースです。
/// EN: Documentation for public API. JA: IRulesEngine の公開契約を定義します。
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
