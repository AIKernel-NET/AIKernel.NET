using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// チャットターンのハッシュに対する暗号学的署名を提供する。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnSignatureProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnSignatureProvider']" />
public interface IChatTurnSignatureProvider
{
    /// <summary>Executes the SignAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SignAsync 操作を実行します。</summary>
    Task<string> SignAsync(
        string hash,
        CancellationToken cancellationToken = default);
    /// <summary>Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    Task<bool> VerifyAsync(
        string hash,
        string signature,
        CancellationToken cancellationToken = default);
}
