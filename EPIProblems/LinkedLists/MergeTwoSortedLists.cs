namespace EPI.LinkedLists
{
	/// <summary>
	/// Let L and F be singly LinkedLists holding numbers and the data in each linked list is sorted.
	/// Merge the two lists into a new linked list consisting of the nodes of L and F in which number are sorted.
	/// </summary>
	/// <remarks>Reuse the nodes of L and F. Use O(1) additional storage</remarks>
	public static class MergeTwoSortedLists
	{
		public static SingleLinkedList<int> Merge(SingleLinkedList<int> left, SingleLinkedList<int> right)
		{
			// start with a dummy node
			SingleLinkedList<int> result = new SingleLinkedList<int>();
			SingleLinkedListNode<int> resultCurrentNode = result.Head;

			// track current position of both lists
			SingleLinkedListNode<int> leftCurrentNode = (left == null) ? null : left.Head;
			SingleLinkedListNode<int> rightCurrentNode = (right == null) ? null : right.Head;

			// iterate until we reach the end of both lists
			while (leftCurrentNode != null || rightCurrentNode != null)
			{
				if (leftCurrentNode == null)
				{
					// remaining nodes are all sorted in the right list
					resultCurrentNode.Next = rightCurrentNode;
					break;
				}
				else if (rightCurrentNode == null)
				{
					// remaining nodes are all sorted in the left list
					resultCurrentNode.Next = leftCurrentNode;
					break;
				}
				else if (leftCurrentNode.Data <= rightCurrentNode.Data)
				{
					// left list's current node  data is smaller
					resultCurrentNode.Next = leftCurrentNode;
					resultCurrentNode = resultCurrentNode.Next;

					leftCurrentNode = leftCurrentNode.Next;
				}
				else
				{
					resultCurrentNode.Next = rightCurrentNode;
					resultCurrentNode = resultCurrentNode.Next;
					rightCurrentNode = rightCurrentNode.Next;
				}
			}
			return result.Head.Next == null ? null : new SingleLinkedList<int>(result.Head.Next);
		}
	}
}
