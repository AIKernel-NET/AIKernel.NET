namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Rom;

/// <summary>EN: Documentation for public API. JA: IRomPathResolver contract を定義します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IRomPathResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IRomPathResolver']" />
public interface IRomPathResolver
{
    /// <summary>EN: Executes the ResolvePathAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolvePathAsync 操作を実行します。</summary>
    ValueTask<string> ResolvePathAsync(
        RomId romId,
        CancellationToken cancellationToken = default);
}
