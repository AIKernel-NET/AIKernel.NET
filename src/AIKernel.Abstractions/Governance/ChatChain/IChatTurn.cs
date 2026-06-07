using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurn']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurn']" />
public interface IChatTurn
{
    /// <summary>Gets the Actor value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Actor 値を取得します。</summary>
    string Actor { get; }
    /// <summary>Gets the Body value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Body 値を取得します。</summary>
    string Body { get; }
    /// <summary>Gets the Timestamp value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Timestamp 値を取得します。</summary>
    DateTime Timestamp { get; }
}

