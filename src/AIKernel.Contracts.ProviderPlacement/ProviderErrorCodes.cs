namespace AIKernel.Dtos.Providers;

/// <summary>[EN] Shared provider failures. [JA] Provider 共通エラーコード。</summary>
public static class ProviderErrorCodes
{
    /// <summary>[EN] Operation is unavailable. [JA] 操作は未実装です。</summary>
    public const string NotImplemented = "provider.not_implemented";
    /// <summary>[EN] The model is not registered. [JA] モデルが未登録です。</summary>
    public const string ModelNotRegistered = "provider.model_not_registered";
    /// <summary>[EN] The input modality is unsupported. [JA] 入力モダリティが未対応です。</summary>
    public const string UnsupportedModality = "provider.unsupported_modality";
    /// <summary>[EN] The file or media format is unsupported. [JA] ファイルまたはメディア形式が未対応です。</summary>
    public const string UnsupportedFormat = "provider.unsupported_format";
    /// <summary>[EN] The option is unsupported. [JA] 要求されたオプションが未対応です。</summary>
    public const string UnsupportedOption = "provider.unsupported_option";
    /// <summary>[EN] The input exceeds a declared limit. [JA] 入力が申告上限を超えています。</summary>
    public const string InputLimitExceeded = "provider.input_limit_exceeded";
    /// <summary>[EN] The request is invalid. [JA] 要求が不正です。</summary>
    public const string InvalidRequest = "provider.invalid_request";
    /// <summary>[EN] The provider output is invalid. [JA] Provider の出力が不正です。</summary>
    public const string InvalidOutput = "provider.invalid_output";
    /// <summary>[EN] No eligible execution node. [JA] 配置できるノードがありません。</summary>
    public const string NoCandidateNode = "provider.no_candidate_node";
    /// <summary>[EN] Execution failed. [JA] 実行に失敗しました。</summary>
    public const string ExecutionFailed = "provider.execution_failed";
}

/// <summary>[EN] Stable exclusion reasons. [JA] 配置除外理由コード。</summary>
public static class PlacementReasonCodes
{
    /// <summary>[EN] Provider or model missing from the node registry. [JA] ノードに Provider またはモデルが未登録です。</summary>
    public const string ProviderNotRegistered = "scheduler.provider_not_registered";
    /// <summary>[EN] Required modality is unavailable. [JA] 必須のモダリティを利用できません。</summary>
    public const string ModalityUnsupported = "scheduler.modality_unsupported";
    /// <summary>[EN] Required execution mode is unavailable. [JA] 必須の呼び出し形態を利用できません。</summary>
    public const string ModeUnsupported = "scheduler.mode_unsupported";
    /// <summary>[EN] Required feature is unavailable. [JA] 必須の機能を利用できません。</summary>
    public const string FeatureUnsupported = "scheduler.feature_unsupported";
    /// <summary>[EN] Required CPU instruction extension is unavailable. [JA] 必須の CPU 命令拡張を利用できません。</summary>
    public const string IsaUnsupported = "scheduler.isa_unsupported";
    /// <summary>[EN] Required precision is unavailable. [JA] 指定の演算精度を利用できません。</summary>
    public const string PrecisionUnsupported = "scheduler.precision_unsupported";
    /// <summary>[EN] Insufficient allocatable RAM and AIKernel swap. [JA] 割り当て可能な RAM と AIKernel の Swap が不足しています。</summary>
    public const string MemoryInsufficient = "scheduler.memory_insufficient";
    /// <summary>[EN] Node or registration observation is stale. [JA] ノード状態または登録状態の有効期限を超えています。</summary>
    public const string DescriptorStale = "scheduler.descriptor_stale";
    /// <summary>[EN] Unsupported descriptor schema. [JA] 記述子のスキーマ版が未対応です。</summary>
    public const string DescriptorSchemaUnknown = "scheduler.descriptor_schema_unknown";
    /// <summary>[EN] Descriptor fails validation. [JA] 記述子が検証に失敗しました。</summary>
    public const string DescriptorInvalid = "scheduler.descriptor_invalid";
    /// <summary>[EN] No node observations were supplied. [JA] ノードの観測がありません。</summary>
    public const string NoNodes = "scheduler.no_nodes";
}
