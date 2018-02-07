using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public class AVLTreeNode<KeyT> : BinaryTreeNode<AVLTreeNode<KeyT>, KeyT> where KeyT : IComparable
    {
        #region CONSTRUCTORS
        public AVLTreeNode()
        {
        }
        public AVLTreeNode(KeyT key) : base(key)
        {
        }
        #endregion
    }
}
