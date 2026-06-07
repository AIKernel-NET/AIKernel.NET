namespace AIKernel.Abstractions.Context;

using AIKernel.Dtos.Rom;

/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IRomPathResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Context.IRomPathResolver']" />
public interface IRomPathResolver
{
    /// <summary>Executes the ResolvePathAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolvePathAsync 操作を実行します。</summary>
    ValueTask<string> ResolvePathAsync(
        RomId romId,
        CancellationToken cancellationToken = default);
}
