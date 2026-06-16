using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>EN: Documentation for public API. JA: IChatTurn contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurn']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurn']" />
public interface IChatTurn
{
    /// <summary>EN: Gets the Actor value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Actor 値を取得します。</summary>
    string Actor { get; }
    /// <summary>EN: Gets the Body value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Body 値を取得します。</summary>
    string Body { get; }
    /// <summary>EN: Gets the Timestamp value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Timestamp 値を取得します。</summary>
    DateTime Timestamp { get; }
}

