namespace AIKernel.Enums;

public enum DynamicSlmPayloadKind
{
    Unknown = 0,
    BaseWeights = 1,
    Adapter = 2,
    LoRaDelta = 3,
    QLoRaDelta = 4,
    QuantizedBlock = 5,
    TokenizerFragment = 6,
    ExecutableSegment = 7
}
