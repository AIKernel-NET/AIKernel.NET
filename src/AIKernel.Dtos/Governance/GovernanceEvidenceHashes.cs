namespace AIKernel.Dtos.Governance;

/// <summary>EN: SHA-256 references to the four evidence artifacts for a trajectory. JA: 軌道評価に対応する4種類の証跡のSHA-256参照です。</summary>
public sealed record GovernanceEvidenceHashes(string RomHash, string StateHash, string ActionHash, string ReplayLogHash);
