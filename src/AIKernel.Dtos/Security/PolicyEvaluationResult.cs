namespace AIKernel.Dtos.Security;

/// <summary>
/// EN: PolicyEvaluationResult の契約を定義します。
/// [EN] Documents this public package API member. [JA] PolicyEvaluationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PolicyEvaluationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PolicyEvaluationResult']" />
public sealed class PolicyEvaluationResult
{
    /// <summary>[EN] Documents this public package API member. [JA] AllAllowed を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.AllAllowed']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.AllAllowed']" />
    public bool AllAllowed { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Decisions を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.PolicyEvaluationResult.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.PolicyEvaluationResult.new']" />
    public List<AccessDecision> Decisions { get; init; } = new();
    /// <summary>EN: Gets the FailedPolicies value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FailedPolicies 値を取得します。</summary>
    public List<string> FailedPolicies { get; init; } = new();
    /// <summary>[EN] Documents this public package API member. [JA] RiskLevel を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.RiskLevel']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.RiskLevel']" />
    public string RiskLevel { get; init; } = "Low";
}




