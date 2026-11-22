namespace AIKernel.Abstractions.Security;

/// <summary>Check, reserve and settle token usage across process restarts.</summary>
public interface ITokenReservationBudget
{
    bool CanReserve(int tokens = 1);
    string Reserve(int tokens);
    void Settle(string id, int? inputTokens, int? outputTokens);
}
