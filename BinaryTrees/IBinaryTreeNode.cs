using System;

namespace BinaryTrees
{
    public interface IBinaryTreeNode<NodeT, KeyT>
        where NodeT : BinaryTreeNode<NodeT, KeyT>, new()
        where KeyT  : IComparable
    {
        #region PROPERTIES
        KeyT  Key       { get; set; }
        NodeT LeftNode  { get; set; }
        NodeT RightNode { get; set; }
        #endregion
    }
}