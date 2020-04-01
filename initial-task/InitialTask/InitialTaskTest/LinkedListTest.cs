using System;
using System.Linq;
using InitialTask.LinkedList;
using NUnit.Framework;

namespace InitialTaskTest
{
    public class LinkedListTest
    {
        [Test]
        public void SimpleTest()
        {
            CustomList<object> list = new CustomList<object>();
            
            Assert.AreEqual(0, list.GetSize);
            Assert.AreEqual(true, list.IsEmpty);
            Assert.Catch<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Test]
        public void AddMethodTest()
        {
            CustomList<string> list = new CustomList<string>();
            
            /* AddFirst */
            list.AddFirst("Первый");
            Assert.AreEqual("Первый", list.Get(0));
            
            /* AddLast */
            list.AddLast("Второй");
            Assert.AreEqual("Второй", list.Get(1));
            
            /* AddFirst */
            list.AddFirst("Снова первый");
            Assert.AreEqual("Снова первый", list.Get(0));
        }

        [Test]
        public void RemoveMethodTest()
        {
            CustomList<string> list = new CustomList<string>();
            
            /* AddFirst */
            list.AddFirst("Первый");
            Assert.AreEqual("Первый", list.Get(0));

            bool successRemove = list.Remove("Первый");
            bool unsuccessRemove = list.Remove("Второй");
            
            Assert.IsTrue(successRemove);
            Assert.IsFalse(unsuccessRemove);
        }

        [Test]
        public void ReverseMethodTest()
        {
            CustomList<int> list = new CustomList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            Console.Out.WriteLine(list.ToString());
            
            list.Reverse();
            
            Console.Out.WriteLine(list.ToString());
            
            Assert.IsTrue(list.ToString().Equals("5 4 3 2 1 "));
        }
    }
}