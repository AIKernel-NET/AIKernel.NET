namespace AIKernel.Abstractions.Governance.ChatChain;

public interface IChatTurnVerificationResult
{
    bool IsSuccess { get; }

    string? Error { get; }
}
