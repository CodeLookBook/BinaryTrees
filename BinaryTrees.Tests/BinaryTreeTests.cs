using NUnit.Framework;
using BinaryTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Reflection;

namespace BinaryTrees.Tests
{
    class TestTree<KeyT> : BinaryTree<TestNode<KeyT>, KeyT> where KeyT : IComparable <KeyT>
    {        
    }
    class TestNode<KeyT> : BinaryTreeNode<TestNode<KeyT>, KeyT> where KeyT : IComparable<KeyT> { }

    [TestFixture()]
    public class BinaryTreeTests
    {
        //    TestTree<int>    IntTree { get; set; }
        //    TestTree<string> StrTree { get; set; }

        //    [SetUp]
        //    public void SetUp()
        //    {
        //        this.IntTree = this.CreateTree<int>   (this.CreateIntTreeRootNode(), 15);
        //        this.StrTree = this.CreateTree<string>(this.CreateStrTreeRootNode(), 15);
        //    }

        //    public static TestCaseData[] SearchTest_IntData => new TestCaseData[]
        //    {
        //        new TestCaseData(11).Returns(true ),
        //        new TestCaseData(07).Returns(true ),
        //        new TestCaseData(15).Returns(true ),
        //        new TestCaseData(05).Returns(true ),
        //        new TestCaseData(03).Returns(true ),
        //        new TestCaseData(09).Returns(true ),
        //        new TestCaseData(08).Returns(true ),
        //        new TestCaseData(10).Returns(true ),
        //        new TestCaseData(13).Returns(true ),
        //        new TestCaseData(12).Returns(true ),
        //        new TestCaseData(14).Returns(true ),
        //        new TestCaseData(20).Returns(true ),
        //        new TestCaseData(18).Returns(true ),
        //        new TestCaseData(25).Returns(true ),
        //        new TestCaseData(-1).Returns(false),
        //        new TestCaseData(00).Returns(false),
        //        new TestCaseData(02).Returns(false),
        //        new TestCaseData(16).Returns(false),
        //        new TestCaseData(26).Returns(false),
        //    };
        //    public static TestCaseData[] SearchTest_StrData => new TestCaseData[]
        //    {
        //        new TestCaseData("K").Returns(true ),
        //        new TestCaseData("G").Returns(true ),
        //        new TestCaseData("O").Returns(true ),
        //        new TestCaseData("E").Returns(true ),
        //        new TestCaseData("C").Returns(true ),
        //        new TestCaseData("I").Returns(true ),
        //        new TestCaseData("H").Returns(true ),
        //        new TestCaseData("J").Returns(true ),
        //        new TestCaseData("M").Returns(true ),
        //        new TestCaseData("L").Returns(true ),
        //        new TestCaseData("N").Returns(true ),
        //        new TestCaseData("T").Returns(true ),
        //        new TestCaseData("R").Returns(true ),
        //        new TestCaseData("Y").Returns(true ),

        //        new TestCaseData("-").Returns(false),
        //        new TestCaseData("+").Returns(false),
        //        new TestCaseData("Ы").Returns(false),
        //        new TestCaseData("" ).Returns(false),
        //        new TestCaseData(" ").Returns(false),
        //        new TestCaseData("A").Returns(false),
        //        new TestCaseData("S").Returns(false),
        //        new TestCaseData("Z").Returns(false),

        //        new TestCaseData(null).Returns(false),
        //    };
        //    public static TestCaseData[] RemoveTest_IntData => new TestCaseData[]
        //    {
        //        // Remove tree Key values that doesn't exist.
        //        //new TestCaseData(-1),
        //        //new TestCaseData(00),
        //        //new TestCaseData(02),
        //        //new TestCaseData(16),
        //        //new TestCaseData(26),

        //        // Remove tree Key values that exist.
        //        new TestCaseData(11),
        //        new TestCaseData(07),
        //        new TestCaseData(15),
        //        new TestCaseData(05),
        //        new TestCaseData(03),
        //        new TestCaseData(09),
        //        new TestCaseData(08),
        //        new TestCaseData(10),
        //        new TestCaseData(13),
        //        new TestCaseData(12),
        //        new TestCaseData(14),
        //        new TestCaseData(20),
        //        new TestCaseData(18),
        //        new TestCaseData(25),            
        //    };
        //    public static TestCaseData[] RemoveTest_StrData => new TestCaseData[]
        //    {
        //        // Remove tree Key values that doesn't exist.
        //        new TestCaseData("-"),
        //        new TestCaseData("+"),
        //        new TestCaseData("Ы"),
        //        new TestCaseData("" ),
        //        new TestCaseData(" "),
        //        new TestCaseData("A"),
        //        new TestCaseData("S"),
        //        new TestCaseData("Z"),

        //        new TestCaseData(null),

