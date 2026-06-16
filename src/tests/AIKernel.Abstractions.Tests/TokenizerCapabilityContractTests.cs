using AIKernel.Abstractions.Execution;
using AIKernel.Abstractions.Models;
using AIKernel.Dtos.Tokenization;

namespace AIKernel.Abstractions.Tests;

/// <summary>
/// EN: Defines a test helper type. JA: テスト用の型を定義します。
/// </summary>
public sealed class TokenizerCapabilityContractTests
{
    /// <summary>
    /// EN: Executes CompositeTokenizerExposesGranularTokenizerCapabilities.
    /// EN: Documentation for public API. JA: CompositeTokenizerExposesGranularTokenizerCapabilities を実行します。
    /// </summary>
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
    /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
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
        /// <summary>
        /// EN: Executes CountTokens.
        /// EN: Documentation for public API. JA: CountTokens を実行します。
        /// </summary>
        public int CountTokens(string text)
        {
            return 0;
        }
    }

    private sealed class FullTokenizer : ITokenizer
    {
        /// <summary>
        /// EN: Gets a test helper value. JA: テスト用の値を取得します。
        /// </summary>
        public string TokenizerProfileId => "profile";
        /// <summary>
        /// EN: Gets Name.
        /// EN: Documentation for public API. JA: Name を取得します。
        /// </summary>

        public string Name => "Tokenizer";
        /// <summary>
        /// EN: Executes Tokenize.
        /// EN: Documentation for public API. JA: Tokenize を実行します。
        /// </summary>

        public IReadOnlyList<Token> Tokenize(string text)
        {
            return [];
        }
        /// <summary>
        /// EN: Executes CountTokens.
        /// EN: Documentation for public API. JA: CountTokens を実行します。
        /// </summary>

        public int CountTokens(string text)
        {
            return 0;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public string Decode(IReadOnlyList<Token> tokens)
        {
            return string.Empty;
        }
        /// <summary>
        /// EN: Executes GetStatistics.
        /// EN: Documentation for public API. JA: GetStatistics を実行します。
        /// </summary>

        public TokenizerStatistics GetStatistics()
        {
            return null!;
        }
        /// <summary>
        /// EN: Executes SupportsModel.
        /// EN: Documentation for public API. JA: SupportsModel を実行します。
        /// </summary>

        public bool SupportsModel(string modelName)
        {
            return false;
        }

        /// <summary>
        /// EN: Executes a test helper member. JA: テスト用のメンバーを実行します。
        /// </summary>
        public int GetPhysicalCardinality(int logicalTokenCount, string deviceType)
        {
            return logicalTokenCount;
        }
        /// <summary>
        /// EN: Executes GetPaddingInfo.
        /// EN: Documentation for public API. JA: GetPaddingInfo を実行します。
        /// </summary>

        public PaddingInfo GetPaddingInfo(int logicalTokenCount, int physicalCardinality)
        {
            return null!;
        }
    }
}
