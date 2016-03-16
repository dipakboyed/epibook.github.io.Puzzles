using EPI.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.LinkedLists
{
	[TestClass]
	public class ReverseLinkedListUnitTest
	{
		[TestMethod]
		public void Reverse()
		{
			SingleLinkedList<int> L = new SingleLinkedList<int>(new SingleLinkedListNode<int>(1, new SingleLinkedListNode<int>(2, new SingleLinkedListNode<int>(3, null))));

			ReverseLinkedList.Reverse(null).Should().BeNull();
			ReverseLinkedList.Reverse(L).ToList().Should().ContainInOrder(3, 2, 1);

		}

		[TestMethod]
		public void ReverseRecursively()
		{
			SingleLinkedList<int> L = new SingleLinkedList<int>(new SingleLinkedListNode<int>(1, new SingleLinkedListNode<int>(2, new SingleLinkedListNode<int>(3, null))));

			ReverseLinkedList.ReverseRecursively(null).Should().BeNull();
			ReverseLinkedList.ReverseRecursively(L).ToList().Should().ContainInOrder(3, 2, 1);

		}
	}
}
