using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// 因果的同一性、ハッシュ連続性、署名、ポリシー受理を検証する。
/// </summary>
public interface IChatTurnChainVerifier
{
    IResult VerifyChain(IEnumerable<IHashChainNode> turns);
    IResult VerifyNextTurn(IHashChainNode nextTurn, string currentTailHash);
}
