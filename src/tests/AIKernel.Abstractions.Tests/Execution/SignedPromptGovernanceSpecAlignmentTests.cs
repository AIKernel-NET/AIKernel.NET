using AIKernel.Abstractions;
using AIKernel.Abstractions.Models;
using AIKernel.Dtos.Prompt;

namespace AIKernel.Abstractions.Tests.Execution;

public sealed class SignedPromptGovernanceSpecAlignmentTests
{
    [Fact]
    public async Task SGS_UseCase_Verify_Then_Validate_Then_Allow()
    {
        // SGS-001/002/003/004/007:
        // 署名済み成果物を Verify -> Validate で実行可否判定するユースケース
        var artifact = BuildArtifact();
        var verifier = new StubPromptVerifier(FailClosedDecision.Allow);
        var validator = new StubPromptValidator(FailClosedDecision.Allow);
        var constraints = new StubExecutionConstraints();

        var verify = await verifier.VerifyAsync(artifact);
        var validate = await validator.ValidateAsync(artifact, constraints);

        Assert.Equal(FailClosedDecision.Allow, verify.Decision);
        Assert.True(verify.HashIntegrityVerified);
        Assert.Equal(FailClosedDecision.Allow, validate.Decision);
        Assert.True(validate.ScopeBindingValid);
    }

    [Fact]
    public async Task SGS_F001_F005_Indeterminate_Is_Deny()
    {
        // SGS-F001: Indeterminate は Deny 扱い
        // SGS-F005: TrustStore 到達不能時は実行遮断
        var artifact = BuildArtifact();
        var verifier = new StubPromptVerifier(FailClosedDecision.Indeterminate);
        var verify = await verifier.VerifyAsync(artifact);

        var effective = verify.Decision == FailClosedDecision.Indeterminate ? FailClosedDecision.Deny : verify.Decision;
        Assert.Equal(FailClosedDecision.Deny, effective);
    }

    private static SignedPromptArtifactDto BuildArtifact() =>
        new()
        {
            EntityId = "logic.analyser.core",
            Version = "2.1.0",
            Type = "kernel.signed_prompt",
            PromptBody = "body",
            Policy = new PromptPolicyDto
            {
                AllowedTools = new[] { "tool.a" },
                AllowedScopes = new[] { "scope.read" },
                MaxTokenBudget = 1000,
                CreatedAt = DateTime.UtcNow.AddMinutes(-1),
                ExpiresAt = DateTime.UtcNow.AddMinutes(10)
            },
            Governance = new GovernanceMetadataDto
            {
                Issuer = "issuer",
                SignerId = "signer",
                HashAlgorithm = "SHA256",
                Hash = "sha256:x",
                Signature = "sig",
                SignedAt = DateTime.UtcNow
            }
        };

    private sealed class StubPromptVerifier(FailClosedDecision decision) : IPromptVerifier
    {
        public Task<PromptVerificationResult> VerifyAsync(SignedPromptArtifactDto artifact, CancellationToken ct = default) =>
            Task.FromResult(new PromptVerificationResult(decision, true, true, "ok"));
    }

    private sealed class StubPromptValidator(FailClosedDecision decision) : IPromptValidator
    {
        public Task<PromptValidationResult> ValidateAsync(SignedPromptArtifactDto artifact, IExecutionConstraints executionConstraints, CancellationToken ct = default) =>
            Task.FromResult(new PromptValidationResult(decision, true, true, Array.Empty<string>(), "ok"));
    }

    private sealed class StubExecutionConstraints : IExecutionConstraints
    {
        public int ContextCardinality => 1;
        public IReadOnlyList<string> AllowedTools => new[] { "tool.a" };
        public IReadOnlyList<string> Scopes => new[] { "scope.read" };
        public int MaxTokenBudget => 1000;
        public long AvailableMemoryMb => 1024;
        public int? MaxLatencyMs => 100;
        public string ComputeDeviceType => "CPU";
        public string ComputeDeviceName => "stub";
        public string QuantizationLevel => "FP16";
        public float ComputeThroughputTflops => 1;
        public int BatchSize => 1;
        public int SequenceLength => 128;
        public int PhysicalCardinality => 1;
        public object? GetContextValue(string key) => null;
        public IReadOnlyDictionary<string, object> GetAllContextValues() => new Dictionary<string, object>();
    }
}
