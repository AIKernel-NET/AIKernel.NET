namespace AIKernel.Abstractions.Providers;

/// <summary>
/// EN: UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IModelMessage の契約を定義します。
/// [EN] Documents this public package API member. [JA] IModelMessage の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IModelMessage']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IModelMessage']" />
public interface IModelMessage
{
    /// <summary>EN: Gets the Role value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Role 値を取得します。</summary>
    string Role { get; }
    /// <summary>EN: Gets the Content value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Content 値を取得します。</summary>
    string Content { get; }
}




