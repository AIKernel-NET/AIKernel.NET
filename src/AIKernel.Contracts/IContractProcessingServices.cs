using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を検証する service interface です。
/// Contract 自体は不変 view に留まり、検証処理はこの境界へ外出しします。
/// </summary>
public interface IUnifiedContextContractValidator
{
    ValidationResult ValidateAll(IUnifiedContextContract contract);
}

/// <summary>
/// 3 層分離を検証する service interface です。
/// </summary>
public interface ILayerSeparationValidator
{
    bool ValidateLayerSeparation(IUnifiedContextContract contract);
}

/// <summary>
/// Attention 汚染を検出する service interface です。
/// </summary>
public interface IAttentionPollutionDetector
{
    IReadOnlyList<FailureMode> DetectPollution(IUnifiedContextContract contract);
}

/// <summary>
/// Signal-to-Noise Ratio（SNR）を計算する service interface です。
/// </summary>
public interface ISignalToNoiseRatioCalculator
{
    double CalculateSignalToNoiseRatio(IUnifiedContextContract contract);

    double CalculateSignalToNoiseRatio(IOrchestrationContract contract);
}

/// <summary>
/// Orchestration 契約を検証する service interface です。
/// </summary>
public interface IOrchestrationContractValidator
{
    ValidationResult Validate(IOrchestrationContract contract);
}

/// <summary>
/// Expression 契約の隔離状態を検証する service interface です。
/// </summary>
public interface IExpressionIsolationValidator
{
    ValidationResult ValidateIsolation(IExpressionContract contract);
}

/// <summary>
/// Expression 契約の適用タイミングを判定する service interface です。
/// </summary>
public interface IExpressionApplicationGate
{
    bool CanApplyAfterInference(IExpressionContract contract);
}

/// <summary>
/// Material 契約を正規化する service interface です。
/// </summary>
public interface IMaterialNormalizer
{
    MaterialContextDto Normalize(IMaterialContract contract);
}

/// <summary>
/// Material 契約を構造化する service interface です。
/// </summary>
public interface IMaterialStructurizer
{
    IReadOnlyDictionary<string, object> Structurize(IMaterialContract contract);
}

/// <summary>
/// Material 契約を正準化する service interface です。
/// </summary>
public interface IMaterialCanonicalizer
{
    string Canonicalize(IMaterialContract contract);
}

/// <summary>
/// Material 契約の hash を計算する service interface です。
/// </summary>
public interface IMaterialHashProvider
{
    string ComputeHash(IMaterialContract contract);
}

/// <summary>
/// Orchestration Context へ転写可能な必須 content を抽出する service interface です。
/// </summary>
public interface IEssentialMaterialExtractor
{
    string ExtractEssentialContent(IMaterialContract contract);
}

/// <summary>
/// Material 検疫状態を検証する service interface です。
/// </summary>
public interface IMaterialQuarantineValidator
{
    ValidationResult ValidateQuarantine(IMaterialContract contract);
}
