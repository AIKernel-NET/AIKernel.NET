namespace AIKernel.Abstractions.Rom;

/// <summary>
/// UC-01/UC-12 に基づく IRelationResolver の契約を定義します。
/// JA: IRelationResolver の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRelationResolver']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRelationResolver']" />
public interface IRelationResolver
{
    /// <summary>Executes the ResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ResolveAsync 操作を実行します。</summary>
    Task<AIKernel.Dtos.Rom.ResolvableEntity?> ResolveAsync(string referenceId, CancellationToken cancellationToken = default);
    /// <summary>Executes the CanResolveAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CanResolveAsync 操作を実行します。</summary>
    Task<bool> CanResolveAsync(string referenceId, CancellationToken cancellationToken = default);
}



