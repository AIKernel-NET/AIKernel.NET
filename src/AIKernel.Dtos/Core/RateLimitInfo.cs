namespace AIKernel.Dtos.Core;

/// <summary>
/// RateLimitInfo の契約を定義します。
/// JA: RateLimitInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.RateLimitInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.RateLimitInfo']" />
public sealed record RateLimitInfo(
    int WindowSeconds,
    int RequestsPerWindow,
    int UsedRequests);




