namespace AIKernel.Enums;

/// <summary>
/// RuleScope の契約を定義します。
/// JA: RuleScope の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.RuleScope']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.RuleScope']" />
public enum RuleScope
{
    /// <summary>Gets the Global value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Global 値を取得します。</summary>
    Global = 1,
    /// <summary>Gets the Pipeline value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Pipeline 値を取得します。</summary>
    Pipeline = 2,
    /// <summary>Gets the Task value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Task 値を取得します。</summary>
    Task = 3,
    /// <summary>Gets the User value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される User 値を取得します。</summary>
    User = 4,
    /// <summary>Gets the Custom value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Custom 値を取得します。</summary>
    Custom = 5
}



