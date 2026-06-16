namespace AIKernel.Dtos.Kernel;

using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] KernelTransactionSnapshot を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.KernelTransactionSnapshot']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.KernelTransactionSnapshot']" />
public sealed record KernelTransactionSnapshot
{
    /// <summary>[EN] Documents this public package API member. [JA] TransactionId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.TransactionId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.TransactionId']" />
    public required string TransactionId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] InputHash を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.InputHash']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.InputHash']" />
    public required string InputHash { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] RootRomId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.RootRomId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.RootRomId']" />
    public required string RootRomId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] VfsProviderId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.VfsProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.VfsProviderId']" />
    public required string VfsProviderId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] RequestedModelId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.RequestedModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.RequestedModelId']" />
    public required string? RequestedModelId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] StartedAtUtc を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.StartedAtUtc']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.StartedAtUtc']" />
    public required DateTimeOffset StartedAtUtc { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelTransactionSnapshot.string']" />
    public required ImmutableDictionary<string, string> Metadata { get; init; }
}