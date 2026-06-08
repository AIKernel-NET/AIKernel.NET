namespace AIKernel.Dtos.Security;

/// <summary>
/// AccessDecision の契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.AccessDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.AccessDecision']" />
public sealed class AccessDecision
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Allowed']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Allowed']" />
    public bool Allowed { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Reason']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.Reason']" />
    public string? Reason { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.AccessDecision.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Security.AccessDecision.new']" />
    public List<string> AppliedPolicies { get; init; } = new();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessDecision.string']" />
    public IReadOnlyDictionary<string, string>? Constraints { get; init; }
}




