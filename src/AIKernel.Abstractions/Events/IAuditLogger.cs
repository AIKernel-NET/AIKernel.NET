namespace AIKernel.Abstractions.Events;

/// <summary>
/// EN: UC-20/UC-24/UC-25 に基づく audit event 書き込み契約です。
/// [EN] Documents this public package API member. [JA] IAuditEventWriter の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IAuditEventWriter']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IAuditEventWriter']" />
public interface IAuditEventWriter
{
    /// <summary>EN: Executes the LogAuditEventAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LogAuditEventAsync 操作を実行します。</summary>
    ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// EN: Execution event の audit logging 契約です。
/// [EN] Documents this public package API member. [JA] IExecutionAuditLogger の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IExecutionAuditLogger']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IExecutionAuditLogger']" />
public interface IExecutionAuditLogger
{
    /// <summary>EN: Executes the LogExecutionEventAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LogExecutionEventAsync 操作を実行します。</summary>
    ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// EN: Guard event の audit logging 契約です。
/// [EN] Documents this public package API member. [JA] IGuardAuditLogger の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IGuardAuditLogger']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IGuardAuditLogger']" />
public interface IGuardAuditLogger
{
    /// <summary>EN: Executes the LogGuardEventAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LogGuardEventAsync 操作を実行します。</summary>
    ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// EN: Pipeline event の audit logging 契約です。
/// [EN] Documents this public package API member. [JA] IPipelineAuditLogger の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IPipelineAuditLogger']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IPipelineAuditLogger']" />
public interface IPipelineAuditLogger
{
    /// <summary>EN: Executes the LogPipelineEventAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LogPipelineEventAsync 操作を実行します。</summary>
    ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// EN: Provider event の audit logging 契約です。
/// [EN] Documents this public package API member. [JA] IProviderAuditLogger の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IProviderAuditLogger']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IProviderAuditLogger']" />
public interface IProviderAuditLogger
{
    /// <summary>EN: Executes the LogProviderEventAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LogProviderEventAsync 操作を実行します。</summary>
    ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// EN: Transfer trace の audit logging 契約です。
/// [EN] Documents this public package API member. [JA] ITransferTraceLogger の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.ITransferTraceLogger']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.ITransferTraceLogger']" />
public interface ITransferTraceLogger
{
    /// <summary>EN: Executes the LogTransferTraceAsync operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで LogTransferTraceAsync 操作を実行します。</summary>
    ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default);
}

/// <summary>
/// EN: UC-20/UC-24/UC-25 に基づく IAuditLogger の互換合成契約を定義します。
/// [EN] Documents this public package API member. [JA] IAuditLogger の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IAuditLogger']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Events.IAuditLogger']" />
public interface IAuditLogger :
    IAuditEventWriter,
    IExecutionAuditLogger,
    IGuardAuditLogger,
    IPipelineAuditLogger,
    IProviderAuditLogger,
    ITransferTraceLogger
{
}
