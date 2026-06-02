using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain;

/// <summary>
/// 正準化済みコンテンツと前回ハッシュから現在状態ハッシュを計算する。
/// </summary>
public interface ISemanticHasher
{
    string ComputeHash(string canonicalContent, string previousHash);
}
