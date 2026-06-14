namespace AIKernel.Abstractions.Routing;

/// <summary>[EN] Semantic route result. [JA] semantic route result です。 JA: RouteResult の公開契約を定義します。</summary>
public sealed record RouteResult(
    string Route,
    double Confidence,
    IReadOnlyDictionary<string, string> Metadata);

/// <summary>[EN] OS semantic router abstraction. [JA] OS semantic router 抽象です。 JA: ISemanticRouter の公開契約を定義します。</summary>
public interface ISemanticRouter
{
    /// <summary>[EN] Routes semantic input. [JA] semantic input を route します。 JA: RouteAsync 操作を実行します。</summary>
    Task<RouteResult> RouteAsync(string input);
}
