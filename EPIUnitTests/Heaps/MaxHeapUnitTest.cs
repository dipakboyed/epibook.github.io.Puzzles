using System;
using EPI.Heaps;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Heaps
{
	[TestClass]
	public class MaxHeapUnitTest
	{
		[TestMethod]
		public void ValidateMaxHeap()
		{
			MaxHeap<int> MaxHeap = new MaxHeap<int>(10);
			MaxHeap.Insert(10);
			MaxHeap.Insert(100);
			MaxHeap.Insert(40);
			MaxHeap.Insert(30);
			MaxHeap.Insert(50);
			MaxHeap.Insert(20);
			MaxHeap.Insert(80);
			MaxHeap.Insert(70);
			MaxHeap.Insert(70);
			MaxHeap.Insert(60);

			Action action = () =>
			{
				MaxHeap.Insert(100);
			};
			action.ShouldThrow<InvalidOperationException>();

			MaxHeap.Pop().Should().Be(100);
			MaxHeap.Insert(0);
			MaxHeap.Pop().Should().Be(80);
			MaxHeap.Pop().Should().Be(70);
			MaxHeap.Pop().Should().Be(70);
			MaxHeap.Pop().Should().Be(60);
			MaxHeap.Pop().Should().Be(50);
			MaxHeap.Pop().Should().Be(40);
			MaxHeap.Pop().Should().Be(30);
			MaxHeap.Pop().Should().Be(20);
			MaxHeap.Pop().Should().Be(10);
			MaxHeap.Pop().Should().Be(0);
			Action actionPop = () =>
			{
				MaxHeap.Pop();
			};
			actionPop.ShouldThrow<InvalidOperationException>();
		}
	}
}
