using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Traversal
{
    public class InOrderTraversal<NodeT, KeyT> : Traversal<NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>
        where KeyT : IComparable<KeyT>
    {
        public    override void Traverse  (NodeT root, Action<KeyT> action, TraversalMode mode = TraversalMode.LeftToRight)
        {
            switch (mode)
            {
                case TraversalMode.LeftToRight: this.TraverseLR(root, action); break;
                case TraversalMode.RightToLeft: this.TraverseRL(root, action); break;
                default: throw new ArgumentOutOfRangeException(nameof(mode));
            }
        }
        protected override void TraverseLR(NodeT root, Action<KeyT> action)
        {
            if (root   == null) return;
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stack   = new Stack<NodeT>();
            var current = root;

            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);

                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();

                    action(current.Key);

                    current = current.Right;
                }
            }
        }
        protected override void TraverseRL(NodeT root, Action<KeyT> action)
        {
            if (root   == null) return;
            if (action == null) throw new ArgumentNullException(nameof(action));

            var stack   = new Stack<NodeT>();
            var current = root;

            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);

                    current = current.Right;
                }
                else
                {
                    current = stack.Pop();

                    action(current.Key);

                    current = current.Left;
                }
            }
        }

        public    override IEnumerable<KeyT> Traverse  (NodeT root, TraversalMode mode = TraversalMode.LeftToRight)
        {
            IEnumerable<KeyT> result = null;

            switch (mode)
            {
                case TraversalMode.LeftToRight: result = this.TraverseLR(root); break;
                case TraversalMode.RightToLeft: result = this.TraverseRL(root); break;
                default: throw new ArgumentOutOfRangeException(nameof(mode));
            }

            return result;
        }
        protected override IEnumerable<KeyT> TraverseLR(NodeT root)
        {
            if (root != null)
            {
                var stack = new Stack<NodeT>();
                var current = root;

                while (stack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        stack.Push(current);

                        current = current.Left;
                    }
                    else
                    {
                        current = stack.Pop();

                        yield return current.Key;

                        current = current.Right;
                    }
                }
            }
        }
        protected override IEnumerable<KeyT> TraverseRL(NodeT root)
        {
            if (root != null)
            {
                var stack   = new Stack<NodeT>();
                var current = root;

                while (stack.Count > 0 || current != null)
                {
                    if (current != null)
                    {
                        stack.Push(current);

                        current = current.Right;
                    }
                    else
                    {
                        current = stack.Pop();

                        yield return current.Key;

                        current = current.Left;
                    }
                }
            }
        }
    }
}
