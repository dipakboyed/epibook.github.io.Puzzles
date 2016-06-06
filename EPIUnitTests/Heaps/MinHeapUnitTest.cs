using System;
using EPI.Heaps;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Heaps
{
	[TestClass]
	public class MinHeapUnitTest
	{
		[TestMethod]
		public void ValidateMinHeap()
		{
			MinHeap<int> minHeap = new MinHeap<int>(10);
			minHeap.Insert(100);
			minHeap.Insert(10);
			minHeap.Insert(40);
			minHeap.Insert(30);
			minHeap.Insert(50);
			minHeap.Insert(20);
			minHeap.Insert(80);
			minHeap.Insert(70);
			minHeap.Insert(70);
			minHeap.Insert(60);

			Action action = () =>
			{
				minHeap.Insert(100);
			};
			action.ShouldThrow<InvalidOperationException>();

			minHeap.Pop().Should().Be(10);
			minHeap.Insert(0);
			minHeap.Pop().Should().Be(0);
			minHeap.Pop().Should().Be(20);
			minHeap.Pop().Should().Be(30);
			minHeap.Pop().Should().Be(40);
			minHeap.Pop().Should().Be(50);
			minHeap.Pop().Should().Be(60);
			minHeap.Pop().Should().Be(70);
			minHeap.Pop().Should().Be(70);
			minHeap.Pop().Should().Be(80);
			minHeap.Pop().Should().Be(100);
			Action actionPop = () =>
			{
				minHeap.Pop();
			};
			actionPop.ShouldThrow<InvalidOperationException>();
		}
	}
}
