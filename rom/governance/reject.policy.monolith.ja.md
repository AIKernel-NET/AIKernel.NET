# 拒絶ポリシー・ガバナンス
Version: 0.1.1-rc1
ID: reject.policy.monolith

拒絶ポリシーは、決定または軌道がなぜ棄却（Deny）されたかを決定するための正典的規則を定義する。
すべての拒絶が明示的で、監査可能であり、正典と整合していることを保証する。

---

## 1. 目的 (Purpose)

拒絶ポリシーの目的は、拒絶の結果を分類するための決定論的で透明なフレームワークを提供することである。
すべての棄却（Deny）または停止（Halt）の決定に、正典およびガバナンスプロセスまで追跡可能な明確な理由が伴うことを保証する。

---

## 2. 拒絶理由の種類 (RejectReasonKind)

拒絶は、以下の正典的な理由の種類のいずれかを使用して分類されなければならない：

- **SAFETY_VIOLATION（安全性違反）**
  提案が危害のリスクをもたらすか、安全原則に違反している。

- **LOGICAL_INCONSISTENCY（論理的不整合）**
  推論に矛盾、無効な推論、または検証不可能な主張が含まれている。

- **CONTEXT_MISALIGNMENT（文脈の不整合）**
  提案がユーザーの意図、文脈、または感情的状態と整合していない。

- **IRREVERSIBLE_ACTION（不可逆な行動）**
  行動が取り消し不可能であり、明示的な正当化を欠いている。

- **INSUFFICIENT_INFORMATION（情報不足）**
  必要な情報が欠落している、曖昧である、または判定不能である。

- **OPAQUE_REASONING（不透明な推論）**
  推論が説明可能、追跡可能、または監査可能ではない。

- **ETHOS_VETO（Ethosの拒否権）**
  EthosがReject票を投じ、絶対的な拒否権を発動した。

- **FAIL_CLOSED（フェイルクローズ）**
  評価の失敗または承認不足により、システムがフェイルクローズ状態に入った。

- **IMPLICIT_DENY（暗黙の拒絶）**
  特定の理由が適用されない、または評価が進行できない場合のデフォルトのフォールバック。

これらの理由の種類は網羅的かつ相互排他的である。

---

## 3. 正典の参照 (Canon Reference)

すべての拒絶には、拒絶を正当化する正典またはガバナンス文書の特定のセクションを指し示す **CanonReference** が含まれなければならない。

例：

- `Canon.CTG.2.1` — 安全性
- `Canon.CTG.2.3` — 可逆性
- `Council.Logos.3` — 論理的整合性
- `Gate.Decision.3.1` — 多数決規則
- `Gate.Trajectory.5` — 停止条件

参照は正確かつ安定的でなければならない。

---

## 4. 拒絶条件 (Reject Conditions)

以下の条件のいずれかが満たされた場合、決定または軌道は拒絶されなければならない：

### 4.1 安全性 (Safety)
提案が危害のリスクをもたらすか、安全原則に違反している。

### 4.2 論理的失敗 (Logical Failure)
推論が一貫していない、矛盾している、不完全である、または検証不可能である。

### 4.3 文脈の不整合 (Contextual Misalignment)
行動がユーザーの意図、境界、または感情的状態を尊重していない。

### 4.4 不可逆性 (Irreversibility)
明示的な正当化なしに行動が不可逆になる。

### 4.5 情報の欠落または曖昧さ (Missing or Ambiguous Information)
データ不足により、システムが提案を評価できない。

### 4.6 不透明な推論 (Opaque Reasoning)
推論が説明できない、または監査できない。

### 4.7 Ethosの拒否権 (Ethos Veto)
EthosがRejectを投じる → 即時のDeny。

### 4.8 フェイルクローズ (Fail-Closed)
システムが判定不能または安全でない状態に入る。

### 4.9 デフォルト (Default)
他の理由が適用されない場合、拒絶は **ImplicitDeny** として分類されなければならない。

---

## 5. 意思決定ゲートとの相互作用 (Interaction with Decision Gate)

拒絶ポリシーは意思決定ゲートと以下のように統合される：

- Ethos = Reject の場合 → RejectReasonKind = **ETHOS_VETO**
- Approve < 2 の場合 → RejectReasonKind = **FAIL_CLOSED**
- 評価が完了できない場合 → **FAIL_CLOSED**
- 推論が失敗した場合 → **LOGICAL_INCONSISTENCY**
- 文脈が不整合な場合 → **CONTEXT_MISALIGNMENT**
- 特定の理由が適用されない場合 → **IMPLICIT_DENY**

意思決定ゲートは常に RejectReasonKind を生成しなければならない。

---

## 6. 軌道ゲートとの相互作用 (Interaction with Trajectory Gate)

軌道ゲートは、同じ RejectReasonKind タクソノミーを使用して Halt イベントを分類しなければならない。

例：

- 可逆性の喪失 → **IRREVERSIBLE_ACTION**
- 安全性の低下 → **SAFETY_VIOLATION**
- 文脈の逸脱 → **CONTEXT_MISALIGNMENT**
- データの欠落 → **INSUFFICIENT_INFORMATION**
- Ethosの拒否権 → **ETHOS_VETO**

軌道の停止には常に理由が伴わなければならない。

---

## 7. 決定論とリプレイ (Determinism and Replay)

拒絶の分類は決定論的でなければならない：

- 同一の入力 → 同一の RejectReasonKind
- GovernanceTrace は以下を含まなければならない：
  - 評議会の票
  - 適用された規則
  - RejectReasonKind
  - CanonReference

リプレイは同じ拒絶を再現しなければならない。

---

## 8. 改訂 (Amendments)

本文書は、Monolith-ROMの将来のバージョンにおいて改訂される可能性がある。
改訂は、明示性、決定論、および監査可能性の原則を保持しなければならない。