using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

public interface IChatTurn
{
    string Actor { get; }
    string Body { get; }
    DateTime Timestamp { get; }
}

