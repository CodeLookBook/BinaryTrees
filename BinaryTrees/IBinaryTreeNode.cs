using System;

namespace BinaryTrees
{
    public interface IBinaryTreeNode<NodeT, KeyT> : IEquatable<NodeT>, IComparable<NodeT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>
        where KeyT  : IComparable<KeyT>
    {
        KeyT  Key    { get; set; }
        NodeT Left   { get; set; }
        NodeT Parent { get; set; }
        NodeT Right  { get; set; }

        bool Equals(object obj);

        int  GetHashCode();
    }
}