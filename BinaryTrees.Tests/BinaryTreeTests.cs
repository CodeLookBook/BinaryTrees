using NUnit.Framework;
using BinaryTrees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace BinaryTrees.Tests
{
    [TestFixture()]
    public class BinaryTreeTests
    {
        [Test()]
        public void InsertTest()
        {
            var tree = new Mock<IBinaryTree<BSTreeNode<int>, int>>();
            throw new NotImplementedException();
        }

        [Test()]
        public void SearchTest()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void RemoveTest()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void InOrderTraverseTest()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void PreOrderTraverseTest()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void PostOrderTraverseTest()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void MinTest()
        {
            throw new NotImplementedException();
        }

        [Test()]
        public void MaxTest()
        {
            throw new NotImplementedException();
        }
    }
}