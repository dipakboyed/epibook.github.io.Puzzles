using EPI.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.LinkedLists
{
	[TestClass]
	public class MergeTwoSortedListsUnitTest
	{
		[TestMethod]
		public void MergeSortedLists()
		{
			SingleLinkedList<int> L = new SingleLinkedList<int>(new SingleLinkedListNode<int>(2, new SingleLinkedListNode<int>(5, new SingleLinkedListNode<int>(7, null))));
			SingleLinkedList<int> R = new SingleLinkedList<int>(new SingleLinkedListNode<int>(3, new SingleLinkedListNode<int>(11, null)));

			MergeTwoSortedLists.Merge(null, null).Should().BeNull();
			MergeTwoSortedLists.Merge(L, null).ToList().Should().ContainInOrder(2, 5, 7);
			MergeTwoSortedLists.Merge(null, R).ToList().Should().ContainInOrder(3, 11);
			MergeTwoSortedLists.Merge(L, R).ToList().Should().ContainInOrder(2, 3, 5, 7, 11);
		}
	}
}
