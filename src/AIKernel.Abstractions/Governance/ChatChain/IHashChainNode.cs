using System;
using System.Collections.Generic;
using System.Text;

namespace AIKernel.Abstractions.Governance.ChatChain
{
    /// <summary>Gets the IHashChainNode value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される IHashChainNode 値を取得します。</summary>
    public interface IHashChainNode
    {
        /// <summary>Gets the Turn value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Turn 値を取得します。</summary>
        IChatTurn Turn { get; }
        /// <summary>Gets the PrevHash value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される PrevHash 値を取得します。</summary>
        string PrevHash { get; }
        /// <summary>Gets the Hash value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Hash 値を取得します。</summary>
        string Hash { get; }
        /// <summary>Gets the Signature value exposed by the AIKernel public contract surface. JA: AIKernel の公開契約サーフェスで公開される Signature 値を取得します。</summary>
        string? Signature { get; }
    }

}
