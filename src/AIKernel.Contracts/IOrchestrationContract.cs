using AIKernel.Dtos.Context;

namespace AIKernel.Contracts;

/// <summary>
/// 推論（Orchestration）契約を定義します。
/// 目的、制約、抽象構造を含む不変な入力フォーマットです。
/// 
/// 参照: 2.CONTEXT_ISOLATION_SPEC.jp.md
/// UC-02（Structure フェーズ実行）, UC-04（生成と出力整形）
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IOrchestrationContract']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Contracts.IOrchestrationContract']" />
public interface IOrchestrationContract
{
    /// <summary>
    /// 推論に必要なコンテキストを取得します。
    /// 例・文体・RAG は含まれていません。
    /// </summary>
    /// <returns>Orchestration コンテキスト</returns>
    OrchestrationContextDto GetContext();

    /// <summary>
    /// 推論のための目的を取得します。
    /// </summary>
    /// <returns>目的</returns>
    string GetPurpose();

    /// <summary>
    /// 推論に課される制約条件を取得します。
    /// </summary>
    /// <returns>制約条件一覧</returns>
    IReadOnlyList<string> GetConstraints();

    /// <summary>
    /// 推論の抽象構造を取得します。
    /// </summary>
    /// <returns>抽象構造</returns>
    string GetStructure();

    /// <summary>
    /// 推論パターンを取得します。
    /// </summary>
    /// <returns>推論パターン。未設定の場合は null。</returns>
    string? GetReasoningPattern();
}

