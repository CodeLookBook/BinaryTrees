using NUnit.Framework;
using BinaryTrees.Traversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Traversal.Tests
{
    [TestFixture()]
    public class PostOrderTraversalTests
    {
        public class TestNode<KeyT> : BinaryTreeNode<TestNode<KeyT>, KeyT> where KeyT : IComparable<KeyT>
        {
            public TestNode(KeyT key) : base(key)
            {
            }
            public TestNode(KeyT key, TestNode<KeyT> parent) : base(key, parent)
            {
            }
            public TestNode(KeyT key, TestNode<KeyT> parent, TestNode<KeyT> left, TestNode<KeyT> right) : base(key, parent, left, right)
            {
            }
        }

        static ITraversal<TestNode<int>, int> Traversal => new PostOrderTraversal<TestNode<int>, int>();

        static List<int> ExpectedLeftToRightTraversalResult { get; set; }
        static List<int> ExpectedRightToLeftTraversalResult { get; set; }

        static List<int> ActualLeftToRightTraversalResult { get; set; }
        static List<int> ActualRightToLeftTraversalResult { get; set; }

        [SetUp]
        public void SetUp()
        {
            ExpectedLeftToRightTraversalResult = new List<int> { 3, 6, 5, 8, 10, 9, 7, 12, 14, 13, 18, 25, 20, 15, 11 };
            ExpectedRightToLeftTraversalResult = new List<int> { 25, 18, 20, 14, 12, 13, 15, 10, 8, 9, 6, 3, 5, 7, 11 };
            ActualLeftToRightTraversalResult = new List<int>();
            ActualRightToLeftTraversalResult = new List<int>();
        }

        public static TestCaseData[] Traverse_Data_1 => new TestCaseData[]
        {
            new TestCaseData(CreateIntTreeRootNode(), new Action<int>((i) => ActualLeftToRightTraversalResult.Add(i)), TraversalMode.LeftToRight),
            new TestCaseData(null                   , new Action<int>((i) => ActualLeftToRightTraversalResult.Add(i)), TraversalMode.LeftToRight),
            new TestCaseData(CreateIntTreeRootNode(), null                                                           , TraversalMode.LeftToRight),
            new TestCaseData(null                   , null                                                           , TraversalMode.LeftToRight),

            new TestCaseData(CreateIntTreeRootNode(), new Action<int>((i) => ActualRightToLeftTraversalResult.Add(i)), TraversalMode.RightToLeft),
            new TestCaseData(null                   , new Action<int>((i) => ActualRightToLeftTraversalResult.Add(i)), TraversalMode.RightToLeft),
            new TestCaseData(CreateIntTreeRootNode(), null                                                           , TraversalMode.RightToLeft),
            new TestCaseData(null                   , null                                                           , TraversalMode.RightToLeft)
        };
        public static TestCaseData[] Traverse_Data_2 => new TestCaseData[]
        {
            new TestCaseData(CreateIntTreeRootNode(), TraversalMode.LeftToRight).Returns(
                new List<int> { 3, 6, 5, 8, 10, 9, 7, 12, 14, 13, 18, 25, 20, 15, 11 }),
            new TestCaseData(CreateIntTreeRootNode(), TraversalMode.RightToLeft).Returns(
                new List<int> { 25, 18, 20, 14, 12, 13, 15, 10, 8, 9, 6, 3, 5, 7, 11 }),
            new TestCaseData(null, TraversalMode.LeftToRight).Returns(new List<int>()),
            new TestCaseData(null, TraversalMode.RightToLeft).Returns(new List<int>()),
        };

        [Test, TestCaseSource("Traverse_Data_1")]
        public void Traverse(TestNode<int> root, Action<int> action, TraversalMode mode)
        {
            if (root != null && action != null && mode == TraversalMode.LeftToRight)
            {
                // Act
                Traversal.Traverse(root, action, mode);

                // Asset
                Assert.That(ActualLeftToRightTraversalResult, Is.EqualTo(ExpectedLeftToRightTraversalResult));
            }
            if (root != null && action != null && mode == TraversalMode.RightToLeft)
            {
                // Act
                Traversal.Traverse(root, action, mode);

                // Asset
                Assert.That(ActualRightToLeftTraversalResult, Is.EqualTo(ExpectedRightToLeftTraversalResult));
            }
            if (root != null && action == null)
            {
                // Arrang
                void TestTraversal() { Traversal.Traverse(root, action, mode); }

                // Act & Assert
                Assert.That(TestTraversal, Throws.TypeOf<ArgumentNullException>());
            }
            if (root == null && action != null)
            {
                // Act
                Traversal.Traverse(root, action, mode);

                // Asset
                Assert.That(ActualLeftToRightTraversalResult, Is.EqualTo(new List<int>()));
            }
            if (root == null && action == null)
            {
                // Act
                Traversal.Traverse(root, action, mode);

                // Asset
                Assert.That(ActualLeftToRightTraversalResult, Is.EqualTo(new List<int>()));
            }
        }

        [Test, TestCaseSource("Traverse_Data_2")]
        public IEnumerable<int> Traverse(TestNode<int> root, TraversalMode mode)
        {
            IEnumerable<int> collection = Traversal.Traverse(root, mode);

            return collection;
        }

        static TestNode<int> CreateIntTreeRootNode()
        {
            return new TestNode<int>
            (
                key   : 11,
                parent: null,
                left  : new TestNode<int>
                (
                    key   : 07,
                    parent: null,
                    left  : new TestNode<int>
                    (
                        key   : 05,
                        parent: null,
                        left  : new TestNode<int>(key: 03),
                        right : new TestNode<int>(key: 06)
                    ),
                    right: new TestNode<int>
                    (
                        key   : 09,
                        parent: null,
                        left  : new TestNode<int>(key: 08),
                        right : new TestNode<int>(key: 10)
                    )
                ),
                right: new TestNode<int>
                (
                    key   : 15,
                    parent: null,
                    left  : new TestNode<int>
                    (
                        key   : 13,
                        parent: null,
                        left  : new TestNode<int>(key: 12),
                        right : new TestNode<int>(key: 14)
                    ),
                    right : new TestNode<int>
                    (
                        key   : 20,
                        parent: null,
                        left  : new TestNode<int>(key: 18),
                        right : new TestNode<int>(key: 25)
                    )
                )
            );
        }
    }
}