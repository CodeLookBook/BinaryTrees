using System;

namespace BinaryTrees
{
    public interface IBinaryTree<NodeT, KeyT>
        where NodeT : BinaryTreeNode<NodeT, KeyT>, IBinaryTreeNode<NodeT, KeyT>, new()
        where KeyT : IComparable
    {
        #region PROPERTIES
        NodeT RootNode { get; set; }
        #endregion

        #region METHODS
        void Insert(KeyT key);
        void Remove(KeyT key);
        bool Search(KeyT key);

        KeyT Max();
        KeyT Min();

        void PreOrderTraverse (Action<KeyT> action);
        void InOrderTraverse  (Action<KeyT> action);
        void PostOrderTraverse(Action<KeyT> action);
        #endregion
    }
}