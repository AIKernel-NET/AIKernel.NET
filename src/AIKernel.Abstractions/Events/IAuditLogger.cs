namespace AIKernel.Abstractions.Events;

/// <summary>
/// UC-20/UC-24/UC-25 に基づく IAuditLogger の契約を定義します。
/// </summary>
public interface IAuditLogger
{
    ValueTask LogAuditEventAsync(AuditEvent auditEvent, CancellationToken cancellationToken = default);

    ValueTask LogExecutionEventAsync(ExecutionEvent executionEvent, CancellationToken cancellationToken = default);

    ValueTask LogGuardEventAsync(GuardEvent guardEvent, CancellationToken cancellationToken = default);

    ValueTask LogPipelineEventAsync(PipelineEvent pipelineEvent, CancellationToken cancellationToken = default);

    ValueTask LogProviderEventAsync(ProviderEvent providerEvent, CancellationToken cancellationToken = default);

    ValueTask LogTransferTraceAsync(TransferTrace transferTrace, CancellationToken cancellationToken = default);
}


