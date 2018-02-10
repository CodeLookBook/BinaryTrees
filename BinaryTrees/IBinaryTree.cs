using System;

namespace BinaryTrees
{
    public interface IBinaryTree<KeyT>: IEquatable<IBinaryTree<KeyT>> where KeyT : IComparable
    {
        bool Equals(object obj);
        int  Count { get; }
        int  GetHashCode();
        void InOrderTraverse(Action<KeyT> action);
        void Insert(KeyT key);
        KeyT Max();
        KeyT Min();
        void PostOrderTraverse(Action<KeyT> action);
        void PreOrderTraverse (Action<KeyT> action);
        void Remove(KeyT key);
        bool Search(KeyT key);
    }
}