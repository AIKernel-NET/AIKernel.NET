using AIKernel.Dtos;
using AIKernel.Enums;

namespace AIKernel.Contracts;

/// <summary>
/// 表現（Expression）契約を定義します。
/// 推論が完全に終了した後にのみ適用される、出力表現層の契約です。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public interface IExpressionContract
{
    /// <summary>
    /// 表現層のコンテキストを取得します。
    /// </summary>
    ExpressionContextDto GetContext();

    /// <summary>
    /// 出力の文体を取得します。
    /// </summary>
    string? GetStyle();

    /// <summary>
    /// 説明用の例を取得します。
    /// 注意: これらは推論には混入しません。
    /// </summary>
    IReadOnlyList<string> GetExamples();

    /// <summary>
    /// 説明テンプレートを取得します。
    /// </summary>
    string? GetDescriptionTemplate();

    /// <summary>
    /// 比喩・類推を取得します。
    /// </summary>
    IReadOnlyList<string> GetAnalogies();

    /// <summary>
    /// このコントラクトが推論結果に混入していないことを確認します。
    /// </summary>
    ValidationResult ValidateIsolation();

    /// <summary>
    /// 推論後の適用タイミングを確認します。
    /// </summary>
    bool CanApplyAfterInference();
}
