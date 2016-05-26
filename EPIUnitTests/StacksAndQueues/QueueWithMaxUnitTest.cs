using System;
using EPI.StacksAndQueues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.StacksAndQueues
{
	[TestClass]
	public class QueueWithMaxUnitTest
	{
		[TestMethod]
		public void QueueWithMaxTest()
		{
			QueueWithMax<int> queue = new QueueWithMax<int>();
			queue.Enqueue(1);
			queue.Enqueue(3);
			queue.Enqueue(5);
			queue.Max().Should().Be(5);
			queue.Enqueue(2);
			queue.Max().Should().Be(5);
			queue.Dequeue();
			queue.Max().Should().Be(5);
			queue.Dequeue();
			queue.Dequeue();
			queue.Max().Should().Be(2);
			queue.Dequeue();

			queue.Enqueue(10);
			queue.Clear();
			Action action = () =>
			{
				queue.Max();
			};
			action.ShouldThrow<InvalidOperationException>();
		}
	}
}

