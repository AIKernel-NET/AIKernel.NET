#  **AIKernel / AIOS Paper Series — Phase‑1 完結後フェーズ構成（2026.06 改訂版）**

AIKernel / AIOS Paper Series は、生成 AI を **決定論的に統治し、検証可能で、監査可能な OS として扱うための基盤仕様**を体系化した論文群です。

2026 年 5 月末の再編により、Phase‑1（01〜04）は理論的に完結し、 その後の文書は **実装・拡張フェーズ（Phase‑1.1 / 05〜08）** として整理されました。

さらに 2026 年 6 月、**Phase‑3 Foundation（09: HATL）** が正式に追加され、 AIKernel の暗号基盤・証明基盤が確立されました。

同じく 2026 年 6 月、AI 生成 DSL を決定論的 pipeline へコンパイルする **Semantic DSL Compiler（10）** と、Capability 単位で拡張可能な小規模言語モデル実行基盤 **DynamicSLM（11）** が追加され、AIKernel の agent execution / model runtime 層が拡張されました。

# 1. シリーズ概要

AIKernel / AIOS Paper Series は以下の 4 区分で構成されます：

- **Phase‑1（01〜04）** AIOS の理論的基盤（ガバナンス・意味論・安全境界）
    
- **Phase‑1.1（05〜08）** 実装・拡張フェーズ（Pipeline / Compilation / HashChain / Operator）
    
- **Phase‑3 Foundation（09）** 暗号基盤・証明基盤（HATL: Hash‑Anchored Trust Layer）

- **Agent Execution / Model Runtime（10〜11）** DSL compiler と capability-modular SLM runtime
    
## 2. フェーズ構成

---

## **Phase‑1（初版・理論フェーズ / 01〜04）**

|番号|タイトル|概要|
|---|---|---|
|**01**|ROM Format & Knowledge Snapshot<br>**DOI:** https://doi.org/10.5281/zenodo.20306539|知識の正準化・ハッシュ化・Provenance 定義。AIOS の知識基盤。|
|**02**|VFS Architecture & Semantic Storage<br>**DOI:** https://doi.org/10.5281/zenodo.20307891|ROM 永続化層と Capability ベースのアクセス制御。|
|**03**|Pre‑Inference Admissibility Governance<br>**DOI:** https://doi.org/10.5281/zenodo.20308639|推論前受理（Admission）と Fail‑Closed 制御。|
|**04**|Trajectory Governance Model<br>**DOI:** https://doi.org/10.5281/zenodo.20309510|Semantic Ellipsoid による推論軌跡の逸脱検知。**Phase‑1 完結点。**|

> Phase‑1 は Paper 04 をもって理論的に完結。

---

## **Phase‑1.1（Implementation Layer / 05〜08）**

|番号|タイトル|概要|
|---|---|---|
|**05**|Async Result Pipeline<br>**DOI:** https://doi.org/10.5281/zenodo.20458492|非同期推論結果のパイプライン化と再実行制御。|
|**06**|Semantic Compilation Architecture<br>**DOI:** https://doi.org/10.5281/zenodo.20312092|意味論的コンパイルと依存性分離モデル。|
|**07**|Chat‑Turn Hashchain Governance<br>**DOI:** https://doi.org/10.5281/zenodo.20471345|対話単位のハッシュチェーンによる履歴保証とリプレイ可能性。|
|**08**|Operator Architecture<br>**DOI:** https://doi.org/10.5281/zenodo.20493017|Lean–C–C# 外部化によるゼロ依存並列計算モデル。|

---

## **Phase‑3 Foundation（暗号・証明基盤 / 09）**

|番号|タイトル|概要|
|---|---|---|
|**09**|Hash‑Anchored Trust Layer (HATL)<br>**DOI:** https://doi.org/10.5281/zenodo.20502685|対称ラチェット型マイクロレジャー + ハッシュベース公開アンカー。AIKernel の暗号基盤・証明基盤。|

---

## **Agent Execution / Model Runtime（10〜11）**

|番号|タイトル|概要|
|---|---|---|
|**10**|AIKernel Semantic DSL Compiler and Deterministic Agent Execution Architecture<br>**DOI:** https://doi.org/10.5281/zenodo.20534341|AI が生成した plan を直接実行せず、Semantic IR、admissibility checking、governed pipeline、ResultStep / SemanticDelta、hash-linked ReplayLog へ決定論的にコンパイルする agent execution 基盤。|
|**11**|DynamicSLM: Capability‑Modular, Self‑Improving Small Language Models for AIKernel<br>**DOI:** https://doi.org/10.5281/zenodo.20550614|Semantic Profile、Capability Graph、Execution Profile、Lineage、Payload からなる Model ABI と、capability-level differential distillation / dynamic capability loading / heterogeneous execution の runtime architecture。|

# 3. フェーズ間の関係

|フェーズ|目的|主な成果|
|---|---|---|
|**Phase‑1（01〜04）**|理論的基盤の確立|決定論的ガバナンスモデル・安全推論枠組み。|
|**Phase‑1.1（05〜08）**|実装・拡張フェーズ|Pipeline / Compilation / HashChain / Operator の体系化。|
|**Phase‑3 Foundation（09）**|暗号・証明基盤|HATL による完全性・前方秘匿性・公開検証性の確立。|
|**Agent Execution / Model Runtime（10〜11）**|AI 生成 plan と能力モジュールの実行基盤|Semantic DSL Compiler と DynamicSLM による決定論的 agent execution / capability-modular model runtime。|

# 4. ディレクトリ構成（現行）

コード

```
docs/
  papers/
    01-rom-format-knowledge-snapshot/
    02-vfs-architecture-semantic-storage/
    03-pre-inference-admissibility-governance/
    04-trajectory-governance-model/
    05-async-result-pipeline/
    06-semantic-compilation-architecture/
    07-chat-turn-hashchain-governance/
    08-operator-architecture/
    09-hash-anchored-trust-layer/
    10-semantic-dsl-compiler/
    11-dynamicslm-capability-modular/
```

# 5. 今後の方針

1. **Phase‑1（01〜04）** は理論的完結として維持
    
2. **Phase‑1.1（05〜08）** は実装・拡張フェーズとして継続更新
    
3. **Phase‑3（09: HATL）** を Foundation として AIKernel.NET に統合

4. **Agent Execution / Model Runtime（10〜11）** を DSL / Capability / Model ABI の実装指針として維持
    
5. 各 Paper は独立した DOI 論文として Zenodo に登録
    
6. README はフェーズ境界と更新履歴を明示
    

# 6. ライセンス・引用方法

- ライセンス: **CC BY 4.0**
    
- 各 Paper は Zenodo DOI を付与
    
- 引用時は該当 Paper の DOI を使用
