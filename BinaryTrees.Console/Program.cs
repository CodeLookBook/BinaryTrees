using BinaryTrees.Traversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Console
{
    class Program
    {
        class TestNode<KeyT> : BinaryTreeNode<TestNode<KeyT>, KeyT> where KeyT : IComparable<KeyT> { }

        static void Main(string[] args)
        {
            TestNode<int> CreateIntTreeRootNode()
            {
                return new TestNode<int>
                {
                    Key = 11,
                    Left = new TestNode<int>
                    {
                        Key = 7,
                        Left = new TestNode<int>
                        {
                            Key = 5,
                            Left = new TestNode<int> { Key = 3, },
                            Right = new TestNode<int> { Key = 6, }
                        },
                        Right = new TestNode<int>
                        {
                            Key = 9,
                            Left = new TestNode<int> { Key = 8, },
                            Right = new TestNode<int> { Key = 10, }
                        }
                    },
                    Right = new TestNode<int>
                    {
                        Key = 15,
                        Left = new TestNode<int>
                        {
                            Key = 13,
                            Left = new TestNode<int> { Key = 12, },
                            Right = new TestNode<int> { Key = 14, }
                        },
                        Right = new TestNode<int>
                        {
                            Key = 20,
                            Left = new TestNode<int> { Key = 18, },
                            Right = new TestNode<int> { Key = 25, }
                        }
                    }
                };
            }

            //var tree = new BSTree<int>();

            //tree.Insert(10);

            //tree.Insert(08);
            //tree.Insert(07);
            //tree.Insert(09);
            //tree.Insert(05);
            //tree.Insert(06);
            //tree.Insert(04);

            //tree.Insert(18);
            //tree.Insert(17);
            //tree.Insert(19);
            //tree.Insert(15);
            //tree.Insert(16);
            //tree.Insert(14);

            //tree.InOrderTraverse(i => System.Console.WriteLine(i));           

            var root = CreateIntTreeRootNode();

            var inTraverser = new InOrderTraversal<TestNode<int>, int>();

            System.Console.WriteLine($"In order traversal Left to Right: ");
            inTraverser.Traverse(root, i => System.Console.Write($"{i} "), TraversalMode.LeftToRight);
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine($"In order traversal Right to Left: ");
            inTraverser.Traverse(root, i => System.Console.Write($"{i} "), TraversalMode.RightToLeft);
            System.Console.WriteLine();
            System.Console.WriteLine();

            var preTraverser = new PreOrderTraversal<TestNode<int>, int>();

            System.Console.WriteLine($"Pre order traversal Left to Right: ");
            preTraverser.Traverse(root, i => System.Console.Write($"{i} "), TraversalMode.LeftToRight);
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine($"Pre order traversal Right to Left: ");
            preTraverser.Traverse(root, i => System.Console.Write($"{i} "), TraversalMode.RightToLeft);
            System.Console.WriteLine();
            System.Console.WriteLine();

            var postTraverser = new PostOrderTraversal<TestNode<int>, int>();

            System.Console.WriteLine($"Post order traversal Left to Right: ");
            postTraverser.Traverse(root, i => System.Console.Write($"{i} "), TraversalMode.LeftToRight);
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine($"Post order traversal Right to Left: ");
            postTraverser.Traverse(root, i => System.Console.Write($"{i} "), TraversalMode.RightToLeft);
            System.Console.WriteLine();
            System.Console.WriteLine();


            System.Console.ReadKey();
        }
    }
}
