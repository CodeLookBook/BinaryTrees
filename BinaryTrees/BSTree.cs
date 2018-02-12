using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class BSTree<KeyT> : BinaryTree<BSTreeNode<KeyT>, KeyT> where KeyT : IComparable<KeyT>
    {
        public override void Insert(KeyT key)
        {
            if (key == null) { throw new ArgumentNullException(nameof(key)); }

            var current = this.Root;

            if (this.Root == null)
            {
                this.Root = new BSTreeNode<KeyT>(key);
            }
            else
            {
                while (true)
                {
                    if (current.Key.CompareTo(key) > 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = new BSTreeNode<KeyT>(key, current);
                            break;
                        }
                        else
                        {
                            current = current.Left;
                        }
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = new BSTreeNode<KeyT>(key, current);
                            break;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                }
            }

            this.Count++;
            this.OnInserted?.Invoke(this, key);
        }
        //public override bool Remove(KeyT key)
        //{
        //    var current = Find(key);

        //    if (current == null) { return false; }

        //    this.Count--;

        //    // Вариант 1: Если удаляемый узел не имеет правого потомка      

        //    if (current.Right == null)
        //    {
        //        if (current.Parent == null)
        //        {
        //            this.Root = current.Left;

        //            if (this.Root != null) { this.Root.Parent = null; }
        //        }
        //        else // удаляемый узел не является корнем
        //        {
        //            int result = current.Parent.Key.CompareTo(current.Key);

        //            switch (current.Parent.Key.CompareTo(current.Key))
        //            {
        //                case  1: current.Parent.Left  = current.Left; break;
        //                case -1: current.Parent.Right = current.Left; break;
        //                default: throw new Exception();
        //            }

        //            if (result > 0)
        //            {
        //                // Если значение родительского узла больше значения удаляемого,
        //                // сделать левого потомка удаляемого узла, левым потомком родителя.  

        //                current.Parent.Left = current.Left;
        //            }
        //            else if (result < 0)
        //            {

        //                // Если значение родительского узла меньше чем удаляемого,                 
        //                // сделать левого потомка удаляемого узла - правым потомком родительского узла.                 

        //                current.Parent.Right = current.Left;
        //            }
        //        }
        //    }

        //    // Вариант 2: Если правый потомок удаляемого узла не имеет левого потомка, тогда правый потомок удаляемого узла
        //    // становится потомком родительского узла.      

        //    else if (current.Right.Left == null) // если у правого потомка нет левого потомка
        //    {
        //        current.Right.Left = current.Left;

        //        if (current.Parent == null) // текущий элемент является корнем
        //        {
        //            Root = current.Right;

        //            if (Root != null)
        //            {
        //                Root.Parent = null;
        //            }
        //        }
        //        else
        //        {
        //            int result = current.Parent.CompareTo(current.Value);
        //            if (result > 0)
        //            {
        //                // Если значение узла родителя больше чем значение удаляемого узла,                 
        //                // сделать правого потомка удаляемого узла, левым потомком его родителя.                 

        //                current.Parent.Left = current.Right;
        //            }

        //            else if (result < 0)
        //            {
        //                // Если значение родительского узла меньше значения удаляемого,                 
        //                // сделать правого потомка удаляемого узла - правым потомком родителя.                 

        //                current.Parent.Right = current.Right;
        //            }
        //        }
        //    }

        //    // Вариант 3: Если правый потомок удаляемого узла имеет левого потомка,      
        //    // заместить удаляемый узел, крайним левым потомком правого потомка.     
        //    else
        //    {
        //        // Нахожление крайнего левого узла для правого потомка удаляемого узла.       

        //        AVLTreeNode<T> leftmost = current.Right.Left;

        //        while (leftmost.Left != null)
        //        {
        //            leftmost = leftmost.Left;
        //        }

        //        // Родительское правое поддерево становится родительским левым поддеревом.         

        //        leftmost.Parent.Left = leftmost.Right;

        //        // Присвоить крайнему левому узлу, ссылки на правого и левого потомка удаляемого узла.         
        //        leftmost.Left = current.Left;
        //        leftmost.Right = current.Right;

        //        if (current.Parent == null)
        //        {
        //            Root = leftmost;

        //            if (Root != null)
        //            {
        //                Root.Parent = null;
        //            }
        //        }
        //        else
        //        {
        //            int result = current.Parent.CompareTo(current.Value);

        //            if (result > 0)
        //            {
        //                // Если значение родительского узла больше значения удаляемого,                 
        //                // сделать крайнего левого потомка левым потомком родителя удаляемого узла.                 

        //                current.Parent.Left = leftmost;
        //            }
        //            else if (result < 0)
        //            {
        //                // Если значение родительского узла, меньше чем значение удаляемого,                 
        //                // сделать крайнего левого потомка, правым потомком родителя удаляемого узла.                 

        //                current.Parent.Right = leftmost;
        //            }
        //        }
        //    }

        //    if (treeToBalance != null)
        //    {
        //        treeToBalance.Balance();
        //    }

        //    else
        //    {
        //        if (Root != null)
        //        {
        //            Root.Balance();
        //        }
        //    }

        //    return true;
        //}
    }   
}
