namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>[EN] Documents this public package API member. [JA] IChatTurnVerificationResult contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnVerificationResult']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnVerificationResult']" />
public interface IChatTurnVerificationResult
{
    /// <summary>EN: Gets the IsSuccess value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される IsSuccess 値を取得します。</summary>
    bool IsSuccess { get; }

    /// <summary>EN: Gets the Error value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Error 値を取得します。</summary>
    string? Error { get; }
}
