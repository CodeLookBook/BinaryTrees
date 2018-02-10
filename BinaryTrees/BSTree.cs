using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class BSTree <KeyT> : BinaryTree <BSTreeNode<KeyT>, KeyT> 
        where KeyT : IComparable
    {
        #region PROTECTED METHODS
        protected override void InsertNode(BSTreeNode<KeyT> parentNode, BSTreeNode<KeyT> newNode)
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
                }
            }
        }
        #endregion
    }
}
