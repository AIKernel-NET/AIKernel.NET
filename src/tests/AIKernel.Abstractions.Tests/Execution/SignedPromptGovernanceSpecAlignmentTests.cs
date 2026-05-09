using AIKernel.Abstractions.Models;
using AIKernel.Abstractions.Prompt;
using AIKernel.Abstractions.Security;
using AIKernel.Dtos.Context;
using AIKernel.Dtos.Prompt;
using AIKernel.Dtos.Security;
using System.Security.Principal;
using SecurityPrincipal = AIKernel.Abstractions.Security.IPrincipal;

namespace AIKernel.Abstractions.Tests.Execution;

/// <summary>
/// SignedPromptGovernanceSpecAlignmentTests の契約を定義します。
/// </summary>
public sealed class SignedPromptGovernanceSpecAlignmentTests
{
    private static readonly string[] UserRoles = ["user"];
    private static readonly string[] ScopeRead = ["scope.read"];
    private static readonly string[] ToolA = ["tool.a"];

    [Fact]
    public async Task SGS_PDP_001_003_SGS_F000_NonDeterministic_Path_Is_Rejected_FailClosed()
    {
        // SGS-PDP-001/002/003:
        // PDP は決定論的コードのみで判定する
        // SGS-F000:
        // 非決定論的要素を検出した場合は即時 Deny
        var principal = new StubPrincipal("principal-1", "operator", UserRoles);
        var request = new AccessRequest
        {
            Principal = new GenericPrincipal(new GenericIdentity("operator"), UserRoles),
            Action = "execute",
            Resource = "prompt.signed"
        };
        var policy = new DeterministicDenyPolicy();
        var deterministicPdp = new StubDeterministicPdp(policy, containsNonDeterministicElement: false);
        var nonDeterministicPdp = new StubDeterministicPdp(policy, containsNonDeterministicElement: true);
        var guard = new StubGuard();

        var deterministicDecision = await deterministicPdp.EvaluateAsync(request);
        var allowedByGuard = await guard.CanExecuteAsync(principal, request.Action, request.Resource);
        var nonDeterministicDecision = await nonDeterministicPdp.EvaluateAsync(request);

        Assert.False(deterministicDecision.Allowed);
        Assert.Equal("deny.by.policy", deterministicDecision.Reason);
        Assert.False(allowedByGuard);
        Assert.False(nonDeterministicDecision.Allowed);
        Assert.Equal("SGS-F000", nonDeterministicDecision.Reason);
    }

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
            Policy = new PromptPolicyDto(
                0.0,
                Array.Empty<string>(),
                ScopeRead,
                ToolA,
                1000,
                DateTime.UtcNow.AddMinutes(10),
                DateTime.UtcNow.AddMinutes(-1)),
            PromptBody = "body",
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
        public Task<PromptVerificationResult> VerifyAsync(SignedPromptArtifactDto artifact, CancellationToken ct = default)
        {
            _ = artifact;
            _ = ct;
            return Task.FromResult(new PromptVerificationResult(decision, true, true, "ok"));
        }
    }

    private sealed class StubPromptValidator(FailClosedDecision decision) : IPromptValidator
    {
        public Task<PromptValidationResult> ValidateAsync(SignedPromptArtifactDto artifact, IExecutionConstraints executionConstraints, CancellationToken ct = default)
        {
            _ = artifact;
            _ = executionConstraints;
            _ = ct;
            return Task.FromResult(new PromptValidationResult(decision, true, true, [], "ok"));
        }
    }

    private sealed class StubExecutionConstraints : IExecutionConstraints
    {
        public int ContextCardinality => 1;
        public IReadOnlyList<string> AllowedTools => ToolA;
        public IReadOnlyList<string> Scopes => ScopeRead;
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
        public string? GetContextValue(string key) => null;
        public IReadOnlyDictionary<string, string> GetAllContextValues() => new Dictionary<string, string>();
    }

    private sealed class StubPrincipal(string id, string name, IReadOnlyList<string> roles) : SecurityPrincipal
    {
        public string GetId() => id;
        public string GetName() => name;
        public IReadOnlyList<string> GetRoles() => roles;
        public bool HasRole(string role) => roles.Contains(role, StringComparer.Ordinal);
    }

    private sealed class DeterministicDenyPolicy : IPolicy
    {
        public string GetId() => "policy.deny.execute";
        public string GetName() => "Deny Execute";
        public bool IsApplicable(AccessRequest request) => string.Equals(request.Action, "execute", StringComparison.Ordinal);
        public AccessDecision Evaluate(AccessRequest request) => new() { Allowed = false, Reason = "deny.by.policy" };
    }

    private sealed class StubDeterministicPdp(IPolicy policy, bool containsNonDeterministicElement) : IPdp
    {
        public Task<AccessDecision> EvaluateAsync(AccessRequest request)
        {
            if (containsNonDeterministicElement)
            {
                return Task.FromResult(new AccessDecision
                {
                    Allowed = false,
                    Reason = "SGS-F000"
                });
            }

            return Task.FromResult(policy.Evaluate(request));
        }

        public void AddPolicy(IPolicy policy) { }
        public bool RemovePolicy(string policyId)
        {
            _ = policyId;
            return false;
        }
        public IReadOnlyList<IPolicy> GetPolicies() => new[] { policy };
        public Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract)
        {
            _ = contract;
            return Task.FromResult(new PolicyEvaluationResult
            {
                AllAllowed = false,
                RiskLevel = "High",
                FailedPolicies = new List<string> { "policy.deny.execute" }
            });
        }
    }

    private sealed class StubGuard : IGuard
    {
        public Task<bool> CanExecuteAsync(SecurityPrincipal principal, string action, string resource)
        {
            _ = principal;
            _ = action;
            _ = resource;
            return Task.FromResult(false);
        }

        public Task<bool> CanAccessContextAsync(SecurityPrincipal principal, UnifiedContextDto contract)
        {
            _ = principal;
            _ = contract;
            return Task.FromResult(false);
        }

        public Task<bool> CanReadAsync(SecurityPrincipal principal, string resource)
        {
            _ = principal;
            _ = resource;
            return Task.FromResult(false);
        }

        public Task<bool> CanWriteAsync(SecurityPrincipal principal, string resource)
        {
            _ = principal;
            _ = resource;
            return Task.FromResult(false);
        }

        public Task<GuardAction> EnforceAsync(SecurityPrincipal principal, string action, string resource)
        {
            _ = principal;
            _ = action;
            _ = resource;
            return Task.FromResult(GuardAction.Block);
        }

        public Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context)
        {
            _ = mode;
            _ = context;
            return Task.FromResult(GuardAction.Block);
        }
    }
}



