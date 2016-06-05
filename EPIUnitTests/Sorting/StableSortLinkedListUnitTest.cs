using EPI.LinkedLists;
using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class StableSortLinkedListUnitTest
	{
		[TestMethod]
		public void StableSortaLinkedList()
		{
			SingleLinkedList<int> list = new SingleLinkedList<int>()
			{
				Head = new SingleLinkedListNode<int>(5,
					new SingleLinkedListNode<int>(2,
						new SingleLinkedListNode<int>(3,
							new SingleLinkedListNode<int>(4, null))))
			};
			StableSortLinkedList.Sort(list).ShouldBeEquivalentTo(
				new SingleLinkedList<int>()
				{
					Head = new SingleLinkedListNode<int>(2,
						new SingleLinkedListNode<int>(3,
							new SingleLinkedListNode<int>(4,
								new SingleLinkedListNode<int>(5, null))))
				}
				);
		}
	}
}
