using System.Security.Principal;

namespace AIKernel.Dtos.Security;

/// <summary>
/// AccessRequest の契約を定義します。
/// JA: AccessRequest の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.AccessRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Security.AccessRequest']" />
public sealed record AccessRequest
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.Principal']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.Principal']" />
    public required IPrincipal Principal { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.Action']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.Action']" />
    public required string Action { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.Resource']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.Resource']" />
    public required string Resource { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Security.AccessRequest.string']" />
    public IReadOnlyDictionary<string, string>? Environment { get; init; }
}



