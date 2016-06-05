using EPI.LinkedLists;

namespace EPI.Sorting
{
	/// <summary>
	/// Implement a function which sorts linked list efficiently.
	/// It should be stable sort (i.e. relative position of equal elements is preserved)
	/// </summary>
	public static class StableSortLinkedList
	{
		public static SingleLinkedList<int> Sort(SingleLinkedList<int> list)
		{
			// Usually quick sort is the best for sorting arrays (avg. O(nlogn) runtime)
			// but it isnt a stable sorting algorithm.
			// Merge sort is stable but the default case does not do in-place sorting
			// For linked lists we can do merge sort in-place

			//recursion base case
			if ((list == null) || (list.Head == null) || (list.Head.Next == null))
			{
				return list;
			}

			// use slow and fast pointers to find the mid-point of the linked list
			SingleLinkedListNode<int> slow = list.Head;
			SingleLinkedListNode<int> fast = list.Head;
			SingleLinkedListNode<int> prevSlow = null;
			while (fast != null && fast.Next != null)
			{
				prevSlow = slow;
				slow = slow.Next;
				fast = fast.Next.Next;
			}

			//terminate first first prior to slow
			prevSlow.Next = null;

			list = MergeTwoSortedLists.Merge(
				Sort(new SingleLinkedList<int>() { Head = list.Head }),
				Sort(new SingleLinkedList<int>() { Head = slow }));
			return list;
		}
	}
}
