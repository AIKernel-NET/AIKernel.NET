using AIKernel.Abstractions.Context;
using AIKernel.Abstractions.Material;
using AIKernel.Abstractions.Exceptions;
using Xunit;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// IContextCollection と ContextFragment のテスト
/// </summary>
public class ContextCollectionTests
{
    [Fact]
    public void GetByCategory_ShouldReturnFragmentsOfSpecificCategory()
    {
        // Arrange
        var orchestrationFragment = new ContextFragment
        {
            FragmentId = "orch-1",
            Category = ContextCategory.Orchestration,
            Content = "Orchestration content"
        };

        var expressionFragment = new ExpressionFragment
        {
            FragmentId = "expr-1",
            Category = ContextCategory.Expression,
            Content = "Expression content",
            Tone = "Formal"
        };

        var materialFragment = new ContextFragment
        {
            FragmentId = "mat-1",
            Category = ContextCategory.Material,
            Content = "Material content"
        };

        var allFragments = new ContextFragment[] { orchestrationFragment, expressionFragment, materialFragment };

        // Act & Assert
        var orchFragments = allFragments.Where(f => f.Category == ContextCategory.Orchestration).ToList();
        Assert.Single(orchFragments);
        Assert.Equal("orch-1", orchFragments[0].FragmentId);

        var exprFragments = allFragments.Where(f => f.Category == ContextCategory.Expression).ToList();
        Assert.Single(exprFragments);
        Assert.Equal("expr-1", exprFragments[0].FragmentId);

        var matFragments = allFragments.Where(f => f.Category == ContextCategory.Material).ToList();
        Assert.Single(matFragments);
        Assert.Equal("mat-1", matFragments[0].FragmentId);
    }

    [Fact]
    public void OrchestrationBuffer_ShouldConvertEnumerableToReadOnlyList()
    {
        // Arrange
        var fragments = new List<ContextFragment>
        {
            new ContextFragment { FragmentId = "1", Category = ContextCategory.Orchestration, Content = "Test 1" },
            new ContextFragment { FragmentId = "2", Category = ContextCategory.Orchestration, Content = "Test 2" }
        };

        // Act
        var buffer = new OrchestrationBuffer(fragments);

        // Assert
        Assert.Equal(2, buffer.Fragments.Count);
        Assert.Equal("1", buffer.Fragments[0].FragmentId);
        Assert.Equal("2", buffer.Fragments[1].FragmentId);
    }

    [Fact]
    public void ExpressionBuffer_ShouldContainExpressionFragments()
    {
        // Arrange
        var fragments = new List<ExpressionFragment>
        {
            new ExpressionFragment
            {
                FragmentId = "expr-1",
                Category = ContextCategory.Expression,
                Content = "Expression 1",
                Tone = "Formal",
                LanguageTag = "ja-JP"
            }
        };

        // Act
        var buffer = new ExpressionBuffer(fragments);

        // Assert
        Assert.Single(buffer.Fragments);
        Assert.Equal("Formal", buffer.Fragments[0].Tone);
        Assert.Equal("ja-JP", buffer.Fragments[0].LanguageTag);
    }

    [Fact]
    public void Buffer_WithEmptyEnumerable_ShouldCreateEmptyReadOnlyList()
    {
        // Act
        var buffer = new OrchestrationBuffer(Array.Empty<ContextFragment>());

        // Assert
        Assert.Empty(buffer.Fragments);
    }

    [Fact]
    public void Buffer_WithNullEnumerable_ShouldCreateEmptyReadOnlyList()
    {
        // Act
        var buffer = new OrchestrationBuffer(null!);

        // Assert
        Assert.Empty(buffer.Fragments);
    }
}
