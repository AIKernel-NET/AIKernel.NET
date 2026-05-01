using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Execution;
using Xunit;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// IThoughtProcess, IOutputPolisher, ExecutionResult のテスト
/// </summary>
public class TwoPhaseExecutionTests
{
    /// <summary>
    /// テスト用の IThoughtProcess 実装
    /// </summary>
    private class TestThoughtProcess : IThoughtProcess
    {
        public Task<RawLogic> BuildLogicAsync(IContextCollection orchestrationContext, CancellationToken ct = default)
        {
            var buffer = orchestrationContext.GetOrchestrationBuffer();
            var logicContent = string.Join(" ", buffer.Fragments.Select(f => f.Content));
            return Task.FromResult(new RawLogic($"LOGIC[{logicContent}]"));
        }
    }

    /// <summary>
    /// テスト用の IOutputPolisher 実装
    /// </summary>
    private class TestOutputPolisher : IOutputPolisher
    {
        public Task<string> RenderAsync(RawLogic logic, ExpressionContext expressionContext, CancellationToken ct = default)
        {
            if (logic.IsEmpty)
                throw new InvalidOperationException("Logic is empty");

            var buffer = expressionContext.ExpressionBuffer;
            var tone = buffer.Fragments.FirstOrDefault()?.Tone ?? "Neutral";
            var output = $"OUTPUT[{logic.SerializedRepresentation}] in tone: {tone}";
            return Task.FromResult(output);
        }
    }

    /// <summary>
    /// テスト用の IContextCollection 実装
    /// </summary>
    private class TestContextCollection : IContextCollection
    {
        private readonly List<ContextFragment> _fragments;

        public TestContextCollection(params ContextFragment[] fragments)
        {
            _fragments = fragments.ToList();
        }

        public IEnumerable<ContextFragment> GetAll() => _fragments;

        public IEnumerable<ContextFragment> GetByCategory(ContextCategory category) =>
            _fragments.Where(f => f.Category == category);

        public OrchestrationBuffer GetOrchestrationBuffer() =>
            new OrchestrationBuffer(GetByCategory(ContextCategory.Orchestration));

        public ExpressionBuffer GetExpressionBuffer() =>
            new ExpressionBuffer(GetByCategory(ContextCategory.Expression)
                .Cast<ExpressionFragment>());

        public MaterialBuffer GetMaterialBuffer() =>
            new MaterialBuffer(GetByCategory(ContextCategory.Material));

        public HistoryBuffer GetHistoryBuffer() =>
            new HistoryBuffer(GetByCategory(ContextCategory.History));
    }

    [Fact]
    public async Task TwoPhaseExecution_BuildLogic_ShouldGenerateRawLogic()
    {
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
        Assert.False(logic.IsEmpty);
        Assert.Contains("Do something", logic.SerializedRepresentation);
    }

    [Fact]
    public async Task TwoPhaseExecution_Render_ShouldApplyExpressionContext()
    {
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
    public void RawLogic_IsEmpty_ShouldReturnTrueForWhitespace()
    {
        // Act
        var emptyLogic1 = new RawLogic(string.Empty);
        var emptyLogic2 = new RawLogic("   ");
        var nonEmptyLogic = new RawLogic("content");

        // Assert
        Assert.True(emptyLogic1.IsEmpty);
        Assert.True(emptyLogic2.IsEmpty);
        Assert.False(nonEmptyLogic.IsEmpty);
    }

    [Fact]
    public void ExecutionResult_ShouldEncapsulateLogicAndOutput()
    {
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
        Assert.False(result.Logic.IsEmpty);
        Assert.NotEmpty(result.FinalOutput);
        Assert.True(result.IsSuccessful);
        Assert.True(result.ElapsedMilliseconds >= 0);
    }
}
