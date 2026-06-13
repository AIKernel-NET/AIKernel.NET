namespace AIKernel.Dtos.Security;

/// <summary>
/// PolicyEvaluationResult の契約を定義します。
/// JA: PolicyEvaluationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PolicyEvaluationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PolicyEvaluationResult']" />
public sealed class PolicyEvaluationResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.AllAllowed']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.AllAllowed']" />
    public bool AllAllowed { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.PolicyEvaluationResult.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.PolicyEvaluationResult.new']" />
    public List<AccessDecision> Decisions { get; init; } = new();
    /// <summary>Gets the FailedPolicies value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FailedPolicies 値を取得します。</summary>
    public List<string> FailedPolicies { get; init; } = new();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.RiskLevel']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.RiskLevel']" />
    public string RiskLevel { get; init; } = "Low";
}




