namespace AIKernel.Dtos.Tokenization;

/// <summary>
/// EN: PaddingInfo の契約を定義します。
/// [EN] Documents this public package API member. [JA] PaddingInfo の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.PaddingInfo']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Tokenization.PaddingInfo']" />
public sealed class PaddingInfo
{
    /// <summary>[EN] Documents this public package API member. [JA] LogicalTokenCount を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.LogicalTokenCount']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.LogicalTokenCount']" />
    public required int LogicalTokenCount { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] PhysicalCardinality を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PhysicalCardinality']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PhysicalCardinality']" />
    public required int PhysicalCardinality { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] PaddingAmount を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PaddingAmount']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PaddingAmount']" />
    public required int PaddingAmount { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] PaddingPercentage を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PaddingPercentage']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PaddingPercentage']" />
    public required float PaddingPercentage { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] PaddingMethod を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PaddingMethod']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.PaddingMethod']" />
    public string? PaddingMethod { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] MemoryDifferenceBytes を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.MemoryDifferenceBytes']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.MemoryDifferenceBytes']" />
    public long MemoryDifferenceBytes { get; init; }
    /// <summary>[EN] Documents this public package API member. [JA] Rationale を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.Rationale']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Tokenization.PaddingInfo.Rationale']" />
    public string? Rationale { get; init; }
}




