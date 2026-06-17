namespace AIKernel.Dtos.Execution;

/// <summary>
/// EN: HashChain の契約を定義します。
/// [EN] Documents this public package API member. [JA] HashChain の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.HashChain']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.HashChain']" />
public sealed record HashChain
{
    /// <summary>[EN] Documents this public package API member. [JA] StructureHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.StructureHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.StructureHash']" />
    public required string StructureHash { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] GenerationHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.GenerationHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.GenerationHash']" />
    public required string GenerationHash { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] GenerationParentHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.GenerationParentHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.GenerationParentHash']" />
    public required string GenerationParentHash { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] PolishHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.PolishHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.PolishHash']" />
    public required string PolishHash { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] PolishParentHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.PolishParentHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.PolishParentHash']" />
    public required string PolishParentHash { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] HashAlgorithm を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.HashAlgorithm']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Execution.HashChain.HashAlgorithm']" />
    public string HashAlgorithm { get; init; } = "SHA256";
}




