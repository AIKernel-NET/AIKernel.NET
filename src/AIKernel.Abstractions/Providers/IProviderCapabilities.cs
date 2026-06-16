namespace AIKernel.Abstractions.Providers;

using AIKernel.Abstractions.Models;

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Provider の静的な操作・データ種別 capability を公開します。
/// EN: Documentation for public API. JA: IProviderOperationCapabilities の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderOperationCapabilities']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderOperationCapabilities']" />
public interface IProviderOperationCapabilities
{
    /// <summary>
    /// EN: サポートされている操作の一覧を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> SupportedOperations { get; }

    /// <summary>
    /// EN: サポートされているデータタイプの一覧を取得します。
    /// EN: Documentation for public API. JA: SupportsOperation 操作を実行します。
    /// </summary>
    IReadOnlyList<string> SupportedDataTypes { get; }

    /// <summary>
    /// EN: 特定の操作をサポートしているかどうかを確認します。
    /// EN: Documentation for public API. JA: SupportsOperation 操作を実行します。
    /// </summary>
    /// <param name="operation">EN: Documentation for public API. JA: 操作名 operation パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: サポートしている場合は true 結果を返します。</returns>
    bool SupportsOperation(string operation);

    /// <summary>
    /// EN: 特定のデータタイプをサポートしているかどうかを確認します。
    /// EN: Documentation for public API. JA: SupportsDataType 操作を実行します。
    /// </summary>
    /// <param name="dataType">EN: Documentation for public API. JA: データタイプ dataType パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: サポートしている場合は true 結果を返します。</returns>
    bool SupportsDataType(string dataType);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Provider の接続・レート制限 capability を公開します。
/// EN: Documentation for public API. JA: IProviderConnectionCapabilities の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderConnectionCapabilities']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderConnectionCapabilities']" />
public interface IProviderConnectionCapabilities
{
    /// <summary>
    /// EN: 最大同時接続数を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int MaxConcurrentConnections { get; }

