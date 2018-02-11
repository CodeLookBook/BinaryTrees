using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Traversal
{
    public class TraversalFactory <NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>, new()
        where KeyT  : IComparable<KeyT>
    {
        ITraversal<NodeT, KeyT> Create(TraversalType type, TraversalMode direction)
        {
            ITraversal<NodeT, KeyT> traverse = null;

            switch (type)
            {
                case TraversalType.InOrder  : 
                    traverse = new InOrderTraversal  <NodeT, KeyT>();
                    break;
                case TraversalType.PreOrder :
                    traverse = new PreOrderTraversal <NodeT, KeyT>();
                    break;
                case TraversalType.PostOrder:
                    traverse = new PostOrderTraversal<NodeT, KeyT>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }

            return traverse;
        } 
    }
}
