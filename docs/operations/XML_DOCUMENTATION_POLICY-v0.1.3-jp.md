---
updated: 2026-06-23
published: 2026-06-16
version: "0.1.3"
edition: "Canonical Series"
status: "Active"
issuer: ai-kernel@aikernel.net
maintainer: "Takuya (AIKernel Project Maintainer)"
---

# XML Documentation Policy v0.1.3

[English](XML_DOCUMENTATION_POLICY-v0.1.3.md)

AIKernel.NET の public API には、バイリンガル XML documentation を付与します。
これは package、Demo、Doom の開発者向け documentation に対する 0.1.3 現行ポリシーです。

この方針は、public interface、DTO record、enum type、enum value、public DTO
property、および contract surface を文書化する public test skeleton member に適用します。

## 必須形式

inline XML documentation では、同じ XML element 内に英語と日本語を含めます。
推奨形式は、`EN:` と `JA:` marker を明示する形です。

```csharp
/// <summary>
/// EN: Describes a runtime status snapshot. JA: runtime status snapshot を記述します。
/// </summary>
public sealed record RuntimeStatusSnapshot
{
    /// <summary>EN: Gets the runtime identifier. JA: runtime identifier を取得します。</summary>
    public string RuntimeId { get; init; } = string.Empty;
}
```

method documentation では、`param`、`typeparam`、`returns` にも日本語本文を含めます。

```csharp
/// <summary>
/// EN: Executes a runtime control operation. JA: runtime control 操作を実行します。
/// </summary>
/// <param name="request">EN: The request. JA: request パラメーターです。</param>
/// <param name="cancellationToken">EN: The cancellation token. JA: キャンセル通知を監視するトークンです。</param>
/// <returns>EN: The control result. JA: 結果を返します。</returns>
ValueTask<RuntimeControlResult> ControlAsync(
    RuntimeControlRequest request,
    CancellationToken cancellationToken);
```

## External Include 形式

既存 contract surface では、英語・日本語の両方の include file が存在する場合に
external XML documentation を利用できます。

```csharp
/// <include file="docs.en.xml" path="doc/members/member[@name='T:Example.Type']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:Example.Type']" />
public interface IExample
{
}
```

片方の言語だけの include は規約違反です。

## Review Checklist

- すべての public type に、バイリンガル `summary` または英日ペアの external include がある。
- すべての public member に、バイリンガル `summary` または英日ペアの external include がある。
- すべての public method parameter に、バイリンガル `param` documentation がある。
- すべての public generic parameter に、バイリンガル `typeparam` documentation がある。
- すべての public method return value に、バイリンガル `returns` documentation がある。
- XML documentation は contract surface を説明し、実装ロジックを説明しない。
- Demo と Doom の public member では、member 名の言い換えだけでなく、開発者向けの挙動も説明する。

## Verification

```powershell
py tools\check_bilingual_xml_docs.py src
dotnet build src\AIKernel.NET.slnx
dotnet test src\tests\AIKernel.Abstractions.Tests\AIKernel.Abstractions.Tests.csproj --no-build
```

shared workspace root から repository 横断で検証する場合:

```powershell
py AIKernel.NET\tools\check_bilingual_xml_docs.py `
  AIKernel.NET\src AIKernel.Core\src AIKernel.Control\src `
  AIKernel.Providers\src AIKernel.Wasm\src AIKernel.Cuda13.0\src `
  AIKernel.Tools\src AIKernel.Demo\src AIKernel.Doom\src
```

## 履歴メモ

古い `XML_DOCUMENTATION_POLICY-v0.1.1.1` files は migration history として残します。
0.1.3 の新規作業では、この policy にリンクしてください。
