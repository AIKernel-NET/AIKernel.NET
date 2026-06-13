using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を検証する service interface です。
/// Contract 自体は不変 view に留まり、検証処理はこの境界へ外出しします。
/// JA: IUnifiedContextContractValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContractValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContractValidator']" />
public interface IUnifiedContextContractValidator
{
    /// <summary>Executes the ValidateAll operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateAll 操作を実行します。</summary>
    ValidationResult ValidateAll(IUnifiedContextContract contract);
}

/// <summary>
/// 3 層分離を検証する service interface です。
/// JA: ILayerSeparationValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ILayerSeparationValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ILayerSeparationValidator']" />
public interface ILayerSeparationValidator
{
    /// <summary>Executes the ValidateLayerSeparation operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateLayerSeparation 操作を実行します。</summary>
    bool ValidateLayerSeparation(IUnifiedContextContract contract);
}

/// <summary>
/// Attention 汚染を検出する service interface です。
/// JA: IAttentionPollutionDetector の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IAttentionPollutionDetector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IAttentionPollutionDetector']" />
public interface IAttentionPollutionDetector
{
    /// <summary>Executes the DetectPollution operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで DetectPollution 操作を実行します。</summary>
    IReadOnlyList<FailureMode> DetectPollution(IUnifiedContextContract contract);
}

/// <summary>
/// Signal-to-Noise Ratio（SNR）を計算する service interface です。
/// JA: ISignalToNoiseRatioCalculator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ISignalToNoiseRatioCalculator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ISignalToNoiseRatioCalculator']" />
public interface ISignalToNoiseRatioCalculator
{
    /// <summary>Executes the CalculateSignalToNoiseRatio operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CalculateSignalToNoiseRatio 操作を実行します。</summary>
    double CalculateSignalToNoiseRatio(IUnifiedContextContract contract);

    /// <summary>Executes the CalculateSignalToNoiseRatio operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CalculateSignalToNoiseRatio 操作を実行します。</summary>
    double CalculateSignalToNoiseRatio(IOrchestrationContract contract);
}

/// <summary>
/// Orchestration 契約を検証する service interface です。
/// JA: IOrchestrationContractValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IOrchestrationContractValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IOrchestrationContractValidator']" />
public interface IOrchestrationContractValidator
{
    /// <summary>Executes the Validate operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Validate 操作を実行します。</summary>
    ValidationResult Validate(IOrchestrationContract contract);
}

/// <summary>
/// Expression 契約の隔離状態を検証する service interface です。
/// JA: IExpressionIsolationValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionIsolationValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionIsolationValidator']" />
public interface IExpressionIsolationValidator
{
    /// <summary>Executes the ValidateIsolation operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateIsolation 操作を実行します。</summary>
    ValidationResult ValidateIsolation(IExpressionContract contract);
}

/// <summary>
/// Expression 契約の適用タイミングを判定する service interface です。
/// JA: IExpressionApplicationGate の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionApplicationGate']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionApplicationGate']" />
public interface IExpressionApplicationGate
{
    /// <summary>Executes the CanApplyAfterInference operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CanApplyAfterInference 操作を実行します。</summary>
    bool CanApplyAfterInference(IExpressionContract contract);
}

/// <summary>
/// Material 契約を正規化する service interface です。
/// JA: IMaterialNormalizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialNormalizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialNormalizer']" />
public interface IMaterialNormalizer
{
    /// <summary>Executes the Normalize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Normalize 操作を実行します。</summary>
    MaterialContextDto Normalize(IMaterialContract contract);
}

/// <summary>
/// Material 契約を構造化する service interface です。
/// JA: IMaterialStructurizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialStructurizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialStructurizer']" />
public interface IMaterialStructurizer
{
    /// <summary>Executes the Structurize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Structurize 操作を実行します。</summary>
    IReadOnlyDictionary<string, object> Structurize(IMaterialContract contract);
}

/// <summary>
/// Material 契約を正準化する service interface です。
/// JA: IMaterialCanonicalizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialCanonicalizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialCanonicalizer']" />
public interface IMaterialCanonicalizer
{
    /// <summary>Executes the Canonicalize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Canonicalize 操作を実行します。</summary>
    string Canonicalize(IMaterialContract contract);
}

/// <summary>
/// Material 契約の hash を計算する service interface です。
/// JA: IMaterialHashProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialHashProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialHashProvider']" />
public interface IMaterialHashProvider
{
    /// <summary>Executes the ComputeHash operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ComputeHash 操作を実行します。</summary>
    string ComputeHash(IMaterialContract contract);
}

/// <summary>
/// Orchestration Context へ転写可能な必須 content を抽出する service interface です。
/// JA: IEssentialMaterialExtractor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IEssentialMaterialExtractor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IEssentialMaterialExtractor']" />
public interface IEssentialMaterialExtractor
{
    /// <summary>Executes the ExtractEssentialContent operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExtractEssentialContent 操作を実行します。</summary>
    string ExtractEssentialContent(IMaterialContract contract);
}

/// <summary>
/// Material 検疫状態を検証する service interface です。
/// JA: IMaterialQuarantineValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialQuarantineValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialQuarantineValidator']" />
public interface IMaterialQuarantineValidator
{
    /// <summary>Executes the ValidateQuarantine operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateQuarantine 操作を実行します。</summary>
    ValidationResult ValidateQuarantine(IMaterialContract contract);
}
