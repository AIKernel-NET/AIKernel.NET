# XML Documentation Policy for v0.1.1.1

AIKernel.NET の public API には、バイリンガル XML documentation を付与する。

この方針は、public interface、DTO record、enum type、enum value、public DTO
property、および contract surface を文書化する public test skeleton member に適用する。

---

## 必須形式

inline XML documentation では、同じ XML element 内に英語と日本語を含める。
推奨形式は、`EN:` と `JA:` marker を明示する形である。

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

method documentation では、`param`、`typeparam`、`returns` にも日本語本文を含める。

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

---

## External Include 形式

既存 contract surface では、英語・日本語の両方の include file が存在する場合に
external XML documentation を利用できる。

```csharp
/// <include file="docs.en.xml" path="doc/members/member[@name='T:Example.Type']" />
/// <include file="docs.ja.xml" path="doc/members/member[@name='T:Example.Type']" />
public interface IExample
{
}
```

片方の言語だけの include は規約違反とする。

---

## Review Checklist

- すべての public type に、バイリンガル `summary` または英日ペアの external include がある。
- すべての public member に、バイリンガル `summary` または英日ペアの external include がある。
- すべての public method parameter に、バイリンガル `param` documentation がある。
- すべての public generic parameter に、バイリンガル `typeparam` documentation がある。
- すべての public method return value に、バイリンガル `returns` documentation がある。
- XML documentation は contract surface を説明し、実装ロジックを説明しない。

---

## Verification

repository では、public declaration にバイリンガル XML documentation または
`docs.en.xml` / `docs.ja.xml` のペア include があることを scan で確認できる。
通常の build / test surface も通す。

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
