using AIKernel.Dtos.Execution;
using AIKernel.Dtos.Providers;

namespace AIKernel.Abstractions.Providers;

/// <summary>[EN] Source of a provider's declared capability. [JA] Provider の能力申告元。</summary>
public interface IProviderCapabilityDescriptorSource
{
    /// <summary>[EN] Reads the current declaration. [JA] 現在の申告を取得します。</summary>
    ProviderCapabilityDescriptor GetCapabilityDescriptor();
}

/// <summary>[EN] Source of a live node observation. [JA] ノードの現在の状態を観測する契約。</summary>
public interface INodeCapabilityDescriptorSource
{
    /// <summary>[EN] Reads a new node observation. [JA] ノードの状態を取得します。</summary>
    ValueTask<NodeCapabilityDescriptor> GetNodeCapabilityDescriptorAsync(CancellationToken cancellationToken = default);
}

/// <summary>[EN] Ranks provider placement candidates. [JA] Provider の配置候補を順位付けする契約。</summary>
public interface IProviderPlacementScheduler
{
    /// <summary>[EN] Ranks candidates using independently supplied registry state. [JA] 独立して渡された登録状態を使って候補を順位付けします。</summary>
    ValueTask<PlacementDecision> ResolvePlacementAsync(
        ProviderRequirements requirements,
        IReadOnlyList<NodeCapabilityDescriptor> nodes,
        IReadOnlyDictionary<string, NodeProviderRegistrationSnapshot> registrations,
        CancellationToken cancellationToken = default);
}

/// <summary>[EN] A provider operation failed with a public error. [JA] 公開可能なエラーを伴う Provider 操作の失敗。</summary>
public sealed class ProviderOperationException : Exception
{
    /// <summary>[EN] Creates a failure containing a public error. [JA] 公開可能な内容から例外を作ります。</summary>
    public ProviderOperationException(ExecutionError error) : base(error.Message) => Error = error;
    /// <summary>[EN] Public error without input content or credentials. [JA] 入力本文や資格情報を含まない公開エラー。</summary>
    public ExecutionError Error { get; }
}
