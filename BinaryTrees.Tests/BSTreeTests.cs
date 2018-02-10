using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees.Tests
{
    [TestFixture]
    public class BSTreeTests
    {
        public BSTree<int>        IntTree         { get; set; } = new BSTree<int>();
        public BSTreeNode<int>    IntTreeRootNode { get; set; }

        public BSTree<string>     StrTree         { get; set; } = new BSTree<string>();
        public BSTreeNode<string> StrTreeRootNode { get; set; }

        [SetUp]
        public void BSTreeTest_SetUp()
        {
            // Init IntTree.
            {
                var type = typeof(BSTree<int>);
                var prop = type.GetProperty("RootNode", BindingFlags.Instance | BindingFlags.NonPublic);

                this.IntTree.Insert(11); // { 01 }
                this.IntTree.Insert(07); // { 02 }
                this.IntTree.Insert(15); // { 03 }
                this.IntTree.Insert(05); // { 04 }
                this.IntTree.Insert(03); // { 05 }
                this.IntTree.Insert(09); // { 06 }
                this.IntTree.Insert(08); // { 07 }
                this.IntTree.Insert(10); // { 08 }
                this.IntTree.Insert(13); // { 09 }
                this.IntTree.Insert(12); // { 10 }
                this.IntTree.Insert(14); // { 11 }
                this.IntTree.Insert(20); // { 12 }
                this.IntTree.Insert(18); // { 13 }
                this.IntTree.Insert(25); // { 14 }

                this.IntTreeRootNode = prop.GetValue(this.IntTree) as BSTreeNode<int>;
            }

            // Init StrTree.
            {
                var type = typeof(BSTree<string>);
                var prop = type.GetProperty("RootNode", BindingFlags.Instance | BindingFlags.NonPublic);

                this.StrTree.Insert("Must"  ); // { 01 }
                this.StrTree.Insert("Have"  ); // { 02 }
                this.StrTree.Insert("Should"); // { 03 }
                this.StrTree.Insert("Was"   ); // { 04 }
                this.StrTree.Insert("Did"   ); // { 05 }
                this.StrTree.Insert("Will"  ); // { 06 }
                this.StrTree.Insert("They"  ); // { 07 }
                this.StrTree.Insert("I"     ); // { 08 }
                this.StrTree.Insert("She"   ); // { 09 }
                this.StrTree.Insert("He"    ); // { 10 }

                this.StrTreeRootNode = prop.GetValue(this.StrTree) as BSTreeNode<string>;
            }
        }

        [Test]
        public void Insert_Key_BuildBinaryTreeStructure()
        {
            // ACT
            // ----------------------------------------------------------------

            // Root node.
            var node_11 = this.IntTreeRootNode;    // { 01 }

            // left side nodes.
            var node_7  = node_11.LeftNode; // { 02 }
            var node_5  = node_7.LeftNode ; // { 03 }
            var node_9  = node_7.RightNode; // { 04 }
            var node_3  = node_5.LeftNode ; // { 05 }
            var node_8  = node_9.LeftNode ; // { 06 }
            var node_10 = node_9.RightNode; // { 07 }

            // right side nodes.
            var node_15 = node_11.RightNode; // { 08 }
            var node_13 = node_15.LeftNode ; // { 09 }
            var node_20 = node_15.RightNode; // { 10 }
            var node_12 = node_13.LeftNode ; // { 11 }
            var node_14 = node_13.RightNode; // { 12 }

            var node_18 = node_20.LeftNode ; // { 13 }
            var node_25 = node_20.RightNode; // { 14 }

            // ASSERT
            // ----------------------------------------------------------------

            Assert.Multiple(() =>
            {
                Assert.That(node_11.Key, Is.EqualTo(11)); // { 01 }
                Assert.That(node_7.Key , Is.EqualTo(7 )); // { 02 }
                Assert.That(node_5.Key , Is.EqualTo(5 )); // { 03 }
                Assert.That(node_9.Key , Is.EqualTo(9 )); // { 04 }
                Assert.That(node_3.Key , Is.EqualTo(3 )); // { 05 }
                Assert.That(node_8.Key , Is.EqualTo(8 )); // { 06 }
                Assert.That(node_10.Key, Is.EqualTo(10)); // { 07 }
                Assert.That(node_15.Key, Is.EqualTo(15)); // { 08 }
                Assert.That(node_13.Key, Is.EqualTo(13)); // { 09 }
                Assert.That(node_20.Key, Is.EqualTo(20)); // { 10 }
                Assert.That(node_12.Key, Is.EqualTo(12)); // { 11 }
                Assert.That(node_14.Key, Is.EqualTo(14)); // { 12 }
                Assert.That(node_18.Key, Is.EqualTo(18)); // { 13 }
                Assert.That(node_25.Key, Is.EqualTo(25)); // { 14 }
            });
        }

        [Test]
        public void Insert_NullValueKey_ThrowArgumentNullException()
        {
            // ACT & ASSERT
            // ----------------------------------------------------------------

            Assert.That(
                () => this.StrTree.Insert(null),
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Search_ExcistingKey_ReturnTrue()
        {
            // ACT & ASSERT
            // ----------------------------------------------------------------

            Assert.Multiple(() =>
            {
                Assert.That(this.IntTree.Search(11), Is.True);
                Assert.That(this.IntTree.Search(07), Is.True);
                Assert.That(this.IntTree.Search(15), Is.True);
                Assert.That(this.IntTree.Search(05), Is.True);
                Assert.That(this.IntTree.Search(03), Is.True);
                Assert.That(this.IntTree.Search(09), Is.True);
                Assert.That(this.IntTree.Search(08), Is.True);
                Assert.That(this.IntTree.Search(10), Is.True);
                Assert.That(this.IntTree.Search(13), Is.True);
                Assert.That(this.IntTree.Search(12), Is.True);
                Assert.That(this.IntTree.Search(14), Is.True);
                Assert.That(this.IntTree.Search(20), Is.True);
                Assert.That(this.IntTree.Search(18), Is.True);
                Assert.That(this.IntTree.Search(25), Is.True);
            });
        }

        [Test]
        public void Search_NotExcistingKey_ReturnFalse()
        {
            // ACT & ASSERT
            // ----------------------------------------------------------------

            Assert.Multiple(() =>
            {
                Assert.That(this.IntTree.Search(-1), Is.False);
                Assert.That(this.IntTree.Search(00), Is.False);
                Assert.That(this.IntTree.Search(06), Is.False);
                Assert.That(this.IntTree.Search(17), Is.False);
                Assert.That(this.IntTree.Search(24), Is.False);
                Assert.That(this.IntTree.Search(26), Is.False);
            });
        }

        [Test]
        public void Search_NullValueKey_ThrowArgumentNullException()
        {
            // ACT & ASSERT
            // ----------------------------------------------------------------

            Assert.That(
                () => this.StrTree.Search(null), 
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Max_IfTreeIsNotNull_ReturnMaxKeyValue()
        {

            // ACT & ASSERT
            // ----------------------------------------------------------------

            Assert.That(this.IntTree.Max(), Is.EqualTo(25));
        }

        [Test]
        public void Max_IfTreeIsNull_ReturnMaxKeyValue()
        {

            // ACT & ASSERT
            // ----------------------------------------------------------------

            Assert.That(this.IntTree.Max(), Is.EqualTo(25));
        }

    }
}
