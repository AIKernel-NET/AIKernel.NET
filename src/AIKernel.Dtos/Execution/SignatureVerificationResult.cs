namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: SignatureVerificationResult の契約を定義します。
/// EN: Documentation for public API. JA: SignatureVerificationResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.SignatureVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.SignatureVerificationResult']" />
public sealed record SignatureVerificationResult
{
    /// <summary>EN: Documentation for public API. JA: IsValid を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.IsValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.IsValid']" />
    public required bool IsValid { get; init; }
    /// <summary>EN: Documentation for public API. JA: SignerId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.SignerId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.SignerId']" />
    public required string SignerId { get; init; }
    /// <summary>EN: Documentation for public API. JA: TrustScore を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.TrustScore']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.TrustScore']" />
    public required double TrustScore { get; init; }
    /// <summary>EN: Documentation for public API. JA: Message を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.Message']" />
    public required string Message { get; init; }
    /// <summary>EN: Documentation for public API. JA: VerificationTimestamp を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.VerificationTimestamp']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.SignatureVerificationResult.VerificationTimestamp']" />
    public required DateTime VerificationTimestamp { get; init; }
}




