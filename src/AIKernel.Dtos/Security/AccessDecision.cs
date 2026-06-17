namespace AIKernel.Dtos.Security;

/// <summary>
/// EN: AccessDecision の契約を定義します。
/// [EN] Documents this public package API member. [JA] AccessDecision の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.AccessDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.AccessDecision']" />
public sealed class AccessDecision
{
    /// <summary>[EN] Documents this public package API member. [JA] Allowed を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Allowed']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Allowed']" />
    public bool Allowed { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Reason を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Reason']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Reason']" />
    public string? Reason { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] AppliedPolicies を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.AccessDecision.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.AccessDecision.new']" />
    public List<string> AppliedPolicies { get; init; } = new();
    /// <summary>[EN] Documents this public package API member. [JA] Constraints を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.string']" />
    public IReadOnlyDictionary<string, string>? Constraints { get; init; }
}




