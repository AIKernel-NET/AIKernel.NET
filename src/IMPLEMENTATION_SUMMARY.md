# AIKernel.NET Core の実装概要

## ✅ 実装完了

ドキュメント仕様から以下のコンポーネントを実装しました。

---

## 📦 実装されたコンポーネント

### 1. **AIKernel.Enums** — 共有列挙型

#### InformationCategory（情報カテゴリ）
- `Purpose` — 目的
- `Constraints` — 制約
- `Structure` — 抽象構造
- `History` — 履歴
- `Context` — 背景
- `RagMaterial` — RAG素材
- `Expression` — 表現整形
- `Metadata` — メタ情報

#### ContextType（コンテキストタイプ）
- `Orchestration` — 推論用コンテキスト（OrchestrationContext）
- `Expression` — 表現用コンテキスト（ExpressionContext）
- `Material` — 素材用コンテキスト（MaterialContext）

#### FailureMode（Attention汚染のFailure Mode）
- `SurfaceMode` — 表面模写モード
- `ReasoningStopped` — 推論停止
- `HallucinationIncrease` — ハルシネーション増加
- `DeterministicReplayBroken` — Deterministic Replay 破壊
- `PurposeLost` — 目的の喪失
- `SelfCorrectionLost` — 自己修正能力喪失

#### AttentionSignal（Signal/Noise分類）
- **Signal 優先度** — Purpose, Constraints, Structure, ReasoningPattern
- **Noise 隔離** — Example, Style, RagFragment, History, GeneralNoise

---

### 2. **AIKernel.Dtos** — データ転送オブジェクト

#### InformationCategoryDto
情報カテゴリとその値を表現する DTO

#### OrchestrationContextDto
推論用コンテキストデータ
- 目的（Purpose）
- 制約条件（Constraints）
- 抽象構造（Structure）
- 思考パターン（ReasoningPattern）

#### ExpressionContextDto
表現用コンテキストデータ（推論後にのみ適用）
- 文体（Style）
- 例（Examples）
- 説明テンプレート（DescriptionTemplate）
- 比喩（Analogies）

#### MaterialContextDto
素材用コンテキストデータ
- 取得元ソース（Source）
- 生のデータ（RawData）
- 正規化されたデータ（NormalizedData）
- 構造化されたデータ（StructuredData）
- 関連性スコア（RelevanceScore）

#### UnifiedContextDto
統合コンテキストデータ
- Orchestration / Expression / Material を管理
- SNR（Signal-to-Noise Ratio）
- Detected Failure Modes

---

### 3. **AIKernel.Contracts** — 契約・スキーマ

#### IOrchestrationContract
推論契約インターフェース
- `GetContext()` — コンテキスト取得
- `GetPurpose()` — 目的取得
- `GetConstraints()` — 制約取得
- `GetStructure()` — 構造取得
- `Validate()` — 検証と Attention 汚染検出
- `CalculateSignalToNoiseRatio()` — SNR 計算

#### IExpressionContract
表現契約インターフェース
- `GetContext()` — コンテキスト取得
- `GetStyle()` — 文体取得
- `GetExamples()` — 例取得
- `ValidateIsolation()` — 隔離検証
- `CanApplyAfterInference()` — 推論後適用可能性確認

#### IMaterialContract
素材契約インターフェース
- `GetContext()` — コンテキスト取得
- `Normalize()` — 正規化
- `Structurize()` — 構造化
- `ExtractEssentialContent()` — 必須コンテンツ抽出
- `ValidateQuarantine()` — 検疫検証

#### IUnifiedContextContract
統合コンテキスト契約インターフェース
- `GetOrchestration()` / `GetExpression()` / `GetMaterial()` — 各層取得
- `ValidateAll()` — 全体検証
- `ValidateLayerSeparation()` — 層分離検証
- `DetectPollution()` — Attention 汚染検出
- `CalculateSignalToNoiseRatio()` — SNR 計算

