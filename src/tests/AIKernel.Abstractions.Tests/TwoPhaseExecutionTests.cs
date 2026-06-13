using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Execution;
using AIKernel.Abstractions.Models;
using Xunit;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// UC-02（Structure フェーズ）と UC-04（生成と出力整形）の整合テスト。
/// Defines the TwoPhaseExecutionTests contract. JA: TwoPhaseExecutionTests の公開契約を定義します。
/// </summary>
public class TwoPhaseExecutionTests
{
    private static bool IsEmpty(RawLogic logic)
    {
        return string.IsNullOrWhiteSpace(logic.SerializedRepresentation);
    }

    /// <summary>
    /// テスト用の IThoughtProcess 実装
    /// Gets the RequiredCapacity value. JA: RequiredCapacity を取得します。
    /// </summary>
    private class TestThoughtProcess : IThoughtProcess
    {
        public ModelCapacityVector RequiredCapacity { get; } = new(reasoningDepth: 0.8f);

        public Task<RawLogic> BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default)
        {
            var buffer = orchestrationContext.GetOrchestrationBuffer();
            var logicContent = string.Join(" ", buffer.Fragments.Select(f => f.Content));
            return Task.FromResult(new RawLogic($"LOGIC[{logicContent}]"));
        }
    }

    /// <summary>
    /// テスト用の IOutputPolisher 実装
    /// Gets the RequiredCapacity value. JA: RequiredCapacity を取得します。
    /// </summary>
    private class TestOutputPolisher : IOutputPolisher
    {
        public ModelCapacityVector RequiredCapacity { get; } = new(linguisticFluidity: 0.9f, structuralIntegrity: 0.8f);

        public Task<string> RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default)
        {
            if (IsEmpty(logic))
                throw new InvalidOperationException("Logic is empty");

            var buffer = expressionContext.ExpressionBuffer;
            var tone = buffer.Fragments.FirstOrDefault()?.Tone ?? "Neutral";
            var output = $"OUTPUT[{logic.SerializedRepresentation}] in tone: {tone}";
            return Task.FromResult(output);
        }
    }

    /// <summary>
    /// テスト用の IContextCollection 実装
    /// Defines the TestContextCollection helper. JA: TestContextCollection 操作を実行します。
    /// </summary>
    private class TestContextCollection : IContextCollection
    {
        private readonly List<ContextFragment> _fragments;

        public TestContextCollection(params ContextFragment[] fragments)
        {
            _fragments = fragments.ToList();
        }

        public IEnumerable<ContextFragment> GetAll() => _fragments;

        /// <summary>
        /// Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public IEnumerable<ContextFragment> GetByCategory(ContextCategory category) =>
            _fragments.Where(f => f.Category == category);

        public OrchestrationBuffer GetOrchestrationBuffer() =>
            new OrchestrationBuffer(GetByCategory(ContextCategory.Orchestration));

        public ExpressionBuffer GetExpressionBuffer() =>
            new ExpressionBuffer(GetByCategory(ContextCategory.Expression)
                .Cast<ExpressionFragment>());

        public MaterialBuffer GetMaterialBuffer() =>
            new MaterialBuffer(GetByCategory(ContextCategory.Material));

        /// <summary>
        /// Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public HistoryBuffer GetHistoryBuffer() =>
            new HistoryBuffer(GetByCategory(ContextCategory.History));
    }

    [Fact]
    public async Task TwoPhaseExecution_BuildLogic_ShouldGenerateRawLogic()
    {
        // UC-02: Structure フェーズでタスク分解ロジックを生成
        // Arrange
        var thoughtProcess = new TestThoughtProcess();
        var orchestrationFragment = new ContextFragment
        {
            FragmentId = "orch-1",
            Category = ContextCategory.Orchestration,
            Content = "Do something",
            Priority = 1.0
        };
        var context = new TestContextCollection(orchestrationFragment);

        // Act
        var logic = await thoughtProcess.BuildLogicAsync(context);

        // Assert
        Assert.NotNull(logic);
        Assert.False(IsEmpty(logic));
        Assert.Contains("Do something", logic.SerializedRepresentation);
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public async Task TwoPhaseExecution_Render_ShouldApplyExpressionContext()
    {
        // UC-04: 生成結果を Expression コンテキストで整形
        // Arrange
        var polisher = new TestOutputPolisher();
        var logic = new RawLogic("TEST_LOGIC");
        var expressionFragment = new ExpressionFragment
        {
            FragmentId = "expr-1",
            Category = ContextCategory.Expression,
            Content = "Expression rules",
            Tone = "Formal",
            LanguageTag = "ja-JP"
        };
        var buffer = new ExpressionBuffer(new[] { expressionFragment });
        var exprContext = new ExpressionContext(buffer);

        // Act
        var output = await polisher.RenderAsync(logic, exprContext);

        // Assert
        Assert.NotNull(output);
        Assert.Contains("TEST_LOGIC", output);
        Assert.Contains("Formal", output);
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public async Task TwoPhaseExecution_EmptyLogic_ShouldThrowException()
    {
        // Arrange
        var polisher = new TestOutputPolisher();
        var emptyLogic = new RawLogic(string.Empty);
        var buffer = new ExpressionBuffer(Array.Empty<ExpressionFragment>());
        var exprContext = new ExpressionContext(buffer);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(
            () => polisher.RenderAsync(emptyLogic, exprContext));
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void RawLogicSerializedRepresentation_ShouldSupportWhitespaceChecks()
    {
        // Act
        var emptyLogic1 = new RawLogic(string.Empty);
        var emptyLogic2 = new RawLogic("   ");
        var nonEmptyLogic = new RawLogic("content");

        // Assert
        Assert.True(IsEmpty(emptyLogic1));
        Assert.True(IsEmpty(emptyLogic2));
        Assert.False(IsEmpty(nonEmptyLogic));
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void ExecutionResult_ShouldEncapsulateLogicAndOutput()
    {
        // Two-Phase 実行結果 DTO（現行契約: ExecutionResult）を検証
        // Arrange
        var logic = new RawLogic("LOGIC_DATA");
        var finalOutput = "Final output text";

        // Act
        var result = new ExecutionResult
        {
            Logic = logic,
            FinalOutput = finalOutput,
            IsSuccessful = true,
            ElapsedMilliseconds = 100
        };

        // Assert
        Assert.NotNull(result);
        Assert.Equal("LOGIC_DATA", result.Logic.SerializedRepresentation);
        Assert.Equal("Final output text", result.FinalOutput);
        Assert.True(result.IsSuccessful);
        Assert.Equal(100, result.ElapsedMilliseconds);
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public async Task TwoPhaseExecution_CompleteFlow_ShouldProduceExecutionResult()
    {
        // Arrange
        var thoughtProcess = new TestThoughtProcess();
        var polisher = new TestOutputPolisher();

        var orchestrationFragment = new ContextFragment
        {
            FragmentId = "orch-1",
            Category = ContextCategory.Orchestration,
            Content = "Process this",
            Priority = 1.0
        };

        var expressionFragment = new ExpressionFragment
        {
            FragmentId = "expr-1",
            Category = ContextCategory.Expression,
            Content = "Expression rules",
            Tone = "Informal",
            LanguageTag = "ja-JP"
        };

        var context = new TestContextCollection(orchestrationFragment, expressionFragment);

        // Act
        var startTime = DateTime.UtcNow;
        var logic = await thoughtProcess.BuildLogicAsync(context);
        var exprBuffer = context.GetExpressionBuffer();
        var exprContext = new ExpressionContext(exprBuffer);
        var output = await polisher.RenderAsync(logic, exprContext);
        var elapsed = (int)(DateTime.UtcNow - startTime).TotalMilliseconds;

        var result = new ExecutionResult
        {
            Logic = logic,
            FinalOutput = output,
            IsSuccessful = true,
            ElapsedMilliseconds = elapsed
        };

        // Assert
        Assert.NotNull(result);
        Assert.False(IsEmpty(result.Logic));
        Assert.NotEmpty(result.FinalOutput);
        Assert.True(result.IsSuccessful);
        Assert.True(result.ElapsedMilliseconds >= 0);
    }
}
