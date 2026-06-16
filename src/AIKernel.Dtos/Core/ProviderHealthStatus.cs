namespace AIKernel.Dtos.Core;

/// <summary>
/// EN: ProviderHealthStatus の契約を定義します。
/// [EN] Documents this public package API member. [JA] ProviderHealthStatus の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.ProviderHealthStatus']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Core.ProviderHealthStatus']" />
public sealed record ProviderHealthStatus(
    bool IsHealthy,
    string? Message,
    DateTime CheckedAt,
    long ResponseTimeMs);




