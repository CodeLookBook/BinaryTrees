using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public abstract class BinaryTreeNode <NodeT, KeyT> : IBinaryTreeNode<NodeT, KeyT>

        where NodeT: class, IBinaryTreeNode<NodeT, KeyT>, new()
        where KeyT : IComparable

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
            set => key = (value == null) ? 
                   throw new ArgumentNullException(nameof(value)) : value;
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
        public BinaryTreeNode(KeyT key, NodeT leftNode, NodeT rightNode) : this(key)
        {
            this.LeftNode  = leftNode ;
            this.RightNode = rightNode;
        }
        #endregion

        #region PUBLIC METHODS
        public override bool Equals(object obj  )
        {
            return Equals(obj as BinaryTreeNode<NodeT, KeyT>);
        }
        public          bool Equals(NodeT  other)
        {            
            return other != null &&
                   EqualityComparer<KeyT >.Default.Equals(Key      , other.Key      ) &&
                   EqualityComparer<NodeT>.Default.Equals(LeftNode , other.LeftNode ) &&
                   EqualityComparer<NodeT>.Default.Equals(RightNode, other.RightNode);
        }

        public override int  GetHashCode()
        {
            var hashCode = 1949823637;

            hashCode = hashCode * -1521134295 + EqualityComparer<KeyT> .Default.GetHashCode(Key      );
            hashCode = hashCode * -1521134295 + EqualityComparer<NodeT>.Default.GetHashCode(LeftNode );
            hashCode = hashCode * -1521134295 + EqualityComparer<NodeT>.Default.GetHashCode(RightNode);
            return hashCode;
        }

        public int CompareTo(NodeT other)
        {
            return this.Key.CompareTo(other.Key);
        }
        #endregion
    }
}
