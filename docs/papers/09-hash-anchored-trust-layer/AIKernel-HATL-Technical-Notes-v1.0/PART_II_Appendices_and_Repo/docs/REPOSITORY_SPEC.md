# Recommended Repository Topology

```text
/AIKernel.Hatl
  LICENSE
  README.md
  HATL_SPEC.md
  /src
    /AIKernel.Hatl.Core
      HatlEngine.cs
      KeyRatchet.cs
      SymmetricLedger.cs
    /AIKernel.Hatl.Anchor
      MerkleTree.cs
      StatefulHbsIssuer.cs
      SlhDsaAnchorIssuer.cs
  /schemas
    hatl-block-mac.schema.json
    hatl-public-anchor.schema.json
    hatl-digital-deed.schema.json
  /contracts
    HatlGovernance.sol
  /tests
    RatchetTests.cs
    AnchorVerificationTests.cs
    CanonicalizationTests.cs
    BenchmarkProfiles.json
```

## Build Profile

- Runtime: .NET 11/12 or later when available.
- Language: C#.
- Code license: Apache-2.0.
- Documents: CC-BY-4.0.

## Required Test Classes

1. Canonicalization stability tests.
2. HKDF ratchet forward-progress tests.
3. BlockMAC chain break detection tests.
4. Merkle inclusion proof tests.
5. Public anchor signature verification tests.
6. Digital Deed revocation tests.
7. Crash-recovery tests for stateful HBS counters.
