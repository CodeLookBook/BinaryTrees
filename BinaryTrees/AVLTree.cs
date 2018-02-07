using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTrees
{
    public class AVLTree<KeyT> : BinaryTree<AVLTreeNode<KeyT>, KeyT> where KeyT : IComparable
    {
        protected override void InsertNode(AVLTreeNode<KeyT> parentNode, AVLTreeNode<KeyT> newNode)
        {
            if (parentNode == null) throw new ArgumentNullException(nameof(parentNode));
            if (newNode    == null) throw new ArgumentNullException(nameof(newNode   ));

            if (newNode.Key.CompareTo(parentNode.Key) < 0)
            {
                if (parentNode.LeftNode == null)
                {
                    parentNode.LeftNode = newNode;
                }
                else
                {
                    this.InsertNode(parentNode.LeftNode, newNode);

                    // verify if balancing is needed {1} 

                    if ((this.NodeHeight(parentNode.LeftNode) - this.NodeHeight(parentNode.RightNode)) > 1)
                    {
                        if (newNode.Key.CompareTo(parentNode.LeftNode.Key) < 0)
                        {
                            parentNode.LeftNode = this.RotationLL(parentNode);
                        }
                        else
                        {
                            parentNode.LeftNode = this.RotationLR(parentNode);
                        }
                    }
                }
            }
            else
            {
                if (parentNode.RightNode == null)
                {
                    parentNode.RightNode = newNode;
                }
                else
                {
                    this.InsertNode(parentNode.RightNode, newNode);

                    // verify if balancing is needed {2} 

                    if ((this.NodeHeight(parentNode.RightNode) - this.NodeHeight(parentNode.LeftNode)) > 1)
                    {
                        if (newNode.Key.CompareTo(parentNode.RightNode.Key) > 0)
                        {
                            parentNode.RightNode = this.RotationRR(parentNode);
                        }
                        else
                        {
                            parentNode.RightNode = this.RotationRL(parentNode);
                        }
                    }
                }
            }
        }

        protected int NodeHeight(AVLTreeNode<KeyT> node)
        {
            return (node == null) ? - 1 : Math.Max(NodeHeight(node.LeftNode), NodeHeight(node.RightNode)) + 1;
        }

        protected AVLTreeNode<KeyT> RotationRR(AVLTreeNode<KeyT> node)
        {
            var tmp = node.RightNode;

            node.RightNode = tmp.LeftNode;

            tmp.LeftNode = node;

            return tmp;
        }
        protected AVLTreeNode<KeyT> RotationLL(AVLTreeNode<KeyT> node)
        {
            var tmp = node.LeftNode;

            node.LeftNode = tmp.RightNode;

            tmp.RightNode = node;

            return tmp; 
        }
        protected AVLTreeNode<KeyT> RotationLR(AVLTreeNode<KeyT> node)
        {
            node.LeftNode = this.RotationRR(node.LeftNode);

            return this.RotationLL(node);
        }
        protected AVLTreeNode<KeyT> RotationRL(AVLTreeNode<KeyT> node)
        {
            node.RightNode = this.RotationLL(node.RightNode);

            return this.RotationRR(node);
        }
    }
}
