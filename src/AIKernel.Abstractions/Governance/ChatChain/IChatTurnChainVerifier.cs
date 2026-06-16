using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// EN: 因果的同一性、ハッシュ連続性、署名、ポリシー受理を検証する。
/// EN: Documentation for public API. JA: IChatTurnChainVerifier の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnChainVerifier']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnChainVerifier']" />
public interface IChatTurnChainVerifier
{
    /// <summary>EN: Executes the VerifyChain operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyChain 操作を実行します。</summary>
    IChatTurnVerificationResult VerifyChain(IEnumerable<IHashChainNode> turns);

    /// <summary>EN: Executes the VerifyNextTurn operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyNextTurn 操作を実行します。</summary>
    IChatTurnVerificationResult VerifyNextTurn(IHashChainNode nextTurn, string currentTailHash);
}
