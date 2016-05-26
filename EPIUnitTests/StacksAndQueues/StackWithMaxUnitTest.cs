using System;
using EPI.StacksAndQueues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.StacksAndQueues
{
	[TestClass]
	public class StackWithMaxUnitTest
	{
		[TestMethod]
		public void StackWithMaxTest()
		{
			StackWithMax<int> stack = new StackWithMax<int>();
			stack.Push(1);
			stack.Push(3);
			stack.Push(5);
			stack.Max().Should().Be(5);
			stack.Push(2);
			stack.Max().Should().Be(5);
			stack.Pop();
			stack.Max().Should().Be(5);
			stack.Pop();
			stack.Max().Should().Be(3);
			stack.Pop();

			stack.Peek().Should().Be(1);
			stack.Clear();
			Action action = () =>
			{
				stack.Max();
			};
			action.ShouldThrow<InvalidOperationException>();
		}
	}
}
