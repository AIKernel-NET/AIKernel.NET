using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain
{
    public interface IHashChainNode
    {
        IChatTurn Turn { get; }
        string PrevHash { get; }
        string Hash { get; }
        string? Signature { get; }
    }

}
