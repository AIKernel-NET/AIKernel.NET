using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// EN: チャットターンのハッシュに対する暗号学的署名を提供する。
/// EN: Documentation for public API. JA: IChatTurnSignatureProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnSignatureProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnSignatureProvider']" />
public interface IChatTurnSignatureProvider
{
    /// <summary>EN: Executes the SignAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで SignAsync 操作を実行します。</summary>
    Task<string> SignAsync(
        string hash,
        CancellationToken cancellationToken = default);
    /// <summary>EN: Executes the VerifyAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで VerifyAsync 操作を実行します。</summary>
    Task<bool> VerifyAsync(
        string hash,
        string signature,
        CancellationToken cancellationToken = default);
}
