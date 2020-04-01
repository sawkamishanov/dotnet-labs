using System.Linq;
using InitialTask.InsertionSort;
using NUnit.Framework;

namespace InitialTaskTest
{
    public class InsertionSortTest
    {
        [Test]
        public void SortTest()
        {
            Assert.IsTrue(InsertionSort.Sort(new[] {5, 7, 7, -5, 0, 1, 14, -11})
                .SequenceEqual(new[] {-11, -5, 0, 1, 5, 7, 7, 14}));
        }
    }
}