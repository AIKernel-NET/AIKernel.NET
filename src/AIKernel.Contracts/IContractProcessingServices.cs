using AIKernel.Dtos.Context;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 統合コンテキスト契約を検証する service interface です。
/// EN: Contract 自体は不変 view に留まり、検証処理はこの境界へ外出しします。
/// [EN] Documents this public package API member. [JA] IUnifiedContextContractValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContractValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IUnifiedContextContractValidator']" />
public interface IUnifiedContextContractValidator
{
    /// <summary>EN: Executes the ValidateAll operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateAll 操作を実行します。</summary>
    ValidationResult ValidateAll(IUnifiedContextContract contract);
}

/// <summary>
/// EN: 3 層分離を検証する service interface です。
/// [EN] Documents this public package API member. [JA] ILayerSeparationValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ILayerSeparationValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ILayerSeparationValidator']" />
public interface ILayerSeparationValidator
{
    /// <summary>EN: Executes the ValidateLayerSeparation operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateLayerSeparation 操作を実行します。</summary>
    bool ValidateLayerSeparation(IUnifiedContextContract contract);
}

/// <summary>
/// EN: Attention 汚染を検出する service interface です。
/// [EN] Documents this public package API member. [JA] IAttentionPollutionDetector の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IAttentionPollutionDetector']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IAttentionPollutionDetector']" />
public interface IAttentionPollutionDetector
{
    /// <summary>EN: Executes the DetectPollution operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで DetectPollution 操作を実行します。</summary>
    IReadOnlyList<FailureMode> DetectPollution(IUnifiedContextContract contract);
}

/// <summary>
/// EN: Signal-to-Noise Ratio（SNR）を計算する service interface です。
/// [EN] Documents this public package API member. [JA] ISignalToNoiseRatioCalculator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ISignalToNoiseRatioCalculator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.ISignalToNoiseRatioCalculator']" />
public interface ISignalToNoiseRatioCalculator
{
    /// <summary>EN: Executes the CalculateSignalToNoiseRatio operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CalculateSignalToNoiseRatio 操作を実行します。</summary>
    double CalculateSignalToNoiseRatio(IUnifiedContextContract contract);

    /// <summary>EN: Executes the CalculateSignalToNoiseRatio operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CalculateSignalToNoiseRatio 操作を実行します。</summary>
    double CalculateSignalToNoiseRatio(IOrchestrationContract contract);
}

/// <summary>
/// EN: Orchestration 契約を検証する service interface です。
/// [EN] Documents this public package API member. [JA] IOrchestrationContractValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IOrchestrationContractValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IOrchestrationContractValidator']" />
public interface IOrchestrationContractValidator
{
    /// <summary>EN: Executes the Validate operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Validate 操作を実行します。</summary>
    ValidationResult Validate(IOrchestrationContract contract);
}

/// <summary>
/// EN: Expression 契約の隔離状態を検証する service interface です。
/// [EN] Documents this public package API member. [JA] IExpressionIsolationValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionIsolationValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionIsolationValidator']" />
public interface IExpressionIsolationValidator
{
    /// <summary>EN: Executes the ValidateIsolation operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateIsolation 操作を実行します。</summary>
    ValidationResult ValidateIsolation(IExpressionContract contract);
}

/// <summary>
/// EN: Expression 契約の適用タイミングを判定する service interface です。
/// [EN] Documents this public package API member. [JA] IExpressionApplicationGate の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionApplicationGate']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IExpressionApplicationGate']" />
public interface IExpressionApplicationGate
{
    /// <summary>EN: Executes the CanApplyAfterInference operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで CanApplyAfterInference 操作を実行します。</summary>
    bool CanApplyAfterInference(IExpressionContract contract);
}

/// <summary>
/// EN: Material 契約を正規化する service interface です。
/// [EN] Documents this public package API member. [JA] IMaterialNormalizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialNormalizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialNormalizer']" />
public interface IMaterialNormalizer
{
    /// <summary>EN: Executes the Normalize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Normalize 操作を実行します。</summary>
    MaterialContextDto Normalize(IMaterialContract contract);
}

/// <summary>
/// EN: Material 契約を構造化する service interface です。
/// [EN] Documents this public package API member. [JA] IMaterialStructurizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialStructurizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialStructurizer']" />
public interface IMaterialStructurizer
{
    /// <summary>EN: Executes the Structurize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Structurize 操作を実行します。</summary>
    IReadOnlyDictionary<string, object> Structurize(IMaterialContract contract);
}

/// <summary>
/// EN: Material 契約を正準化する service interface です。
/// [EN] Documents this public package API member. [JA] IMaterialCanonicalizer の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialCanonicalizer']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialCanonicalizer']" />
public interface IMaterialCanonicalizer
{
    /// <summary>EN: Executes the Canonicalize operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで Canonicalize 操作を実行します。</summary>
    string Canonicalize(IMaterialContract contract);
}

/// <summary>
/// EN: Material 契約の hash を計算する service interface です。
/// [EN] Documents this public package API member. [JA] IMaterialHashProvider の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialHashProvider']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialHashProvider']" />
public interface IMaterialHashProvider
{
    /// <summary>EN: Executes the ComputeHash operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ComputeHash 操作を実行します。</summary>
    string ComputeHash(IMaterialContract contract);
}

/// <summary>
/// EN: Orchestration Context へ転写可能な必須 content を抽出する service interface です。
/// [EN] Documents this public package API member. [JA] IEssentialMaterialExtractor の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IEssentialMaterialExtractor']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IEssentialMaterialExtractor']" />
public interface IEssentialMaterialExtractor
{
    /// <summary>EN: Executes the ExtractEssentialContent operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ExtractEssentialContent 操作を実行します。</summary>
    string ExtractEssentialContent(IMaterialContract contract);
}

/// <summary>
/// EN: Material 検疫状態を検証する service interface です。
/// [EN] Documents this public package API member. [JA] IMaterialQuarantineValidator の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialQuarantineValidator']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IMaterialQuarantineValidator']" />
public interface IMaterialQuarantineValidator
{
    /// <summary>EN: Executes the ValidateQuarantine operation on the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで ValidateQuarantine 操作を実行します。</summary>
    ValidationResult ValidateQuarantine(IMaterialContract contract);
}
