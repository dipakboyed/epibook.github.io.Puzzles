using System;
using EPI.StacksAndQueues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.StacksAndQueues
{
	[TestClass]
	public class CircularQueueUnitTest
	{
		[TestMethod]
		public void CircularQueueTest()
		{
			CircularQueue<char> circularQueue = new CircularQueue<char>(5);
			circularQueue.Enqueue('A');
			circularQueue.Enqueue('B');
			circularQueue.Enqueue('C');
			circularQueue.Enqueue('D');
			circularQueue.Enqueue('E');
			circularQueue.Size.Should().Be(5);
			circularQueue.Dequeue().Should().Be('A');
			circularQueue.Size.Should().Be(4);
			circularQueue.Enqueue('F');
			circularQueue.Size.Should().Be(5);
			circularQueue.Dequeue().Should().Be('B');
			circularQueue.Dequeue().Should().Be('C');
			circularQueue.Dequeue().Should().Be('D');
			circularQueue.Dequeue().Should().Be('E');
			circularQueue.Dequeue().Should().Be('F');
			circularQueue.Size.Should().Be(0);

			Action action = () =>
			{
				circularQueue.Dequeue();
			};
			action.ShouldThrow<InvalidOperationException>();

			//resize
			circularQueue.Enqueue('A');
			circularQueue.Enqueue('B');
			circularQueue.Enqueue('C');
			circularQueue.Enqueue('D');
			circularQueue.Enqueue('E');
			circularQueue.Dequeue();
			circularQueue.Enqueue('F');
			circularQueue.Enqueue('G');
			circularQueue.Enqueue('H');
			circularQueue.Enqueue('I');
			circularQueue.Enqueue('J');
			circularQueue.Size.Should().Be(9);
		}
	}
}
