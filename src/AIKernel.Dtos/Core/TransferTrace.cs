namespace AIKernel.Dtos.Core;

/// <summary>
/// 転送トレースを表現します。
/// データフローとトレーサビリティを管理します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.TransferTrace']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.TransferTrace']" />
public sealed class TransferTrace
{
    /// <summary>
    /// トレースの一意識別子を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.TraceId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.TraceId']" />
    public required string TraceId { get; init; }

    /// <summary>
    /// データが転送された時刻を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.TransferredAt']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.TransferredAt']" />
    public required DateTime TransferredAt { get; init; }

    /// <summary>
    /// 転送元を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.Source']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.Source']" />
    public required string Source { get; init; }

    /// <summary>
    /// 転送先を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.Destination']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.Destination']" />
    public required string Destination { get; init; }

    /// <summary>
    /// 転送時のコンテキストタイプを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.ContextType']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.ContextType']" />
    public string? ContextType { get; init; }

    /// <summary>
    /// 転送されたデータサイズ（バイト）を取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.DataSizeBytes']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.DataSizeBytes']" />
    public long DataSizeBytes { get; init; }

    /// <summary>
    /// トレースに関連するメタデータを取得または設定します。
    /// </summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Core.TransferTrace.string']" />
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}


