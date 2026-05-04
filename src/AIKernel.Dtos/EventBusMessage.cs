namespace AIKernel.Dtos;

using AIKernel.Enums;

public sealed record EventBusMessage(
    string EventId,
    string EventName,
    DateTime Timestamp,
    string Data,
    string? Source,
    EventPriority Priority);