        //        // Remove tree Key values that exist.
        //        new TestCaseData("K"),
        //        new TestCaseData("G"),
        //        new TestCaseData("O"),
        //        new TestCaseData("E"),
        //        new TestCaseData("C"),
        //        new TestCaseData("I"),
        //        new TestCaseData("H"),
        //        new TestCaseData("J"),
        //        new TestCaseData("M"),
        //        new TestCaseData("L"),
        //        new TestCaseData("N"),
        //        new TestCaseData("T"),
        //        new TestCaseData("R"),
        //        new TestCaseData("Y"),
        //    };

        //    [Test()]
        //    public void InsertTest()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    [Test(), TestCaseSource("SearchTest_IntData")]        
        //    public bool SearchTest(int    key)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    [Test(), TestCaseSource("SearchTest_StrData")]
        //    public bool SearchTest(string key)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    // Check: if key = null and key = -1
        //    [Test(), TestCaseSource("RemoveTest_IntData")]
        //    public void RemoveTest(int key)
        //    {
        //        // Arrange
        //        var oldNodesCount = this.IntTree.Count;

        //        // Act
        //        this.IntTree.Remove(key);
        //        var newNodesCount = this.IntTree.Count;

        //        // Assert
        //        Assert.That(oldNodesCount - 1, Is.EqualTo(newNodesCount));
        //    }

        //    [Test()]
        //    public void InOrderTraverseTest()
        //    {
        //        Assert.Fail();
        //    }

        //    [Test()]
        //    public void PreOrderTraverseTest()
        //    {
        //        Assert.Fail();
        //    }

        //    [Test()]
        //    public void PostOrderTraverseTest()
        //    {
        //        Assert.Fail();
        //    }

        //    [Test()]
        //    public void MinTest()
        //    {
        //        Assert.Fail();
        //    }

        //    [Test()]
        //    public void MaxTest()
        //    {
        //        Assert.Fail();
        //    }

        //    private TestNode<int>    CreateIntTreeRootNode()
        //    {
        //        return new TestNode<int>
        //        {
        //            Key  = 11,
        //            Left = new TestNode<int>
        //            {
        //                Key  = 7,
        //                Left = new TestNode<int>
        //                {
        //                    Key   = 5,
        //                    Left  = new TestNode<int> { Key = 3, },
        //                    Right = new TestNode<int> { Key = 6, }
        //                },
        //                Right = new TestNode<int>
        //                {
        //                    Key   = 9,
        //                    Left  = new TestNode<int> { Key = 8, },
        //                    Right = new TestNode<int> { Key = 10, }
        //                }
        //            },
        //            Right = new TestNode<int>
        //            {
        //                Key  = 15,
        //                Left = new TestNode<int>
        //                {
        //                    Key   = 13,
        //                    Left  = new TestNode<int> { Key = 12, },
        //                    Right = new TestNode<int> { Key = 14, }
        //                },
        //                Right = new TestNode<int>
        //                {
        //                    Key   = 20,
        //                    Left  = new TestNode<int> { Key = 18, },
        //                    Right = new TestNode<int> { Key = 25, }
        //                }
        //            }
        //        };
        //    }
        //    private TestNode<string> CreateStrTreeRootNode()
        //    {
        //        return new TestNode<string>
        //        {
        //            Key  = "K",
        //            Left = new TestNode<string>
        //            {
        //                Key  = "G",
        //                Left = new TestNode<string>
        //                {
        //                    Key   = "E",
        //                    Left  = new TestNode<string> { Key = "C", },
        //                    Right = new TestNode<string> { Key = "F", }
        //                },
        //                Right = new TestNode<string>
        //                {
        //                    Key   = "I",
        //                    Left  = new TestNode<string> { Key = "H", },
        //                    Right = new TestNode<string> { Key = "J", }
        //                }
        //            },
        //            Right = new TestNode<string>
        //            {
        //                Key = "O",
        //                Left = new TestNode<string>
        //                {
        //                    Key   = "M",
        //                    Left  = new TestNode<string> { Key = "L", },
        //                    Right = new TestNode<string> { Key = "N", }
        //                },
        //                Right = new TestNode<string>
        //                {
        //                    Key = "T",
        //                    Left  = new TestNode<string> { Key = "R", },
        //                    Right = new TestNode<string> { Key = "Y", }
        //                }
        //            }
        //        };
        //    }
        //    private TestTree<KeyT> CreateTree<KeyT>(TestNode<KeyT> rootNode, int countNode) where KeyT : IComparable<KeyT>
        //    {
        //        var tree = new TestTree<KeyT>();
        //        var type = typeof(TestTree<KeyT>);
        //        var root = type.GetProperty("RootNode", BindingFlags.Instance | BindingFlags.NonPublic);

        //        root.SetValue(tree, rootNode);

        //        var count = type.GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);

        //        count.SetValue(tree, countNode);

        //        return tree;
        //    }        
    }
}