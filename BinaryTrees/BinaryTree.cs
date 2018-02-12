using BinaryTrees.Traversal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BinaryTrees
{
    public abstract class BinaryTree<NodeT, KeyT> : IBinaryTree<NodeT, KeyT>

        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>
        where KeyT  : IComparable<KeyT>
    {
        #region FIELDS
        private NodeT                  root;
        private ITraversal<NodeT,KeyT> traversal;
        private TraversalMode          traversalMode;
        #endregion

        #region PROPERTIES
        public NodeT Root                  { get => this.root         ; set => this.root     = value; }
        public TraversalMode TraversalMode { get => this.traversalMode; set => traversalMode = value; }
        public ITraversal<NodeT, KeyT> Traversal
        {
            get => this.traversal;
            set => this.traversal = value ?? throw new ArgumentNullException(nameof(value));
        }
        public int   Count { get; protected set; }
        #endregion

        #region CONSTRUCTOR
        public BinaryTree(ITraversal<NodeT, KeyT> traversal, TraversalMode traversalMode)
        {
            this.Traversal = traversal;
        }
        #endregion

        #region PUBLIC METHODS
        public abstract void Insert(KeyT key);
        public void Insert  (params KeyT[]     keys)
        {
            foreach (var key in keys) { this.Insert(key); }
        }
        public void Insert  (IEnumerable<KeyT> keys)
        {
            foreach (var key in keys) { this.Insert(key); }
        }

        public bool Contains(KeyT key)
        {
            return (this.Find(key) != null);
        }
        public bool Contains(params KeyT[]     keys)
        {
            var contains = true;

            foreach (var key in keys)
            {
                if (!this.Contains(key))
                {
                    contains = false;
                    break;
                }
            }

            return contains;
        }
        public bool Contains(IEnumerable<KeyT> keys)
        {
            var contains = true;

            foreach (var key in keys)
            {
                if (!this.Contains(key))
                {
                    contains = false;
                    break;
                }
            }

            return contains;
        }

        public abstract bool Remove(KeyT key);
        public bool Remove  (params KeyT[]     keys )
        {
            throw new NotImplementedException();
        }
        public bool Remove  (IEnumerable<KeyT> keys )
        {
            throw new NotImplementedException();
        }
        public bool Remove  (Predicate<KeyT>   match)
        {
            throw new NotImplementedException();
        }

        public void CopyTo  (KeyT[] array)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Any()
        {
            throw new NotImplementedException();
        }
        public bool Any(Func<KeyT, bool> predicate)
        {
            throw new NotImplementedException();
        }
        public bool All(Func<KeyT, bool> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region PRIVATE METHODS
        protected NodeT Find(KeyT key)
        {
            var current = this.Root;
            var found   = false; 

            while (current != null && !found)
            {
                switch (current.Key.CompareTo(key))
                {
                    case  1: current = current.Left ; break;
                    case -1: current = current.Right; break;
                    case  0: found   = true         ; break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }

            return current;
        }
        #endregion

        #region FACTORY METHODS
        protected virtual ITraversal<NodeT, KeyT> CreateTraversal(TraversalType type)
        {
            switch (type)
            {
                case TraversalType.InOrder  : return new InOrderTraversal  <NodeT, KeyT>();
                case TraversalType.PreOrder : return new PreOrderTraversal <NodeT, KeyT>();
                case TraversalType.PostOrder: return new PostOrderTraversal<NodeT, KeyT>();
                default: throw new InvalidEnumArgumentException();
            }
        }

        #endregion
    }
}
