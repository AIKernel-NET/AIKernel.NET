# AIKernel shared contracts

The 0.3.0 foundation packages target .NET 10. Install the package that owns the types your application uses. NuGet restores its dependencies.

| Package | Purpose | AIKernel dependencies |
| --- | --- | --- |
| AIKernel.Enums | Shared enum values | None |
| AIKernel.Dtos | Request, response, and replay data | AIKernel.Enums |
| AIKernel.Abstractions | Runtime and Provider interfaces | AIKernel.Dtos and AIKernel.Enums |

```sh
dotnet add package AIKernel.Abstractions --version 0.3.0
```

共有インターフェースを使う場合は Abstractions、データ型だけを使う場合は Dtos、列挙型だけを使う場合は Enums を参照します。各パッケージの版は 0.3.0 です。既存のコンパイル済みコードとの互換性のため、アセンブリバージョンは 0.1.4.0 を維持しています。
