namespace AIKernel.Dtos.Kernel;

using AIKernel.Dtos.Context;
using AIKernel.Dtos.Execution;
using AIKernel.Dtos.Rom;
using AIKernel.Dtos.Vfs;
using System.Collections.Immutable;

/// <summary>[EN] Documents this public package API member. [JA] KernelRequest を表します。</summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.KernelRequest']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Kernel.KernelRequest']" />
public sealed record KernelRequest
{
    /// <summary>[EN] Documents this public package API member. [JA] Input を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.Input']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.Input']" />
    public required string Input { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] RootRomId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.RootRomId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.RootRomId']" />
    public required RomId RootRomId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] VfsProviderId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.VfsProviderId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.VfsProviderId']" />
    public required string VfsProviderId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Credentials を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.Credentials']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.Credentials']" />
    public required VfsCredentials Credentials { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Scope を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.Scope']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.Scope']" />
    public required ContextAssemblyScope Scope { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] PromptOptions を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.PromptOptions']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.PromptOptions']" />
    public required PromptGenerationOptions PromptOptions { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ExecutionOptions を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.ExecutionOptions']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.ExecutionOptions']" />
    public required ExecutionOptions ExecutionOptions { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] RequestedModelId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.RequestedModelId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.RequestedModelId']" />
    public string? RequestedModelId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] ParentSnapshotId を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.ParentSnapshotId']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.ParentSnapshotId']" />
    public string? ParentSnapshotId { get; init; }

    /// <summary>[EN] Documents this public package API member. [JA] Metadata を取得します。</summary>
    /// <include file="docs.en.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.string']" />
    /// <include file="docs.ja.xml" path="doc/members/member[@name='P:AIKernel.Dtos.Kernel.KernelRequest.string']" />
    public ImmutableDictionary<string, string> Metadata { get; init; }
        = ImmutableDictionary<string, string>.Empty;
}
