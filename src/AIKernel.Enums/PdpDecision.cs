namespace AIKernel.Enums;

/// <summary>
/// ポリシー決定ポイント（PDP）の決定結果を定義します。
/// EN: アクセス制御の最終判定を表現します。
/// EN: Documentation for public API. JA: PdpDecision の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.PdpDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.PdpDecision']" />
public enum PdpDecision
{
    /// <summary>
    /// EN: アクセスが許可されました
    /// EN: Documentation for public API. JA: Allow 値を表します。
    /// </summary>
    Allow = 1,

    /// <summary>
    /// EN: アクセスが拒否されました
    /// EN: Documentation for public API. JA: Deny 値を表します。
    /// </summary>
    Deny = 2,

    /// <summary>
    /// EN: 決定が不確定（追加情報が必要）
    /// EN: Documentation for public API. JA: Undecided 値を表します。
    /// </summary>
    Undecided = 3
}

