namespace AIKernel.Abstractions.Governance;

/// <summary>
/// EN: UC-06/UC-32 に基づく IAttentionGuard の契約を定義します。
/// EN: Documentation for public API. JA: IAttentionGuard の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IAttentionGuard']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.IAttentionGuard']" />
public interface IAttentionGuard
{
    /// <summary>EN: Executes the ValidateIsolation operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateIsolation 操作を実行します。</summary>
    void ValidateIsolation(Context.IContextCollection context);
    /// <summary>EN: Executes the DetectPollution operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで DetectPollution 操作を実行します。</summary>
    IReadOnlyList<string> DetectPollution(Context.IContextCollection context);
    /// <summary>EN: Gets the FailClosed value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される FailClosed 値を取得します。</summary>
    bool FailClosed { get; }
}



