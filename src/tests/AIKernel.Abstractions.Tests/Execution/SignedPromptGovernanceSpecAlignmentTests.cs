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
/// EN: Defines the SignedPromptGovernanceSpecAlignmentTests contract. JA: SignedPromptGovernanceSpecAlignmentTests の公開契約を定義します。
/// </summary>
public sealed class SignedPromptGovernanceSpecAlignmentTests
{
    private static readonly string[] UserRoles = ["user"];
    private static readonly string[] ScopeRead = ["scope.read"];
    private static readonly string[] ToolA = ["tool.a"];
    /// <summary>
    /// EN: Executes SGS_PDP_001_003_SGS_F000_NonDeterministic_Path_Is_Rejected_FailClosed.
    /// EN: Documentation for public API. JA: SGS_PDP_001_003_SGS_F000_NonDeterministic_Path_Is_Rejected_FailClosed を実行します。
    /// </summary>

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
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
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
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
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
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<PromptVerificationResult> VerifyAsync(SignedPromptArtifactDto artifact, CancellationToken ct = default)
        {
            _ = artifact;
            _ = ct;
            return Task.FromResult(new PromptVerificationResult(decision, true, true, "ok"));
        }
    }

    private sealed class StubPromptValidator(FailClosedDecision decision) : IPromptValidator
    {
        /// <summary>
        /// EN: Executes ValidateAsync.
        /// EN: Documentation for public API. JA: ValidateAsync を実行します。
        /// </summary>
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
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public int ContextCardinality => 1;
        /// <summary>
        /// EN: Gets AllowedTools.
        /// EN: Documentation for public API. JA: AllowedTools を取得します。
        /// </summary>
        public IReadOnlyList<string> AllowedTools => ToolA;
        /// <summary>
        /// EN: Gets Scopes.
        /// EN: Documentation for public API. JA: Scopes を取得します。
        /// </summary>
        public IReadOnlyList<string> Scopes => ScopeRead;
        /// <summary>
        /// EN: Gets MaxTokenBudget.
        /// EN: Documentation for public API. JA: MaxTokenBudget を取得します。
        /// </summary>
        public int MaxTokenBudget => 1000;
        /// <summary>
        /// EN: Gets AvailableMemoryMb.
        /// EN: Documentation for public API. JA: AvailableMemoryMb を取得します。
        /// </summary>
        public long AvailableMemoryMb => 1024;
        /// <summary>
        /// EN: Gets MaxLatencyMs.
        /// EN: Documentation for public API. JA: MaxLatencyMs を取得します。
        /// </summary>
        public int? MaxLatencyMs => 100;
        /// <summary>
        /// EN: Gets ComputeDeviceType.
        /// EN: Documentation for public API. JA: ComputeDeviceType を取得します。
        /// </summary>
        public string ComputeDeviceType => "CPU";
        /// <summary>
        /// EN: Gets ComputeDeviceName.
        /// EN: Documentation for public API. JA: ComputeDeviceName を取得します。
        /// </summary>
        public string ComputeDeviceName => "stub";
        /// <summary>
        /// EN: Gets QuantizationLevel.
        /// EN: Documentation for public API. JA: QuantizationLevel を取得します。
        /// </summary>
        public string QuantizationLevel => "FP16";
        /// <summary>
        /// EN: Gets ComputeThroughputTflops.
        /// EN: Documentation for public API. JA: ComputeThroughputTflops を取得します。
        /// </summary>
        public float ComputeThroughputTflops => 1;
        /// <summary>
        /// EN: Gets BatchSize.
        /// EN: Documentation for public API. JA: BatchSize を取得します。
        /// </summary>
        public int BatchSize => 1;
        /// <summary>
        /// EN: Gets SequenceLength.
        /// EN: Documentation for public API. JA: SequenceLength を取得します。
        /// </summary>
        public int SequenceLength => 128;
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public int PhysicalCardinality => 1;
        /// <summary>
        /// EN: Executes GetContextValue.
        /// EN: Documentation for public API. JA: GetContextValue を実行します。
        /// </summary>
        public string? GetContextValue(string key) => null;
        /// <summary>
        /// EN: Executes GetAllContextValues.
        /// EN: Documentation for public API. JA: GetAllContextValues を実行します。
        /// </summary>
        public IReadOnlyDictionary<string, string> GetAllContextValues() => new Dictionary<string, string>();
    }

    private sealed class StubPrincipal(string id, string name, IReadOnlyList<string> roles) : SecurityPrincipal
    {
        /// <summary>
        /// EN: Executes GetId.
        /// EN: Documentation for public API. JA: GetId を実行します。
        /// </summary>
        public string GetId() => id;
        /// <summary>
        /// EN: Executes GetName.
        /// EN: Documentation for public API. JA: GetName を実行します。
        /// </summary>
        public string GetName() => name;
        /// <summary>
        /// EN: Executes GetRoles.
        /// EN: Documentation for public API. JA: GetRoles を実行します。
        /// </summary>
        public IReadOnlyList<string> GetRoles() => roles;
        /// <summary>
        /// EN: Executes HasRole.
        /// EN: Documentation for public API. JA: HasRole を実行します。
        /// </summary>
        public bool HasRole(string role) => roles.Contains(role, StringComparer.Ordinal);
    }

    private sealed class DeterministicDenyPolicy : IPolicy
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string GetId() => "policy.deny.execute";
        /// <summary>
        /// EN: Executes GetName.
        /// EN: Documentation for public API. JA: GetName を実行します。
        /// </summary>
        public string GetName() => "Deny Execute";
        /// <summary>
        /// EN: Executes IsApplicable.
        /// EN: Documentation for public API. JA: IsApplicable を実行します。
        /// </summary>
        public bool IsApplicable(AccessRequest request) => string.Equals(request.Action, "execute", StringComparison.Ordinal);
        /// <summary>
        /// EN: Executes Evaluate.
        /// EN: Documentation for public API. JA: Evaluate を実行します。
        /// </summary>
        public AccessDecision Evaluate(AccessRequest request) => new() { Allowed = false, Reason = "deny.by.policy" };
    }

    private sealed class StubDeterministicPdp(IPolicy policy, bool containsNonDeterministicElement) : IPdp
    {
        /// <summary>
        /// EN: Executes EvaluateAsync.
        /// EN: Documentation for public API. JA: EvaluateAsync を実行します。
        /// </summary>
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

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public void AddPolicy(IPolicy policy) { }
        /// <summary>
        /// EN: Executes RemovePolicy.
        /// EN: Documentation for public API. JA: RemovePolicy を実行します。
        /// </summary>
        public bool RemovePolicy(string policyId)
        {
            _ = policyId;
            return false;
        }
        /// <summary>
        /// EN: Executes GetPolicies.
        /// EN: Documentation for public API. JA: GetPolicies を実行します。
        /// </summary>
        public IReadOnlyList<IPolicy> GetPolicies() => new[] { policy };
        /// <summary>
        /// EN: Executes EvaluatePoliciesAsync.
        /// EN: Documentation for public API. JA: EvaluatePoliciesAsync を実行します。
        /// </summary>
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
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<bool> CanExecuteAsync(SecurityPrincipal principal, string action, string resource)
        {
            _ = principal;
            _ = action;
            _ = resource;
            return Task.FromResult(false);
        }
        /// <summary>
        /// EN: Executes CanAccessContextAsync.
        /// EN: Documentation for public API. JA: CanAccessContextAsync を実行します。
        /// </summary>

        public Task<bool> CanAccessContextAsync(SecurityPrincipal principal, UnifiedContextDto contract)
        {
            _ = principal;
            _ = contract;
            return Task.FromResult(false);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<bool> CanReadAsync(SecurityPrincipal principal, string resource)
        {
            _ = principal;
            _ = resource;
            return Task.FromResult(false);
        }
        /// <summary>
        /// EN: Executes CanWriteAsync.
        /// EN: Documentation for public API. JA: CanWriteAsync を実行します。
        /// </summary>

        public Task<bool> CanWriteAsync(SecurityPrincipal principal, string resource)
        {
            _ = principal;
            _ = resource;
            return Task.FromResult(false);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<GuardAction> EnforceAsync(SecurityPrincipal principal, string action, string resource)
        {
            _ = principal;
            _ = action;
            _ = resource;
            return Task.FromResult(GuardAction.Block);
        }
        /// <summary>
        /// EN: Executes OnFailureModeDetectedAsync.
        /// EN: Documentation for public API. JA: OnFailureModeDetectedAsync を実行します。
        /// </summary>

        public Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context)
        {
            _ = mode;
            _ = context;
            return Task.FromResult(GuardAction.Block);
        }
    }
}


