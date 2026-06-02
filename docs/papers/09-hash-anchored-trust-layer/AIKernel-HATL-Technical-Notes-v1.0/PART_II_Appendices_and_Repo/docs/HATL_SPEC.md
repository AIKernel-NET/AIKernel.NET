# HATL Protocol Specification Summary

## 1. BlockMAC

A BlockMAC binds one canonical event record to the previous BlockMAC, the execution outcome hash, and the active capability scope.

Required invariants:

1. The serialized message is deterministic and versioned.
2. The `hmac_signature` field is excluded from the authenticated message.
3. The previous BlockMAC is included to preserve causal ordering.
4. The active epoch key is advanced after each successful commitment.

## 2. Key Ratchet

Recommended key transition:

```text
K_{t+1} = HKDF-Expand(HKDF-Extract(salt_t, K_t), info = event_hash || sequence_number, L = 64)
```

Implementation requirements:

- Old keys must be erased or made inaccessible.
- In C#/.NET implementations, secret buffers must not rely on garbage collection for timely erasure; use short-lived spans or memory slices, pinned/native memory for high-risk key material, and explicit zeroization such as `CryptographicOperations.ZeroMemory` before releasing buffers.
- Ratchet context must include sequence information.
- Key derivation must be deterministic for replay within a protected test environment, but production secrets must not be stored in replay artifacts.

## 3. Merkle Anchor Window

The Merkle tree should use domain-separated leaf and node hashing:

```text
leaf = H("HATL-LEAF" || canonical(block_mac))
node = H("HATL-NODE" || left || right)
```

## 4. Public Anchor

A public anchor document binds:

- policy epoch,
- anchor window sequence range,
- Merkle root,
- previous anchor hash,
- public signature type,
- signature bytes.

Supported anchor profiles:

- LMS / HSS under strict state management,
- XMSS / XMSS^MT under strict state management,
- SLH-DSA for stateless public anchoring.

## 5. Digital Deed

A Digital Deed defines the trust status of a node. Runtime policy enforcement must reject privileged work from `SUSPENDED` or `REVOKED` identities. If quorum verification, evidence retrieval, policy lookup, or anchor status resolution is `Indeterminate`, the decision must be treated as `Deny` and the runtime must fail closed until a valid decision can be established.

## 6. Privacy-Preserving Anchor Extension

Future anchor profiles may use zero-knowledge proofs, including zk-SNARKs, to prove that a batch was processed according to the required HATL ledger-transition rules without exposing the underlying Merkle path, event history, or private ReplayLog contents.
