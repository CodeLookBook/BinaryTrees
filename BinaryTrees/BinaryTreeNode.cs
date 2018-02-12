using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTrees
{
    public abstract class BinaryTreeNode<NodeT, KeyT> : IBinaryTreeNode<NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>
        where KeyT  : IComparable <KeyT>
    {
        #region FIELDS
        private KeyT  key   ;
        private NodeT parent;
        private NodeT left  ;
        private NodeT right ;
        #endregion

        #region PROPERTIES
        public KeyT  Key    { get => this.key   ; set => this.key    = value; }
        public NodeT Parent { get => this.parent; set => this.parent = value; }
        public NodeT Left   { get => this.left  ; set => this.left   = value; }
        public NodeT Right  { get => this.right ; set => this.right  = value; }
        #endregion

        #region CONSTRUCTORS
        public BinaryTreeNode(KeyT key) 
        {
            this.Key = key;
        }
        public BinaryTreeNode(KeyT key, NodeT parent) : this(key)
        {
            this.Parent = parent;
        }
        public BinaryTreeNode(KeyT key, NodeT parent, NodeT left, NodeT right) : this(key, parent)
        {
            this.Left  = left ;
            this.Right = right;
        }
        #endregion

        #region METHODS
        public override bool Equals(object obj  )
        {
            return Equals(obj as NodeT);
        }
        public          bool Equals(NodeT  other)
        {
            return other != null &&
                   EqualityComparer<NodeT>.Default.Equals(Parent, other.Parent) &&
                   EqualityComparer<KeyT >.Default.Equals(Key   , other.Key   ) &&
                   EqualityComparer<NodeT>.Default.Equals(Left  , other.Left  ) &&
                   EqualityComparer<NodeT>.Default.Equals(Right , other.Right );
        }

        public override int GetHashCode()
        {
            var hashCode = -326891413;

            hashCode = hashCode * -1521134295 + EqualityComparer<NodeT>.Default.GetHashCode(Parent);
            hashCode = hashCode * -1521134295 + EqualityComparer<KeyT >.Default.GetHashCode(Key   );
            hashCode = hashCode * -1521134295 + EqualityComparer<NodeT>.Default.GetHashCode(Left  );
            hashCode = hashCode * -1521134295 + EqualityComparer<NodeT>.Default.GetHashCode(Right );

            return hashCode;
        }

        public int CompareTo(NodeT other)
        {
            return this.Key.CompareTo(other.Key);
        }
        #endregion
    }
}
