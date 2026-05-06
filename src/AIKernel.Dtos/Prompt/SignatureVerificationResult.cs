namespace AIKernel.Dtos.Prompt;

/// <summary>
/// SignatureVerificationResult の契約を定義します。
/// </summary>
public sealed record SignatureVerificationResult(
    bool IsValid,
    string Message);



