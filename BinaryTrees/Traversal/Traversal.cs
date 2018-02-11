using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Traversal
{
    public abstract class Traversal<NodeT, KeyT> : ITraversal<NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>, new()
        where KeyT : IComparable<KeyT>
    {
        public    abstract void Traverse  (NodeT root, Action<KeyT> action, TraversalMode mode);
        protected abstract void TraverseLR(NodeT root, Action<KeyT> action);
        protected abstract void TraverseRL(NodeT root, Action<KeyT> action);

        public    abstract IEnumerable<KeyT> Traverse  (NodeT root, TraversalMode mode);
        protected abstract IEnumerable<KeyT> TraverseLR(NodeT root);
        protected abstract IEnumerable<KeyT> TraverseRL(NodeT root);
    }
}
