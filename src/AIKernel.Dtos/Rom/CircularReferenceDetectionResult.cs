namespace AIKernel.Dtos.Rom;

/// <summary>
/// CircularReferenceDetectionResult の契約を定義します。
/// JA: CircularReferenceDetectionResult の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.CircularReferenceDetectionResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Rom.CircularReferenceDetectionResult']" />
public sealed record CircularReferenceDetectionResult
{
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.CircularReferencesDetected']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.CircularReferencesDetected']" />
    public required bool CircularReferencesDetected { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.Message']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.Message']" />
    public required string Message { get; init; }
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.List&lt;IReadOnlyList&lt;string&gt;&gt;']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.List&lt;IReadOnlyList&lt;string&gt;&gt;']" />
    public IReadOnlyList<IReadOnlyList<string>> CircularChains { get; init; } = new List<IReadOnlyList<string>>();
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.MayTriggerInferenceLoop']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Rom.CircularReferenceDetectionResult.MayTriggerInferenceLoop']" />
    public bool MayTriggerInferenceLoop { get; init; }
}




