using System;
using EPI.StacksAndQueues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.StacksAndQueues
{
	[TestClass]
	public class StackBasedQueueUnitTest
	{
		[TestMethod]
		public void StackBasedQueueEnqueAndPeek()
		{
			StackBasedQueue<int> stackBasedQueue = new StackBasedQueue<int>();
			stackBasedQueue.Enqueue(1);
			stackBasedQueue.Enqueue(2);
			stackBasedQueue.Enqueue(3);
			stackBasedQueue.Enqueue(4);
			stackBasedQueue.Peek().Should().Be(1);
			//peek again and ensure we didnt dequeue
			stackBasedQueue.Peek().Should().Be(1);
		}

		[TestMethod]
		public void StackBasedQueueEnqueAndDequeAndPeek()
		{
			StackBasedQueue<int> stackBasedQueue = new StackBasedQueue<int>();
			stackBasedQueue.Enqueue(1);
			stackBasedQueue.Enqueue(2);
			stackBasedQueue.Enqueue(3);
			stackBasedQueue.Enqueue(4);

			stackBasedQueue.Dequeue().Should().Be(1);
			stackBasedQueue.Peek().Should().Be(2);

			stackBasedQueue.Dequeue().Should().Be(2);
			stackBasedQueue.Enqueue(5);
			stackBasedQueue.Enqueue(6);

			stackBasedQueue.Dequeue().Should().Be(3);
			stackBasedQueue.Dequeue().Should().Be(4);
			stackBasedQueue.Dequeue().Should().Be(5);
			stackBasedQueue.Dequeue().Should().Be(6);
			Action action = () => 
			{
				stackBasedQueue.Dequeue();
			};
			action.ShouldThrow<InvalidOperationException>();
		}

		[TestMethod]
		public void StackBasedQueueClear()
		{
			StackBasedQueue<int> stackBasedQueue = new StackBasedQueue<int>();
			stackBasedQueue.Enqueue(1);
			stackBasedQueue.Enqueue(2);
			stackBasedQueue.Clear();
			Action action = () =>
			{
				stackBasedQueue.Dequeue();
			};
			action.ShouldThrow<InvalidOperationException>();
		}
	}
}
