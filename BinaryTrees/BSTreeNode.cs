using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public class BSTreeNode<KeyT> : BinaryTreeNode<BSTreeNode<KeyT>, KeyT> where KeyT : IComparable
    {
        #region CONSTRUCTORS
        public BSTreeNode()
        {
        }
        public BSTreeNode(KeyT key) : base(key)
        {
        }
        #endregion
    }
}
