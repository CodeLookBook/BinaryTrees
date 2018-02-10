using System;
using System.Collections.Generic;

namespace BinaryTrees
{
     public interface IBinaryTreeNode<NodeT, KeyT> 
        : IEquatable<NodeT>, IComparable<NodeT>

        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, new()
        where KeyT  : IComparable
    {
        KeyT  Key       { get; set; }
        NodeT LeftNode  { get; set; }
        NodeT RightNode { get; set; }
    }
}