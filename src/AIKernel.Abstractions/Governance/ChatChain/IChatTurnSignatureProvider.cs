using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// チャットターンのハッシュに対する暗号学的署名を提供する。
/// </summary>
public interface IChatTurnSignatureProvider
{
    Task<string> SignAsync(
        string hash,
        CancellationToken cancellationToken = default);
    Task<bool> VerifyAsync(
        string hash,
        string signature,
        CancellationToken cancellationToken = default);
}
