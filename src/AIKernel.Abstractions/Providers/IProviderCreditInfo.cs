namespace AIKernel.Abstractions.Providers;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく IProviderCreditInfo の契約を定義します。
/// </summary>
public interface IProviderCreditInfo
{
    string ProviderId { get; }
    string CurrencyCode { get; }
    decimal CurrentBalance { get; }
    decimal ReservedBalance { get; }
    decimal HardLimit { get; }
    decimal SoftLimit { get; }
    DateTimeOffset LastUpdatedUtc { get; }
}




