using InitialTask.BinaryTree;
using NUnit.Framework;

namespace InitialTaskTest
{
    public class BinaryTreeTest
    {
        [Test]
        public void InsertMethodTest()
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(50);
            Assert.AreEqual(50, tree.Data);
            tree.Insert(84);
            Assert.AreEqual(84, tree.Right.Data);
            tree.Insert(66);
            tree.Insert(75);
            Assert.AreEqual(75, tree.Right.Left.Right.Data);
        }

        [Test]
        public void SearchMethodTest()
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(66);
            tree.Insert(45);
            tree.Insert(194);
            tree.Insert(23);
            tree.Insert(19);
            tree.Insert(104);
            tree.Insert(99);
            tree.Insert(16);
            tree.Insert(23);
            tree.Insert(88);
            
            Assert.AreEqual(16, tree.Search(16).Data);
        }

        [Test]
        public void RemoveMethodTest()
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(66);
            tree.Insert(45);
            tree.Insert(194);
            tree.Insert(23);
            tree.Insert(19);
            tree.Insert(104);
            tree.Insert(99);
            tree.Insert(16);
            tree.Insert(23);
            tree.Insert(88);
            
            Assert.AreEqual(194, tree.Search(194).Data);
            Assert.IsTrue(tree.Remove(194));
            Assert.IsNull(tree.Search(194));
        }
    }
}