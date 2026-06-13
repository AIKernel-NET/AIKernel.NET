namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// Computes the deterministic hash for a chat turn from canonical content and the previous turn hash.
/// JA: IChatTurnSemanticHasher の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnSemanticHasher']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Governance.ChatChain.IChatTurnSemanticHasher']" />
public interface IChatTurnSemanticHasher
{
    /// <summary>Executes the ComputeHash operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ComputeHash 操作を実行します。</summary>
    string ComputeHash(string canonicalContent, string previousHash);
}
