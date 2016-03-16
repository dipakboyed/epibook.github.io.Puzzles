namespace EPI.LinkedLists
{
	/// <summary>
	/// Let L be singly LinkedList holding numbers.
	/// Reverse the nodes in the list
	/// </summary>
	/// <remarks>Reuse the nodes of L. Provide an O(n) time solution</remarks>
	public static class ReverseLinkedList
	{
		public static SingleLinkedList<int> Reverse(SingleLinkedList<int> linkedList)
		{
			if (linkedList  == null)
			{
				return null;
			}

			SingleLinkedListNode<int> previous = null;
			SingleLinkedListNode<int> current = linkedList.Head;

			while (current != null)
			{
				SingleLinkedListNode<int> next = current.Next;
				current.Next = previous;
				previous = current;
				current = next;
			}

			return previous == null ? null : new SingleLinkedList<int>(previous);
		}

		/// <summary>
		/// Recursive solution. But uses O(n) space in the stac as the implementation is nt
		/// tail recursive
		/// </summary>
		public static SingleLinkedList<int> ReverseRecursively(SingleLinkedList<int> linkedList)
		{
			if (linkedList == null)
			{
				return null;
			}
			var result = ReverseRecursivelyHelper(linkedList.Head);
			return result == null ? null : new SingleLinkedList<int>(result);
		}

		private static SingleLinkedListNode<int> ReverseRecursivelyHelper(SingleLinkedListNode<int> head)
		{
			if (head == null || head.Next == null)
			{
				return head;
			}

			// 2 <- 5 -> null
			SingleLinkedListNode<int> newHead = ReverseRecursivelyHelper(head.Next);
			head.Next.Next = head;
			head.Next = null;

			return newHead;
		}
	}
}
