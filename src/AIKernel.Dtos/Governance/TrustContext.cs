namespace AIKernel.Dtos.Governance;

/// <summary>
/// EN: TrustContext の契約を定義します。
/// [EN] Documents this public package API member. [JA] TrustContext の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.TrustContext']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Governance.TrustContext']" />
public sealed record TrustContext
{
    /// <summary>[EN] Documents this public package API member. [JA] SignerId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.SignerId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.SignerId']" />
    public required string SignerId { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] TrustScore を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.TrustScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.TrustScore']" />
    public required double TrustScore { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] IsKeyRevoked を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsKeyRevoked']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsKeyRevoked']" />
    public required bool IsKeyRevoked { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] KeyExpiry を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.KeyExpiry']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.KeyExpiry']" />
    public DateTime? KeyExpiry { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] IsCertificateChainValid を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsCertificateChainValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsCertificateChainValid']" />
    public required bool IsCertificateChainValid { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] IsTrustStoreHealthy を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsTrustStoreHealthy']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsTrustStoreHealthy']" />
    public required bool IsTrustStoreHealthy { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] VerificationTimestamp を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.VerificationTimestamp']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.VerificationTimestamp']" />
    public required DateTime VerificationTimestamp { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] IsDetermined を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsDetermined']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Governance.TrustContext.IsDetermined']" />
    public required bool IsDetermined { get; init; }
}



