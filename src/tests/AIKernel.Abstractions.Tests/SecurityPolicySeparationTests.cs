using AIKernel.Abstractions.Events;
using AIKernel.Abstractions.Prompt;
using AIKernel.Abstractions.Providers;
using AIKernel.Abstractions.Security;
using AIKernel.Dtos.Security;
using SecurityPrincipal = AIKernel.Abstractions.Security.IPrincipal;

namespace AIKernel.Abstractions.Tests;

public sealed class SecurityPolicySeparationTests
{
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
    public void GuardEvaluatorDoesNotExposeFailureHandling()
    {
        IGuardEvaluator evaluator = new DecisionOnlyGuard();

        Assert.False(evaluator is IGuardFailureHandler);
        Assert.False(evaluator is IResourceAccessGuard);
        Assert.False(evaluator is IGuardEnforcer);
    }

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
    public void PolicyDecisionPointDoesNotExposePolicyRegistry()
    {
        IPolicyDecisionPoint decisionPoint = new DecisionOnlyPdp();

        Assert.False(decisionPoint is IPolicyRegistry);
        Assert.False(decisionPoint is IPolicySource);
    }

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
    public void RuleEvaluatorDoesNotExposeRegistryOrPostValidation()
    {
        IRuleEvaluator evaluator = new RuleEvaluationOnlyEngine();

        Assert.False(evaluator is IRuleRegistry);
        Assert.False(evaluator is IPostExecutionRuleValidator);
    }

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
    public void ExecutionAuditLoggerDoesNotExposeGuardOrTransferAudit()
    {
        IExecutionAuditLogger logger = new ExecutionOnlyAuditLogger();

        Assert.False(logger is IGuardAuditLogger);
        Assert.False(logger is ITransferTraceLogger);
    }

    private sealed class DecisionOnlyGuard : IGuardEvaluator
    {
        public Task<bool> CanExecuteAsync(SecurityPrincipal principal, string action, string resource)
        {
            return Task.FromResult(true);
        }

        public Task<bool> CanAccessContextAsync(SecurityPrincipal principal, UnifiedContextDto contract)
        {
            return Task.FromResult(true);
        }
    }

    private sealed class FullGuard : IGuard
    {
        public Task<bool> CanExecuteAsync(SecurityPrincipal principal, string action, string resource)
        {
            return Task.FromResult(true);
        }

        public Task<bool> CanAccessContextAsync(SecurityPrincipal principal, UnifiedContextDto contract)
        {
            return Task.FromResult(true);
        }

        public Task<bool> CanReadAsync(SecurityPrincipal principal, string resource)
        {
            return Task.FromResult(true);
        }

        public Task<bool> CanWriteAsync(SecurityPrincipal principal, string resource)
        {
            return Task.FromResult(true);
        }

        public Task<GuardAction> EnforceAsync(SecurityPrincipal principal, string action, string resource)
        {
            return Task.FromResult(GuardAction.Continue);
        }

        public Task<GuardAction> OnFailureModeDetectedAsync(FailureMode mode, string context)
        {
            return Task.FromResult(GuardAction.Block);
        }
    }

    private sealed class DecisionOnlyPdp : IPolicyDecisionPoint
    {
        public Task<AccessDecision> EvaluateAsync(AccessRequest request)
        {
            return Task.FromResult<AccessDecision>(null!);
        }
    }

    private sealed class FullPdp : IPdp
    {
        public Task<AccessDecision> EvaluateAsync(AccessRequest request)
        {
            return Task.FromResult<AccessDecision>(null!);
        }

        public void AddPolicy(IPolicy policy)
        {
        }

        public bool RemovePolicy(string policyId)
        {
            return true;
        }

        public IReadOnlyList<IPolicy> GetPolicies()
        {
            return [];
        }

        public Task<PolicyEvaluationResult> EvaluatePoliciesAsync(UnifiedContextDto contract)
        {
            return Task.FromResult<PolicyEvaluationResult>(null!);
        }
    }

    private sealed class RuleEvaluationOnlyEngine : IRuleEvaluator
    {
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
        public string ProviderId => "rules";

        public string Name => "Rules";

        public string Version => "0.0.2";

        public IProviderCapabilities GetCapabilities()
        {
            return null!;
        }

        public Task<bool> IsAvailableAsync()
        {
            return Task.FromResult(true);
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public Task ShutdownAsync()
        {
            return Task.CompletedTask;
        }

        public Task<ProviderHealthStatus> GetHealthAsync()
        {
            return Task.FromResult(new ProviderHealthStatus(true, null, DateTime.UnixEpoch, 0));
        }

        public Task RegisterRuleAsync(string ruleId, IPromptRule rule)
        {
            return Task.CompletedTask;
        }

        public Task<IPromptRule?> GetRuleAsync(string ruleId)
        {
            return Task.FromResult<IPromptRule?>(null);
        }

        public Task<bool> DeleteRuleAsync(string ruleId)
        {
            return Task.FromResult(true);
        }

        public Task<IReadOnlyList<IPromptRule>> ListRulesAsync()
        {
            IReadOnlyList<IPromptRule> rules = [];
            return Task.FromResult(rules);
        }

        public Task<RuleEvaluationResult> EvaluateAsync(
            string ruleId,
            IReadOnlyDictionary<string, string> context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RuleEvaluationResult>(null!);
        }

        public Task<RuleValidationResult> ValidatePrePromptAsync(
            string ruleId,
            IReadOnlyDictionary<string, string> prepromptContext,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult<RuleValidationResult>(null!);
        }

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
        public ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
    }

    private sealed class FullAuditLogger : IAuditLogger
    {
        public ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }

        public ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default)
        {
            return ValueTask.CompletedTask;
        }
    }
}
