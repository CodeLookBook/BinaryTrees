using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Traversal
{
    public class PostOrderTraversal<NodeT, KeyT> : Traversal<NodeT, KeyT>
        where NodeT : class, IBinaryTreeNode<NodeT, KeyT>, IComparable<NodeT>, new()
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

            var visited = new Stack<NodeT>();
            var marker  = new Stack<Boolean>();
            var current = root;
            var done    = false;

            while (!done)
            {
                if (current != null)
                {
                    visited.Push(current);

                    marker.Push(false);

                    current = current.Left;
                }
                else if (!visited.Any())
                {
                    done = true;
                }
                else
                {
                    current = visited.Pop();
                    if (!marker.Pop())
                    {
                        visited.Push(current);

                        marker.Push(true);

                        current = current.Right;
                    }
                    else
                    {
                        action(current.Key);

                        current = null;
                    }
                }
            }
        }
        protected override void TraverseRL(NodeT root, Action<KeyT> action)
        {
            if (root   == null) return;
            if (action == null) throw new ArgumentNullException(nameof(action));

            var visited = new Stack<NodeT>  ();
            var marker  = new Stack<Boolean>();
            var current = root;
            var done    = false;

            while (!done)
            {
                if (current != null)
                {
                    visited.Push(current);

                    marker.Push(false);

                    current = current.Right;
                }
                else if (!visited.Any())
                {
                    done = true;
                }
                else
                {
                    current = visited.Pop();

                    if (!marker.Pop())
                    {
                        visited.Push(current);

                        marker.Push(true);

                        current = current.Left;
                    }
                    else
                    {
                        action(current.Key);

                        current = null;
                    }
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
                var visited = new Stack<NodeT>  ();
                var marker  = new Stack<Boolean>();
                var current = root;
                var done    = false;

                while (!done)
                {
                    if (current != null)
                    {
                        visited.Push(current);

                        marker.Push(false);

                        current = current.Left;
                    }
                    else if (!visited.Any())
                    {
                        done = true;
                    }
                    else
                    {
                        current = visited.Pop();

                        if (!marker.Pop())
                        {
                            visited.Push(current);

                            marker.Push(true);

                            current = current.Right;
                        }
                        else
                        {
                            yield return current.Key;

                            current = null;
                        }
                    }
                }
            }
        }
        protected override IEnumerable<KeyT> TraverseRL(NodeT root)
        {
            if (root != null)
            {
                var visited = new Stack<NodeT>();
                var marker  = new Stack<Boolean>();
                var current = root;
                var done    = false;

                while (!done)
                {
                    if (current != null)
                    {
                        visited.Push(current);

                        marker.Push(false);

                        current = current.Right;
                    }
                    else if (!visited.Any())
                    {
                        done = true;
                    }
                    else
                    {
                        current = visited.Pop();

                        if (!marker.Pop())
                        {
                            visited.Push(current);

                            marker.Push(true);

                            current = current.Left;
                        }
                        else
                        {
                            yield return current.Key;

                            current = null;
                        }
                    }
                }
            }
        }        
    }
}
