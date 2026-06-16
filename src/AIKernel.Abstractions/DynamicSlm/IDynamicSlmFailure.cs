namespace AIKernel.Abstractions.DynamicSlm;

using AIKernel.Enums;

/// <summary>EN: Documentation for public API. JA: IDynamicSlmFailure contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmFailure']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.DynamicSlm.IDynamicSlmFailure']" />
public interface IDynamicSlmFailure
{
    /// <summary>EN: Gets the Kind value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Kind 値を取得します。</summary>
    DynamicSlmFailureKind Kind { get; }

    /// <summary>EN: Gets the Stage value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Stage 値を取得します。</summary>
    DynamicSlmPipelineStage Stage { get; }

    /// <summary>EN: Gets the Code value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Code 値を取得します。</summary>
    string Code { get; }

    /// <summary>EN: Gets the Message value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Message 値を取得します。</summary>
    string Message { get; }

    /// <summary>EN: Gets the ReplayLogHash value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ReplayLogHash 値を取得します。</summary>
    string? ReplayLogHash { get; }

    /// <summary>EN: Gets the Metadata value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Metadata 値を取得します。</summary>
    IReadOnlyDictionary<string, string> Metadata { get; }
}
