namespace AIKernel.Dtos.Context;

using AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: ValidationResult を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ValidationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Context.ValidationResult']" />
public sealed class ValidationResult
{
    /// <summary>EN: Documentation for public API. JA: IsValid を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ValidationResult.IsValid']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Context.ValidationResult.IsValid']" />
    public bool IsValid { get; init; }

    /// <summary>EN: Documentation for public API. JA: Errors を実行します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ValidationResult.new']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='M:AIKernel.Dtos.Context.ValidationResult.new']" />
    public List<string> Errors { get; init; } = new();

    /// <summary>EN: Gets the Warnings value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Warnings 値を取得します。</summary>
    public List<string> Warnings { get; init; } = new();

    /// <summary>EN: Gets the DetectedFailureModes value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される DetectedFailureModes 値を取得します。</summary>
    public List<FailureMode> DetectedFailureModes { get; init; } = new();
}
