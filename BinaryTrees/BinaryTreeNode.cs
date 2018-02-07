using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public abstract class BinaryTreeNode <NodeT, KeyT> : IBinaryTreeNode<NodeT, KeyT>
        where KeyT : IComparable
        where NodeT: BinaryTreeNode<NodeT, KeyT>, new()
    {
        #region FIELDS
        private KeyT  key      ;
        private NodeT leftNode ;
        private NodeT rightNode;
        #endregion

        #region PROPERTIES
        public KeyT  Key
        {
            get => key;
            set => key = value == null? throw new ArgumentNullException(nameof(value)) : value;
        }
        public NodeT LeftNode  { get => leftNode ; set => leftNode  = value; }
        public NodeT RightNode { get => rightNode; set => rightNode = value; }
        #endregion

        #region CONSTRUCTORS
        public BinaryTreeNode()
        {

        }
        public BinaryTreeNode(KeyT key)
        {
            this.Key = key;
        }
        #endregion

    }
}
