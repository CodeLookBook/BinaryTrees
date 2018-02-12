using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public class BSTreeNode<KeyT> : BinaryTreeNode<BSTreeNode<KeyT>, KeyT>
        where KeyT : IComparable<KeyT>
    {
        #region CONSTRUCTORS
        public BSTreeNode(KeyT key) : base(key)
        {

        }
        public BSTreeNode(BSTreeNode<KeyT> parent, KeyT key) : base(parent, key)
        {

        }
        public BSTreeNode(BSTreeNode<KeyT> parent, KeyT key, BSTreeNode<KeyT> left, BSTreeNode<KeyT> right) : base(parent, key, left, right)
        {

        }
        #endregion

        #region OPERATORS DECLARATION & OVERLOADING
        public static implicit operator BSTreeNode<KeyT>(KeyT value)
        {
            return new BSTreeNode<KeyT> { Key = value };
        }
        public static implicit operator KeyT(BSTreeNode<KeyT> value)
        {
            return value.Key;
        }
        #endregion
    }
}
