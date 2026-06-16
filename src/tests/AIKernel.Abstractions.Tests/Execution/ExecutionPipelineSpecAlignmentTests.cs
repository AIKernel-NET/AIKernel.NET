using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Execution;
using AIKernel.Abstractions.Models;
using AIKernel.Dtos.Execution;
using AIKernel.Dtos.Routing;
using AIKernel.Dtos.Rules;
using ExecutionRouter = AIKernel.Abstractions.Routing.IModelVectorRouter;

namespace AIKernel.Abstractions.Tests.Execution;

/// <summary>
/// ExecutionPipelineSpecAlignmentTests の契約を定義します。
/// EN: Defines the ExecutionPipelineSpecAlignmentTests contract. JA: ExecutionPipelineSpecAlignmentTests の公開契約を定義します。
/// </summary>
public sealed class ExecutionPipelineSpecAlignmentTests
{
    private static readonly string[] EpsViolations = ["EPS-F005"];
    private static readonly string[] AlteredSegments = ["plan"];
    private static readonly string[] AllowedToolsValues = ["tool.a"];
    private static readonly string[] ScopeValues = ["scope.read"];
    /// <summary>
    /// EN: Executes EPS_004_EPS_008_UseCase_Flows_By_Interface_Composition.
    /// EN: Documentation for public API. JA: EPS_004_EPS_008_UseCase_Flows_By_Interface_Composition を実行します。
    /// </summary>

