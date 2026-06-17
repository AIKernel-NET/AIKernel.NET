namespace AIKernel.Dtos.Execution;

/// <summary>
/// 推論の中間表現（生のロジック）を表現します。
/// EN: IThoughtProcess が返し、IOutputPolisher が入力として受け取ります。
/// [EN] Documents this public package API member. [JA] RawLogic の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.RawLogic']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Dtos.Execution.RawLogic']" />
public sealed record RawLogic(string SerializedRepresentation);


