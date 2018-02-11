using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Traversal
{
    public interface ITraversal <NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>, new()
        where KeyT  : IComparable<KeyT>
    {
        void Traverse(NodeT root, Action<KeyT> action, TraversalMode mode);
        IEnumerable<KeyT> Traverse(NodeT root, TraversalMode mode);
    }
}
