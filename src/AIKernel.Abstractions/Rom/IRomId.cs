using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Rom;

/// <summary>
/// ROM の論理識別子を表す抽象契約です。
///
/// 設計意図:
/// ContextAssembler や GovernancePolicy が RomId という具象 record に依存すると、
/// 利用者が独自の ROM ID 実装を差し込めなくなります。
///
/// 抽象層では「値を持つ ROM 識別子である」という最小契約だけを扱い、
/// 実際の record / class / struct の選択は実装側へ委ねます。
/// JA: IRomId の公開契約を定義します。
/// </summary>
/// <include file="docs.en.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomId']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:AIKernel.Abstractions.Rom.IRomId']" />
public interface IRomId
{
    /// <summary>Gets the Value value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Value 値を取得します。</summary>
    string Value { get; }
}
