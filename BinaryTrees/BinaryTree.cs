using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public abstract class BinaryTree <NodeT, KeyT> : IBinaryTree<KeyT>
        
        where NodeT: class, IBinaryTreeNode<NodeT, KeyT>, new()
        where KeyT : IComparable
    {
        #region FIELDS
        private NodeT rootNode;
        #endregion

        #region PROPERTIES
        protected NodeT RootNode { get => this.rootNode; set => this.rootNode = value; }
        public    int   Count    { get; protected set; }
        #endregion

        #region EVENTS
        public event EventHandler<KeyT> OnInserted;
        public event EventHandler<KeyT> OnRemoved ;
        #endregion

        #region CONSTRUCTORS
        public BinaryTree()
        {
            this.OnInserted += BinaryTree_OnInserted;
            this.OnRemoved  += BinaryTree_OnRemoved ;
        }
        #endregion

        #region PUBLIC METHODS
        public void Insert(KeyT key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var newNode = new NodeT { Key = key };

            if (this.RootNode == null)
            {
                this.RootNode = newNode;
            }
            else
            {
                this.InsertNode(this.RootNode, newNode);
            }

            this.OnInserted?.Invoke(this, key);
        }
        public bool Search(KeyT key)
        {
            return this.SearchNode(this.RootNode, key);
        }
        public void Remove(KeyT key)
        {
            this.RootNode = this.RemoveNode(this.RootNode, key);
        }

        public void InOrderTraverse  (Action<KeyT> action)
        {
            this.InOrderTraverseNode(this.RootNode, action);
        }
        public void PreOrderTraverse (Action<KeyT> action)
        {
            this.PreOrderTraverseNode(this.RootNode, action);
        }
        public void PostOrderTraverse(Action<KeyT> action)
        {
            this.PostOrderTraverseNode(this.RootNode, action);
        }

        public KeyT Min()
        {
            return this.MinNode(this.RootNode);
        }
        public KeyT Max()
        {
            return this.MaxNode(this.RootNode);
        }
        #endregion

        #region PROTECTED METHODS
        protected abstract void InsertNode(NodeT parentNode, NodeT newNode);

        /// <summary>
        /// Searches tree node by key value.
        /// </summary>
        /// <param name="key">Key value</param>
        /// <returns>Node instance or null - if node doesn't excist.</returns>
        private NodeT Find(KeyT key)
        {
            var current = this.RootNode;

            while (current != null)
            {
                int result = Comparer<KeyT>.Default.Compare(current.Key, key);

                if (result > 0)
                {
                    current = current.LeftNode;
                }
                else if (result < 0)
                {
                    current = current.RightNode;
                }
                else
                {
                    break;
                }
            }
            return current;
        }


        protected bool SearchNode           (NodeT node, KeyT         key   )
        {
            bool isFind = false;

            if (node == null)
            {
                isFind = false;
            }
            else
            {
                if (Comparer<KeyT>.Default.Compare(key, node.Key) < 0)
                {
                    isFind = this.SearchNode(node.LeftNode, key);
                }
                else
                {
                    if (Comparer<KeyT>.Default.Compare(key, node.Key) > 0)
                    {
                        isFind = this.SearchNode(node.RightNode, key);
                    }
                    else
                    {
                        isFind = true;
                    }
                }
            }

            return isFind;
        }
        protected void InOrderTraverseNode  (NodeT node, Action<KeyT> action)
        {
            if (node != null)
            {
                this.InOrderTraverseNode(node.LeftNode, action);

                action(node.Key);

                this.InOrderTraverseNode(node.RightNode, action);
            }
        }
        protected void PreOrderTraverseNode (NodeT node, Action<KeyT> action)
        {
            if (node != null)
            {
                action(node.Key);

                this.PreOrderTraverseNode(node.LeftNode, action);
                this.PreOrderTraverseNode(node.RightNode, action);
            }
        }
        protected void PostOrderTraverseNode(NodeT node, Action<KeyT> action)
        {
            if (node != null)
            {
                this.PostOrderTraverseNode(node.LeftNode, action);
                this.PostOrderTraverseNode(node.RightNode, action);

                action(node.Key);
            }
        }

        protected KeyT MinNode(NodeT node)
        {
            KeyT min  = default(KeyT);

            if (node != null)
            {
                while (node != null && node.LeftNode != null)
                {
                    node = node.LeftNode;
                }

                min  = node.Key;
            }
            
            return min;
        }
        protected KeyT MaxNode(NodeT node)
        {
            KeyT max = default(KeyT);

            if (node != null)
            {
                while (node != null && node.RightNode != null)
                {
                    node = node.RightNode;
                }

                max = node.Key;
            }

            return max;
        }

        protected NodeT RemoveNode (NodeT node, KeyT key)
        {
            if (node != null)
            {
                if (Comparer<KeyT>.Default.Compare(key, node.Key) < 0)
                {
                    node.LeftNode = this.RemoveNode(node.LeftNode, key);
                }
                else if (Comparer<KeyT>.Default.Compare(key, node.Key) > 0)
                {
                    node.RightNode = this.RemoveNode(node.RightNode, key);
                }
                else
                {
                    KeyT e = default(KeyT);

                    if (node.RightNode == null && node.LeftNode == null)
                    {
                        e    = node.Key;
                        node = null;
                    }
                    else
                    {
                        if (node.LeftNode == null)
                        {
                            e    = node.Key;
                            node = node.RightNode;                        
                        }
                        else if (node.RightNode == null)
                        {
                            e    = node.Key;
                            node = node.LeftNode;
                        }
                        else
                        {
                            e = node.Key;

                            var aux = this.FindMinNode(node.RightNode);

                            node.Key = aux.Key;
                            node.RightNode = this.RemoveNode(node.RightNode, aux.Key);
                        }
                    }

                    this.OnRemoved?.Invoke(this, e);
                }

            }

            return node;
        }
        protected NodeT FindMinNode(NodeT node)
        {
            while (node != null && node.LeftNode != null)
            {
                node = node.LeftNode;
            }

            return node;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BinaryTree<NodeT, KeyT>);
        }
        public virtual  bool Equals(IBinaryTree<KeyT> other)
        {
            bool Comparer(NodeT n1, NodeT n2)
            {
                return (n1.CompareTo(n2) == 0             ) && 
                       Comparer(n1.LeftNode , n2.LeftNode ) &&
                       Comparer(n1.RightNode, n2.RightNode);
            }

            return Comparer(this.RootNode, (other as BinaryTree<NodeT, KeyT>).RootNode);
        }

        public override int GetHashCode()
        {
            return -120845931 + EqualityComparer<NodeT>.Default.GetHashCode(RootNode);
        }
        #endregion

        #region EVENT HANDLERS
        private void BinaryTree_OnInserted(object sender, KeyT e)
        {
            this.Count++;
        }
        private void BinaryTree_OnRemoved (object sender, KeyT e)
        {
            this.Count--;
        }
        #endregion
    }
}
