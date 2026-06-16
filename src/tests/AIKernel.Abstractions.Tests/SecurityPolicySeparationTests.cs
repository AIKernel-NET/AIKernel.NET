using AIKernel.Abstractions.Events;
using AIKernel.Abstractions.Prompt;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Security;
using AIKernel.Dtos.Security;
using SecurityPrincipal = AIKernel.Abstractions.Security.IPrincipal;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class SecurityPolicySeparationTests
{
    /// <summary>
    /// EN: Executes CompositeGuardExposesDecisionResourceEnforcementAndFailureCapabilities.
    /// EN: Documentation for public API. JA: CompositeGuardExposesDecisionResourceEnforcementAndFailureCapabilities を実行します。
    /// </summary>
    [Fact]
    public void CompositeGuardExposesDecisionResourceEnforcementAndFailureCapabilities()
    {
        IGuard guard = new FullGuard();

        Assert.IsAssignableFrom<IGuardEvaluator>(guard);
        Assert.IsAssignableFrom<IResourceAccessGuard>(guard);
        Assert.IsAssignableFrom<IGuardEnforcer>(guard);
        Assert.IsAssignableFrom<IGuardFailureHandler>(guard);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void GuardEvaluatorDoesNotExposeFailureHandling()
    {
        IGuardEvaluator evaluator = new DecisionOnlyGuard();

        Assert.False(evaluator is IGuardFailureHandler);
        Assert.False(evaluator is IResourceAccessGuard);
        Assert.False(evaluator is IGuardEnforcer);
    }
    /// <summary>
    /// EN: Executes CompositePdpExposesDecisionRegistrySourceAndPolicyEvaluation.
    /// EN: Documentation for public API. JA: CompositePdpExposesDecisionRegistrySourceAndPolicyEvaluation を実行します。
    /// </summary>

    [Fact]
    public void CompositePdpExposesDecisionRegistrySourceAndPolicyEvaluation()
    {
        IPdp pdp = new FullPdp();

        Assert.IsAssignableFrom<IPolicyDecisionPoint>(pdp);
        Assert.IsAssignableFrom<IPolicyRegistry>(pdp);
        Assert.IsAssignableFrom<IPolicySource>(pdp);
        Assert.IsAssignableFrom<IPolicyDecisionEvaluator>(pdp);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void PolicyDecisionPointDoesNotExposePolicyRegistry()
    {
        IPolicyDecisionPoint decisionPoint = new DecisionOnlyPdp();

        Assert.False(decisionPoint is IPolicyRegistry);
        Assert.False(decisionPoint is IPolicySource);
    }
    /// <summary>
    /// EN: Executes CompositeRulesEngineExposesRegistryEvaluationAndValidationCapabilities.
    /// EN: Documentation for public API. JA: CompositeRulesEngineExposesRegistryEvaluationAndValidationCapabilities を実行します。
    /// </summary>

    [Fact]
    public void CompositeRulesEngineExposesRegistryEvaluationAndValidationCapabilities()
    {
        IRulesEngine engine = new FullRulesEngine();

        Assert.IsAssignableFrom<IProvider>(engine);
        Assert.IsAssignableFrom<IRuleRegistry>(engine);
        Assert.IsAssignableFrom<IRuleEvaluator>(engine);
        Assert.IsAssignableFrom<IPreExecutionRuleValidator>(engine);
        Assert.IsAssignableFrom<IPostExecutionRuleValidator>(engine);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void RuleEvaluatorDoesNotExposeRegistryOrPostValidation()
    {
        IRuleEvaluator evaluator = new RuleEvaluationOnlyEngine();

        Assert.False(evaluator is IRuleRegistry);
        Assert.False(evaluator is IPostExecutionRuleValidator);
    }
    /// <summary>
    /// EN: Executes CompositeAuditLoggerExposesCategorySpecificAuditCapabilities.
    /// EN: Documentation for public API. JA: CompositeAuditLoggerExposesCategorySpecificAuditCapabilities を実行します。
    /// </summary>

    [Fact]
    public void CompositeAuditLoggerExposesCategorySpecificAuditCapabilities()
    {
        IAuditLogger logger = new FullAuditLogger();

        Assert.IsAssignableFrom<IAuditEventWriter>(logger);
        Assert.IsAssignableFrom<IExecutionAuditLogger>(logger);
        Assert.IsAssignableFrom<IGuardAuditLogger>(logger);
        Assert.IsAssignableFrom<IPipelineAuditLogger>(logger);
        Assert.IsAssignableFrom<IProviderAuditLogger>(logger);
        Assert.IsAssignableFrom<ITransferTraceLogger>(logger);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ExecutionAuditLoggerDoesNotExposeGuardOrTransferAudit()
    {
        IExecutionAuditLogger logger = new ExecutionOnlyAuditLogger();

        Assert.False(logger is IGuardAuditLogger);
        Assert.False(logger is ITransferTraceLogger);
    }

    private sealed class DecisionOnlyGuard : IGuardEvaluator
    {
        /// <summary>
        /// EN: Executes CanExecuteAsync.
        /// EN: Documentation for public API. JA: CanExecuteAsync を実行します。
        /// </summary>
        public Task<bool> CanExecuteAsync(SecurityPrincipal principal, string action, string resource)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<bool> CanAccessContextAsync(SecurityPrincipal principal, UnifiedContextDto contract)
        {
            return Task.FromResult(true);
        }
    }

    private sealed class FullGuard : IGuard
    {
        /// <summary>
        /// EN: Executes CanExecuteAsync.
        /// EN: Documentation for public API. JA: CanExecuteAsync を実行します。
        /// </summary>
        public Task<bool> CanExecuteAsync(SecurityPrincipal principal, string action, string resource)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<bool> CanAccessContextAsync(SecurityPrincipal principal, UnifiedContextDto contract)
        {
            return Task.FromResult(true);
        }
        /// <summary>
        /// EN: Executes CanReadAsync.
        /// EN: Documentation for public API. JA: CanReadAsync を実行します。
        /// </summary>

        public Task<bool> CanReadAsync(SecurityPrincipal principal, string resource)
        {
            return Task.FromResult(true);
        }
        /// <summary>
        /// EN: Executes CanWriteAsync.
        /// EN: Documentation for public API. JA: CanWriteAsync を実行します。
        /// </summary>

        public Task<bool> CanWriteAsync(SecurityPrincipal principal, string resource)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<GuardAction> EnforceAsync(SecurityPrincipal principal, string action, string resource)
        {
            return Task.FromResult(GuardAction.Continue);
        }
        /// <summary>
        /// EN: Executes OnFailureModeDetectedAsync.
        /// EN: Documentation for public API. JA: OnFailureModeDetectedAsync を実行します。
        /// </summary>

        public Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context)
        {
            return Task.FromResult(GuardAction.Block);
        }
    }

    private sealed class DecisionOnlyPdp : IPolicyDecisionPoint
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<AccessDecision> EvaluateAsync(AccessRequest request)
        {
            return Task.FromResult<AccessDecision>(null!);
        }
    }

    private sealed class FullPdp : IPdp
    {
        /// <summary>
        /// EN: Executes EvaluateAsync.
        /// EN: Documentation for public API. JA: EvaluateAsync を実行します。
        /// </summary>
        public Task<AccessDecision> EvaluateAsync(AccessRequest request)
        {
            return Task.FromResult<AccessDecision>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public void AddPolicy(IPolicy policy)
        {
        }
        /// <summary>
        /// EN: Executes RemovePolicy.
        /// EN: Documentation for public API. JA: RemovePolicy を実行します。
        /// </summary>

        public bool RemovePolicy(string policyId)
        {
            return true;
        }
        /// <summary>
        /// EN: Executes GetPolicies.
        /// EN: Documentation for public API. JA: GetPolicies を実行します。
        /// </summary>

        public IReadOnlyList<IPolicy> GetPolicies()
        {
            return [];
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<PolicyEvaluationResult>(null!);
        }
    }

    private sealed class RuleEvaluationOnlyEngine : IRuleEvaluator
    {
        /// <summary>
        /// EN: Gets EvaluateAsync.
        /// EN: Documentation for public API. JA: EvaluateAsync を取得します。
        /// </summary>
        public Task<RuleEvaluationResult> EvaluateAsync(
            string ruleId,
            IReadOnlyDictionary<string, string> context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RuleEvaluationResult>(null!);
        }
    }

    private sealed class FullRulesEngine : IProvider, IRulesEngine
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string ProviderId => "rules";
        /// <summary>
        /// EN: Gets Name.
        /// EN: Documentation for public API. JA: Name を取得します。
        /// </summary>

        public string Name => "Rules";
        /// <summary>
        /// EN: Gets Version.
        /// EN: Documentation for public API. JA: Version を取得します。
        /// </summary>

        public string Version => "0.0.2";
        /// <summary>
        /// EN: Executes GetCapabilities.
        /// EN: Documentation for public API. JA: GetCapabilities を実行します。
        /// </summary>

        public IProviderCapabilities GetCapabilities()
        {
            return null!;
        }
        /// <summary>
        /// EN: Executes IsAvailableAsync.
        /// EN: Documentation for public API. JA: IsAvailableAsync を実行します。
        /// </summary>

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes ShutdownAsync.
        /// EN: Documentation for public API. JA: ShutdownAsync を実行します。
        /// </summary>

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes GetHealthAsync.
        /// EN: Documentation for public API. JA: GetHealthAsync を実行します。
        /// </summary>

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task RegisterRuleAsync(string ruleId, IPromptRule rule)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// EN: Executes GetRuleAsync.
        /// EN: Documentation for public API. JA: GetRuleAsync を実行します。
        /// </summary>

        public Task<IPromptRule?> GetRuleAsync(string ruleId)
        {
            return Task.FromResult<IPromptRule?>(null);
        }
        /// <summary>
        /// EN: Executes DeleteRuleAsync.
        /// EN: Documentation for public API. JA: DeleteRuleAsync を実行します。
        /// </summary>

        public Task<bool> DeleteRuleAsync(string ruleId)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<IReadOnlyList<IPromptRule>> ListRulesAsync()
        {
            IReadOnlyList<IPromptRule> rules = [];
            return Task.FromResult(rules);
        }
        /// <summary>
        /// EN: Gets EvaluateAsync.
        /// EN: Documentation for public API. JA: EvaluateAsync を取得します。
        /// </summary>

        public Task<RuleEvaluationResult> EvaluateAsync(
            string ruleId,
            IReadOnlyDictionary<string, string> context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RuleEvaluationResult>(null!);
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public Task<RuleValidationResult> ValidatePrePromptAsync(
            string ruleId,
            IReadOnlyDictionary<string, string> prepromptContext,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RuleValidationResult>(null!);
        }
        /// <summary>
        /// EN: Gets ValidatePostPromptAsync.
        /// EN: Documentation for public API. JA: ValidatePostPromptAsync を取得します。
        /// </summary>

        public Task<RuleValidationResult> ValidatePostPromptAsync(
            string ruleId,
            IReadOnlyDictionary<string, string> postpromptContext,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RuleValidationResult>(null!);
        }
    }

    private sealed class ExecutionOnlyAuditLogger : IExecutionAuditLogger
    {
        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
    }

    private sealed class FullAuditLogger : IAuditLogger
    {
        /// <summary>
        /// EN: Executes LogAuditEventAsync.
        /// EN: Documentation for public API. JA: LogAuditEventAsync を実行します。
        /// </summary>
        public ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
        /// <summary>
        /// EN: Executes LogGuardEventAsync.
        /// EN: Documentation for public API. JA: LogGuardEventAsync を実行します。
        /// </summary>

        public ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
        /// <summary>
        /// EN: Executes LogPipelineEventAsync.
        /// EN: Documentation for public API. JA: LogPipelineEventAsync を実行します。
        /// </summary>

        public ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
        /// <summary>
        /// EN: Executes LogTransferTraceAsync.
        /// EN: Documentation for public API. JA: LogTransferTraceAsync を実行します。
        /// </summary>

        public ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
    }
}
