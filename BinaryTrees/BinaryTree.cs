using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public abstract class BinaryTree <NodeT, KeyT> : IBinaryTree<NodeT, KeyT>
        where KeyT : IComparable
        where NodeT: BinaryTreeNode<NodeT, KeyT>, new()
    {
        #region FIELDS
        private NodeT rootNode;
        #endregion

        #region PROPERTIES
        public NodeT RootNode { get => this.rootNode; set => this.rootNode = value; }
        #endregion

        #region PUBLIC METHODS
        public void Insert(KeyT key)
        {
            var newNode = new NodeT { Key = key };

            if (this.RootNode == null)
            {
                this.RootNode = newNode;
            }
            else
            {
                this.InsertNode(this.RootNode, newNode);
            }
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

        protected bool SearchNode           (NodeT node, KeyT         key   )
        {
            if (node == null)
            {
                return false;
            }
            else
            {
                if (key.CompareTo(node.Key) < 0)
                {
                    return this.SearchNode(node.LeftNode, key);
                }
                else
                {
                    if (key.CompareTo(node.Key) > 0)
                    {
                        return this.SearchNode(node.RightNode, key);
                    }
                    else
                    {
                        return true;
                    }
                }
            }
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
            if (node != null)
            {
                while (node != null && node.LeftNode != null)
                {
                    node = node.LeftNode;
                }

                return node.Key;
            }

            return default(KeyT);
        }
        protected KeyT MaxNode(NodeT node)
        {
            if (node != null)
            {
                while (node != null && node.RightNode != null)
                {
                    node = node.RightNode;
                }

                return node.Key;
            }

            return default(KeyT);
        }

        protected NodeT RemoveNode (NodeT node, KeyT key)
        {
            if (node != null)
            {
                if (key.CompareTo(node.Key) < 0)
                {
                    node.LeftNode = this.RemoveNode(node.LeftNode, key);
                }
                else if (key.CompareTo(node.Key) > 0)
                {
                    node.RightNode = this.RemoveNode(node.RightNode, key);
                }
                else
                {
                    if (node.RightNode == null && node.LeftNode == null)
                    {
                        node = null;
                    }
                    else if (node.LeftNode == null)
                    {
                        node = node.RightNode;
                    }
                    else if (node.RightNode == null)
                    {
                        node = node.LeftNode;
                    }
                    else
                    {
                        var aux = this.FindMinNode(node.RightNode);

                        node.Key = aux.Key;
                        node.RightNode = this.RemoveNode(node.RightNode, aux.Key);
                    }
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
        #endregion
    }
}
