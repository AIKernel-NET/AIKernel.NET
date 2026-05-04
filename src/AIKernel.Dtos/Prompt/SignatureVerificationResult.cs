namespace AIKernel.Dtos.Prompt;

public sealed record SignatureVerificationResult(
    bool IsValid,
    string Message);
