using EPI.Graphs.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Graphs.Algorithms
{
    [TestClass]
	public class MinHeapWithDecreaseKeyUnitTest
	{

		[TestMethod]
        public void MinHeap()
        {
            MinHeapWithDecreaseKey heap = new MinHeapWithDecreaseKey(7);
            heap.Insert(0,0);
            heap.Insert(1,int.MaxValue);
            heap.Insert(2,10);
            heap.Insert(3,int.MaxValue);
            heap.Insert(4,2);
            heap.Insert(5,20);
            heap.Insert(6,55);
            Assert.AreEqual(7, heap.size);

            var r = heap.Pop();
            Assert.AreEqual(0, r.index);
            Assert.AreEqual(0, r.dist);
            Assert.AreEqual(6, heap.size);

            heap.DecreaseKey(1, 1);

            r = heap.Pop();
            Assert.AreEqual(1, r.index);
            Assert.AreEqual(1, r.dist);
            Assert.AreEqual(5, heap.size);

             r = heap.Pop();
            Assert.AreEqual(4, r.index);
            Assert.AreEqual(2, r.dist);
            Assert.AreEqual(4, heap.size);

            heap.DecreaseKey(2, 9);
            heap.DecreaseKey(3, 100);
            heap.DecreaseKey(6, 5);
            heap.DecreaseKey(5, 19);

             r = heap.Pop();
            Assert.AreEqual(6, r.index);
            Assert.AreEqual(5, r.dist);
            Assert.AreEqual(3, heap.size);
        }

    }
}