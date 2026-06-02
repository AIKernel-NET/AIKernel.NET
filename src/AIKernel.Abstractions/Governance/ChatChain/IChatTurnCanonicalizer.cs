using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// チャットターンを決定論的なバイト列または文字列表現へ正準化する。
/// </summary>
public interface IChatTurnCanonicalizer
{
    string Canonicalize(IChatTurn turn);
}
