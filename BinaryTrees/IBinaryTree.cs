using BinaryTrees.Traversal;
using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public interface IBinaryTree<NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>
        where KeyT : IComparable<KeyT>
    {
        int   Count { get;      }
        NodeT Root  { get; set; }
        ITraversal<NodeT, KeyT> Traversal { get; set; }

        bool All     (Func<KeyT, bool> predicate);
        bool Any     ();
        bool Any     (Func<KeyT, bool> predicate);
        void Clear   ();
        bool Contains(IEnumerable<KeyT> keys);
        bool Contains(KeyT key);
        bool Contains(params KeyT[] keys);
        void CopyTo  (KeyT[] array);
        void Insert  (KeyT key);
        void Insert  (params KeyT[] key);
        bool Remove  (IEnumerable<KeyT> keys);
        bool Remove  (KeyT key);
        bool Remove  (params KeyT[] keys);
        bool Remove  (Predicate<KeyT> match);
    }
}