using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

public interface IResult
{
    bool IsSuccess { get; }
    string? Error { get; }
}

