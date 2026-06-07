using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// チャットターンを決定論的なバイト列または文字列表現へ正準化する。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnCanonicalizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnCanonicalizer']" />
public interface IChatTurnCanonicalizer
{
    /// <summary>Executes the Canonicalize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Canonicalize 操作を実行します。</summary>
    string Canonicalize(IChatTurn turn);
}