    /// <summary>
    /// EN: レート制限情報を取得します。
    /// EN: Documentation for public API. JA: IProviderCapacityVectorSource の公開契約を定義します。
    /// </summary>
    RateLimitInfo? RateLimit { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Provider の静的能力ベクトルを公開します。
/// EN: Documentation for public API. JA: IProviderCapacityVectorSource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapacityVectorSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapacityVectorSource']" />
public interface IProviderCapacityVectorSource
{
    /// <summary>
    /// プロバイダー（特にモデル）の能力ベクトルを取得します。
    /// このベクトルはプロバイダー自体の「能力の履歴書」として機能します。
    /// EN: 静的な環境での能力を表します。
    /// EN: Documentation for public API. JA: IDynamicProviderCapacitySource の公開契約を定義します。
    /// </summary>
    ModelCapacityVector Vector { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 実行制約に基づく動的能力を公開します。
/// EN: Documentation for public API. JA: IDynamicProviderCapacitySource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IDynamicProviderCapacitySource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IDynamicProviderCapacitySource']" />
public interface IDynamicProviderCapacitySource
{
    /// <summary>
    /// 実行制約に基づいて動的に能力ベクトルを取得します。
    /// EN: NPU環境など、基数やメモリが非線形に性能に影響する場合に使用。
    /// EN: Documentation for public API. JA: GetDynamicCapacities 操作を実行します。
    /// </summary>
    /// <param name="constraints">EN: Documentation for public API. JA: 実行制約条件 constraints パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: 制約下での動的能力ベクトル 結果を返します。</returns>
    IDictionary<string, float>? GetDynamicCapacities(IExecutionConstraints constraints);
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: Provider の能力プロファイルを公開します。
/// EN: Documentation for public API. JA: IProviderProfileSource の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderProfileSource']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderProfileSource']" />
public interface IProviderProfileSource
{
    /// <summary>
    /// このプロバイダーの能力プロファイルを取得します。
    /// EN: 基数による性能変化をプロファイル曲線として取得できます。
    /// EN: Documentation for public API. JA: GetCapabilityProfile 操作を実行します。
    /// </summary>
    /// <returns>EN: Documentation for public API. JA: 能力プロファイル、有効でない場合は null 結果を返します。</returns>
    ICapabilityProfile? GetCapabilityProfile();
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// EN: 量子化サポート情報を公開します。
/// EN: Documentation for public API. JA: IQuantizationSupport の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQuantizationSupport']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQuantizationSupport']" />
public interface IQuantizationSupport
{
    /// <summary>
    /// EN: 指定された量子化レベルをサポートしているか確認します。
    /// EN: Documentation for public API. JA: SupportsQuantization 操作を実行します。
    /// </summary>
    /// <param name="quantizationLevel">EN: Documentation for public API. JA: 量子化レベル（例："INT8", "FP16", "FP32"） quantizationLevel パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: サポートしている場合は true 結果を返します。</returns>
    bool SupportsQuantization(string quantizationLevel);
}

/// <summary>
/// Phase 1 Query Processing に関する Provider capability を公開します。
/// EN: Query 補間・分解・ルーティングは Core 実装ではなく、Provider または拡張実装が宣言する能力として扱います。
/// EN: Documentation for public API. JA: IQueryProcessingCapabilities の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQueryProcessingCapabilities']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IQueryProcessingCapabilities']" />
public interface IQueryProcessingCapabilities
{
    /// <summary>
    /// EN: Query 補間または正規化をサポートしているかどうかを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool SupportsQueryAugmentation { get; }

    /// <summary>
    /// EN: Query 分解をサポートしているかどうかを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool SupportsQueryDecomposition { get; }

    /// <summary>
    /// EN: Query routing をサポートしているかどうかを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool SupportsQueryRouting { get; }

    /// <summary>
    /// EN: 一度に扱える QueryPart の最大数を取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int MaxQueryParts { get; }

    /// <summary>
    /// EN: サポートされている query processing operation の一覧を取得します。
    /// EN: Documentation for public API. JA: SupportsQueryProcessingOperation 操作を実行します。
    /// </summary>
    IReadOnlyList<string> SupportedQueryProcessingOperations { get; }

    /// <summary>
    /// EN: 指定された query processing operation をサポートしているか確認します。
    /// EN: Documentation for public API. JA: SupportsQueryProcessingOperation 操作を実行します。
    /// </summary>
    /// <param name="operation">EN: Documentation for public API. JA: 操作名。 operation パラメーターです。</param>
    /// <returns>EN: Documentation for public API. JA: サポートしている場合は true。 結果を返します。</returns>
    bool SupportsQueryProcessingOperation(string operation);
}

/// <summary>
/// Embedding に関する Provider capability metadata を公開します。
/// EN: 実際の embedding 生成は ITextEmbeddingProvider / IBatchEmbeddingProvider / IEmbeddingProvider が担います。
/// EN: Documentation for public API. JA: IEmbeddingCapabilityMetadata の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingCapabilityMetadata']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IEmbeddingCapabilityMetadata']" />
public interface IEmbeddingCapabilityMetadata
{
    /// <summary>
    /// EN: Embedding 生成をサポートしているかどうかを取得します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    bool SupportsEmbedding { get; }

    /// <summary>
    /// Embedding vector の次元数を取得します。
    /// EN: 次元が固定でない場合、または未公開の場合は null を返します。
    /// EN: Documentation for public API. JA: このメンバー の公開契約を定義します。
    /// </summary>
    int? EmbeddingDimensions { get; }

    /// <summary>
    /// EN: サポートされている embedding model 名の一覧を取得します。
    /// EN: Documentation for public API. JA: IProviderCapabilities の公開契約を定義します。
    /// </summary>
    IReadOnlyList<string> SupportedEmbeddingModels { get; }
}

/// <summary>
/// UC-05/UC-19/UC-23/UC-26/UC-27 に基づく契約です。
/// プロバイダーの機能情報を定義する互換合成インターフェースです。
/// EN: 静的な能力情報と、実行制約に基づく動的能力に対応します。
/// EN: Documentation for public API. JA: IProviderCapabilities の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapabilities']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Providers.IProviderCapabilities']" />
public interface IProviderCapabilities :
    IProviderOperationCapabilities,
    IProviderConnectionCapabilities,
    IProviderCapacityVectorSource,
    IDynamicProviderCapacitySource,
    IProviderProfileSource,
    IQuantizationSupport,
    IQueryProcessingCapabilities,
    IEmbeddingCapabilityMetadata
{
}