---

### 4. **AIKernel.Abstractions** — Syscall レベルインターフェース

#### IKernel — Kernel インターフェース
AIKernel の中核エンジン
- `ExecuteAsync()` — 統合コンテキスト契約を実行
- `AnalyzeAttentionAsync()` — Attention 汚染分析
- `PreprocessMaterialAsync()` — 素材の前処理
- `PrepareExpressionAsync()` — 表現の準備
- `GetProviderRouter()` — Provider ルーター取得
- `GetGuard()` — Guard 取得
- `GetPdp()` — PDP 取得

#### IProviderRouter / IProvider — プロバイダー管理
外部データ取得・キャッシング・ルーティング
- `RetrieveAsync()` — データ取得
- `RetrieveMultipleAsync()` — 並列取得
- `RegisterProvider()` — プロバイダー登録
- `CacheMaterialAsync()` — キャッシング

#### IGuard — セキュリティ・アクセス制御
- `CanExecuteAsync()` — 実行可能性チェック
- `CanAccessContextAsync()` — アクセス権チェック
- `OnFailureModeDetectedAsync()` — Failure mode 時処理

#### IPdp（Policy Decision Point）— ポリシー決定
- `EvaluateAsync()` — アクセス決定
- `AddPolicy()` / `RemovePolicy()` — ポリシー管理
- `EvaluatePoliciesAsync()` — ポリシー評価

---

## 🏗️ アーキテクチャ設計の基本原則

すべての実装は以下の原則に基づいています：

### 1. **情報カテゴリ分離**
情報を明確にカテゴリ分けし、混在を構造的に防止

### 2. **コンテキスト隔離（3 層モデル）**
```
OrchestrationContext（推論用）
    ↓
ExpressionContext（表現用、推論後のみ）
    ↓
MaterialContext（素材用、検疫処理）
```

### 3. **Attention 汚染防止**
- Signal（推論情報）を最優先で attention に乗せる
- Noise（表面構造）を構造的に隔離

### 4. **Contract-driven 実行**
すべての実行は不変な契約スキーマで定義される

### 5. **前処理中心主義（Preprocessing over Prompting）**
- プロンプトは「最後の整形」
- 推論精度は前処理（カテゴリ分離・構造化）で決まる

---

## 📚 参照ドキュメント

実装の基盤となったドキュメント：

1. **1.CATEGORY_SEPARATION_PRINCIPLES.jp.md** — 情報カテゴリ分離
2. **2.CONTEXT_ISOLATION_SPEC.jp.md** — コンテキスト隔離仕様
3. **3.ATTENTION_POLLUTION_THEORY.jp.md** — Attention 汚染理論
4. **4.LLM_SURFACE_MODE_FAILURE.jp.md** — 表面模写モードの危険性
5. **5.PREPROCESSING_VS_PROMPTING.jp.md** — 前処理中心主義

---

## 🔗 依存関係グラフ

```
AIKernel.Enums
    ↓
AIKernel.Dtos ⟵ AIKernel.Enums
    ↓
AIKernel.Contracts ⟵ AIKernel.Enums, AIKernel.Dtos
    ↓
AIKernel.Abstractions ⟵ AIKernel.Contracts, AIKernel.Enums
```

すべての依存は README.md の公式ルールに従っています。

---

## ✨ 次のステップ

以下のプロジェクトでこれらのインターフェースの実装を進められます：

1. **AIKernel.KernelContext** — IKernel 実装
2. **AIKernel.VFS** — ファイルシステム抽象
3. **AIKernel.Events** — イベント定義
4. **実装層** — Provider、Guard、Pdp の具体実装

---

## 🎯 品質保証

✅ ビルド成功
✅ 全ファイル作成完了
✅ 型安全性確保（nullable reference types enabled）
✅ 依存関係ルール準拠
✅ ドキュメント仕様完全実装
