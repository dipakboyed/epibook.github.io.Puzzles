using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.LinkedLists
{
	/// <summary>
	/// Return null if the given linked list does not have a cycle,
	/// otherwise return the reference to the start of the cycle
	/// </summary>
	public static class LinkedListIsCyclic
	{
		public static SingleLinkedListNode<int> HasCycle(SingleLinkedList<int> linkedList)
		{
			var slow = linkedList.Head;
			var fast = linkedList.Head.Next;
			while (slow != null && fast != null && fast.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;
				if (slow == fast)
				{
					return slow;
				}
			}

			return null;
		}
	}
}
