namespace AIKernel.Abstractions.Events;

/// <summary>
/// UC-20/UC-24/UC-25 に基づく audit event 書き込み契約です。
/// </summary>
public interface IAuditEventWriter
{
    ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Execution event の audit logging 契約です。
/// </summary>
public interface IExecutionAuditLogger
{
    ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Guard event の audit logging 契約です。
/// </summary>
public interface IGuardAuditLogger
{
    ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Pipeline event の audit logging 契約です。
/// </summary>
public interface IPipelineAuditLogger
{
    ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Provider event の audit logging 契約です。
/// </summary>
public interface IProviderAuditLogger
{
    ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default);
}

/// <summary>
/// Transfer trace の audit logging 契約です。
/// </summary>
public interface ITransferTraceLogger
{
    ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default);
}

/// <summary>
/// UC-20/UC-24/UC-25 に基づく IAuditLogger の互換合成契約を定義します。
/// </summary>
public interface IAuditLogger :
    IAuditEventWriter,
    IExecutionAuditLogger,
    IGuardAuditLogger,
    IPipelineAuditLogger,
    IProviderAuditLogger,
    ITransferTraceLogger
{
}
