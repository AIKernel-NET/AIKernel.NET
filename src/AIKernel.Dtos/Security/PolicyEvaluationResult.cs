namespace AIKernel.Dtos.Security;

/// <summary>
/// EN: PolicyEvaluationResult の契約を定義します。
/// EN: Documentation for public API. JA: PolicyEvaluationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PolicyEvaluationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.PolicyEvaluationResult']" />
public sealed class PolicyEvaluationResult
{
    /// <summary>EN: Documentation for public API. JA: AllAllowed を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.AllAllowed']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.AllAllowed']" />
    public bool AllAllowed { get; init; }
    /// <summary>EN: Documentation for public API. JA: Decisions を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.PolicyEvaluationResult.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.PolicyEvaluationResult.new']" />
    public List<AccessDecision> Decisions { get; init; } = new();
    /// <summary>EN: Gets the FailedPolicies value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FailedPolicies 値を取得します。</summary>
    public List<string> FailedPolicies { get; init; } = new();
    /// <summary>EN: Documentation for public API. JA: RiskLevel を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.RiskLevel']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.PolicyEvaluationResult.RiskLevel']" />
    public string RiskLevel { get; init; } = "Low";
}




