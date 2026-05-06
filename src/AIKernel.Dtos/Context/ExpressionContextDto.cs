using AIKernel.Enums;

namespace AIKernel.Dtos.Context;

/// <summary>
/// ExpressionContext のデータを表現する DTO です。
/// 推論が完全に終了した後にのみ適用される、出力表現層の情報を含みます。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// </summary>
public sealed class ExpressionContextDto
{
    /// <summary>
    /// 出力の文体を取得または設定します。
    /// </summary>
    public string? Style { get; init; }

    /// <summary>
    /// 説明用の例を取得または設定します。
    /// 注意: これらの例は推論には混入しません。
    /// </summary>
    public List<string> Examples { get; init; } = new();

    /// <summary>
    /// 説明テンプレートを取得または設定します。
    /// </summary>
    public string? DescriptionTemplate { get; init; }

    /// <summary>
    /// 比喩・類推を取得または設定します。
    /// </summary>
    public List<string> Analogies { get; init; } = new();

    /// <summary>
    /// フォーマット指示を取得または設定します。
    /// </summary>
    public Dictionary<string, string>? FormatDirectives { get; init; }

    /// <summary>
    /// 作成日時を取得または設定します。
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}


