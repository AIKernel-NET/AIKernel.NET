namespace AIKernel.Enums;

/// <summary>
/// ポリシー決定ポイント（PDP）の決定結果を定義します。
/// アクセス制御の最終判定を表現します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Enums.PdpDecision']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Enums.PdpDecision']" />
public enum PdpDecision
{
    /// <summary>
    /// アクセスが許可されました
    /// </summary>
    Allow = 1,

    /// <summary>
    /// アクセスが拒否されました
    /// </summary>
    Deny = 2,

    /// <summary>
    /// 決定が不確定（追加情報が必要）
    /// </summary>
    Undecided = 3
}

