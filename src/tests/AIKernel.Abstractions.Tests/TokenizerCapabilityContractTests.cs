using AIKernel.Abstractions.Execution;
using AIKernel.Abstractions.Models;
using AIKernel.Dtos.Tokenization;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class TokenizerCapabilityContractTests
{
    [Fact]
    public void CompositeTokenizerExposesGranularTokenizerCapabilities()
    {
        ITokenizer tokenizer = new FullTokenizer();

        Assert.IsAssignableFrom<ITokenizerIdentity>(tokenizer);
        Assert.IsAssignableFrom<ITextTokenizer>(tokenizer);
        Assert.IsAssignableFrom<ITokenCounter>(tokenizer);
        Assert.IsAssignableFrom<ITokenDecoder>(tokenizer);
        Assert.IsAssignableFrom<ITokenizerStatisticsProvider>(tokenizer);
        Assert.IsAssignableFrom<ITokenizerModelSupport>(tokenizer);
        Assert.IsAssignableFrom<IPhysicalCardinalityAdvisor>(tokenizer);
        Assert.IsAssignableFrom<IPaddingInfoProvider>(tokenizer);
    }

    [Fact]
    /// <summary>
    /// Executes a test helper member. JA: テスト用のメンバーを実行します。
    /// </summary>
    public void TokenCounterDoesNotExposeTokenizeOrDecodeCapabilities()
    {
        ITokenCounter counter = new CountOnlyTokenizer();

        Assert.False(counter is ITextTokenizer);
        Assert.False(counter is ITokenDecoder);
        Assert.False(counter is IPaddingInfoProvider);
    }

    private sealed class CountOnlyTokenizer : ITokenCounter
    {
        public int CountTokens(string text)
        {
            return 0;
        }
    }

    private sealed class FullTokenizer : ITokenizer
    {
        /// <summary>
        /// Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string TokenizerProfileId => "profile";

        public string Name => "Tokenizer";

        public IReadOnlyList<Token> Tokenize(string text)
        {
            return [];
        }

        public int CountTokens(string text)
        {
            return 0;
        }

        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public string Decode(IReadOnlyList<Token> tokens)
        {
            return string.Empty;
        }

        public TokenizerStatistics GetStatistics()
        {
            return null!;
        }

        public bool SupportsModel(string modelName)
        {
            return false;
        }

        /// <summary>
        /// Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public int GetPhysicalCardinality(int logicalTokenCount, string deviceType)
        {
            return logicalTokenCount;
        }

        public PaddingInfo GetPaddingInfo(int logicalTokenCount, int physicalCardinality)
        {
            return null!;
        }
    }
}
