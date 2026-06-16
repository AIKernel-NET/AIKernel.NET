namespace AIKernel.Abstractions.Prompt;

/// <summary>
/// EN: UC-11/UC-12/UC-13 に基づく IPromptRule の契約を定義します。
/// EN: Documentation for public API. JA: IPromptRule の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptRule']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Prompt.IPromptRule']" />
public interface IPromptRule
{
    /// <summary>EN: Gets the RuleId value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される RuleId 値を取得します。</summary>
    string RuleId { get; }
    /// <summary>EN: Gets the Name value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Name 値を取得します。</summary>
    string Name { get; }
    /// <summary>EN: Gets the Description value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Description 値を取得します。</summary>
    string Description { get; }
    /// <summary>EN: Gets the Content value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Content 値を取得します。</summary>
    string Content { get; }
    /// <summary>EN: Gets the Scope value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Scope 値を取得します。</summary>
    RuleScope Scope { get; }
    /// <summary>EN: Gets the Version value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Version 値を取得します。</summary>
    string Version { get; }
    /// <summary>EN: Gets the Signature value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Signature 値を取得します。</summary>
    string Signature { get; }
    /// <summary>EN: Gets the CreatedAt value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CreatedAt 値を取得します。</summary>
    DateTime CreatedAt { get; }
    /// <summary>EN: Gets the UpdatedAt value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される UpdatedAt 値を取得します。</summary>
    DateTime UpdatedAt { get; }
    /// <summary>EN: Gets the IsActive value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される IsActive 値を取得します。</summary>
    bool IsActive { get; }
    /// <summary>EN: Gets the CreatedBy value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される CreatedBy 値を取得します。</summary>
    string CreatedBy { get; }
    /// <summary>EN: Gets the UpdatedBy value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される UpdatedBy 値を取得します。</summary>
    string? UpdatedBy { get; }
    /// <summary>EN: Gets the Tags value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Tags 値を取得します。</summary>
    IReadOnlyList<string> Tags { get; }
    /// <summary>EN: Gets the Priority value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Priority 値を取得します。</summary>
    int Priority { get; }
    /// <summary>EN: Gets the ExpiresAt value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される ExpiresAt 値を取得します。</summary>
    DateTime? ExpiresAt { get; }
    /// <summary>EN: Gets the Metadata value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Metadata 値を取得します。</summary>
    IReadOnlyDictionary<string, string>? Metadata { get; }
}