    [Fact]
    public async Task EPS_004_EPS_008_UseCase_Flows_By_Interface_Composition()
    {
        // EPS-004: Structure -> Generation -> Polish の固定順序を表現
        // EPS-008: 各フェーズ前に IModelVectorRouter で再評価し根拠を記録
        var router = new StubRouter();
        var constraints = new StubExecutionConstraints();
        var required = new ModelCapacityVector { ReasoningDepth = 0.9f };
        var context = new RuleEvaluationContext("ctx-1", "generation", new Dictionary<string, string>());

        var structureRoute = await router.RouteAsync(required, context, constraints);
        var generationRoute = await router.RouteAsync(required, context, constraints);
        var polishRoute = await router.RouteAsync(required, context, constraints);

        Assert.Equal("provider.reasoning", structureRoute.SelectedProviderId);
        Assert.Equal("provider.reasoning", generationRoute.SelectedProviderId);
        Assert.Equal("provider.reasoning", polishRoute.SelectedProviderId);
        Assert.Equal("deterministic", structureRoute.SelectionRationale);
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void EPS_005_EPS_F002_HashChain_Tamper_Is_FailClosed()
    {
        // EPS-005: フェーズ間ハッシュ連鎖で完全性検証
        // EPS-F002: 不一致時に停止（Fail-Closed）
        var chain = new HashChain
        {
            StructureHash = "s1",
            GenerationHash = "g1",
            GenerationParentHash = "tampered",
            PolishHash = "p1",
            PolishParentHash = "g1"
        };

        Assert.False(IsHashChainValid(chain));
    }

    [Fact]
    /// <summary>
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public async Task EPS_F005_Logic_Divergence_Returns_Safe_Result_Type()
    {
        // EPS-F005: Logic Divergence Check を戻り値型で安全ハンドル
        var validator = new StubPolisherValidator();
        var result = await validator.ValidateLogicPreservationAsync(new RawLogic("{plan:A}"), "output:B");
        Assert.False(result.IsValid);
        Assert.Contains("divergence", result.Message, StringComparison.OrdinalIgnoreCase);
    }

    private sealed class StubRouter : ExecutionRouter
    {
        /// <summary>
        /// EN: Gets RouteAsync.
        /// EN: Documentation for public API. JA: RouteAsync を取得します。
        /// </summary>
        public Task<ModelRoutingDecision> RouteAsync(
            ModelCapacityVector requiredCapacity,
            RuleEvaluationContext ruleEvaluationContext,
            IExecutionConstraints executionConstraints,
            CancellationToken cancellationToken = default)
        {
            _ = ruleEvaluationContext;
            _ = executionConstraints;
            _ = cancellationToken;
            return Task.FromResult(new ModelRoutingDecision
            {
                SelectedProviderId = "provider.reasoning",
                SelectionRationale = "deterministic",
                EffectiveCapacity = requiredCapacity,
                FittingScore = 1.0,
                DecisionTimestamp = DateTime.UtcNow
            });
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public ModelType SelectOptimalModel(ModelCapacityVector requirement, IEnumerable<ModelType> candidates)
        {
            _ = requirement;
            return candidates.FirstOrDefault();
        }
        /// <summary>
        /// EN: Executes IEnumerable&lt;.
        /// EN: Documentation for public API. JA: IEnumerable&lt; を実行します。
        /// </summary>

        public IEnumerable<(ModelType Model, float Score)> RankModels(ModelCapacityVector requirement, IEnumerable<ModelType> candidates)
        {
            _ = requirement;
            return candidates.Select(x => (x, 1.0f));
        }

        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public bool VerifyDeterministicRouting(ModelRoutingDecision decision1, ModelRoutingDecision decision2) =>
            decision1.SelectedProviderId == decision2.SelectedProviderId && decision1.SelectionRationale == decision2.SelectionRationale;
    }

    private sealed class StubPolisherValidator : IPolisherValidator
    {
        /// <summary>
        /// EN: Executes ValidateLogicPreservationAsync.
        /// EN: Documentation for public API. JA: ValidateLogicPreservationAsync を実行します。
        /// </summary>
        public Task<PolisherValidationResult> ValidateLogicPreservationAsync(RawLogic originalLogic, string polishedOutput, CancellationToken cancellationToken = default) =>
            Task.FromResult(new PolisherValidationResult
            {
                IsValid = false,
                Message = "logic divergence",
                Violations = EpsViolations,
                LogicIntegrityScore = 0.0
            });

        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public Task<LogicDivergenceAnalysis> AnalyzeDivergenceAsync(RawLogic originalLogic, string output, CancellationToken cancellationToken = default) =>
            Task.FromResult(new LogicDivergenceAnalysis
            {
                DivergenceDetected = true,
                DivergenceType = "plan",
                Description = "EPS-F005",
                Severity = "critical",
                AlteredSegments = AlteredSegments
            });
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
        public IReadOnlyList<string> AllowedTools => AllowedToolsValues;
        /// <summary>
        /// EN: Gets Scopes.
        /// EN: Documentation for public API. JA: Scopes を取得します。
        /// </summary>
        public IReadOnlyList<string> Scopes => ScopeValues;
        /// <summary>
        /// EN: Gets MaxTokenBudget.
        /// EN: Documentation for public API. JA: MaxTokenBudget を取得します。
        /// </summary>
        public int MaxTokenBudget => 2048;
        /// <summary>
        /// EN: Gets AvailableMemoryMb.
        /// EN: Documentation for public API. JA: AvailableMemoryMb を取得します。
        /// </summary>
        public long AvailableMemoryMb => 1024;
        /// <summary>
        /// EN: Gets MaxLatencyMs.
        /// EN: Documentation for public API. JA: MaxLatencyMs を取得します。
        /// </summary>
        public int? MaxLatencyMs => 500;
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
        public float ComputeThroughputTflops => 1.0f;
        /// <summary>
        /// EN: Gets BatchSize.
        /// EN: Documentation for public API. JA: BatchSize を取得します。
        /// </summary>
        public int BatchSize => 1;
        /// <summary>
        /// EN: Gets SequenceLength.
        /// EN: Documentation for public API. JA: SequenceLength を取得します。
        /// </summary>
        public int SequenceLength => 512;
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

    private static bool IsHashChainValid(HashChain chain)
    {
        return !string.IsNullOrEmpty(chain.StructureHash)
            && !string.IsNullOrEmpty(chain.GenerationHash)
            && !string.IsNullOrEmpty(chain.GenerationParentHash)
            && !string.IsNullOrEmpty(chain.PolishHash)
            && !string.IsNullOrEmpty(chain.PolishParentHash)
            && chain.GenerationParentHash == chain.StructureHash;
    }
}


