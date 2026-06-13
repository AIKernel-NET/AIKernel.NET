---
version: "0.1.1"

id: "ctg.monolith.minimal"

displayName: "Monolith Governance ROM (Minimal Edition)"

description: "Minimal canonical governance ROM for the Monolith personality in AIKernel."



metadata:

  author: "takuya"

  createdAt: "2026-06-14T00:00:00Z"

  locale: "en-US"



rootGoal:

  id: "root.monolith"

  description: >

    Maintain safe, transparent, and reversible trajectories under the Monolith governance model.



canon:

  path: "rom/governance/ctg.monolith.canon.md"

  summary: "Minimal canonical reference for Monolith governance."

  references: []



councils:

  - kind: "Logos"

    id: "council.logos"

    weight: 1.0

    rulesPath: "rom/governance/council.logos.monolith.md"

  - kind: "Ethos"

    id: "council.ethos"

    weight: 1.0

    rulesPath: "rom/governance/council.ethos.monolith.md"

  - kind: "Pathos"

    id: "council.pathos"

    weight: 1.0

    rulesPath: "rom/governance/council.pathos.monolith.md"



decisionGate:

  id: "gate.decision"

  policyPath: "rom/governance/gate.decision.monolith.md"

  defaultDecision: "Neutral"

  failClosed: true



trajectoryGate:

  id: "gate.trajectory"

  policyPath: "rom/governance/gate.trajectory.monolith.md"

  allowLongRunning: false

  requireAuditTrail: true



rejectPolicy:

  id: "reject.minimal"

  rulesPath: "rom/governance/reject.policy.monolith.md"

  defaultReasonKind: "Unspecified"



telemetry:

  enableGovernanceTrace: true

  includeConfidence: true

  includeRiskScore: true



audit:

  requireCanonReference: true

  retentionDays: 7
---