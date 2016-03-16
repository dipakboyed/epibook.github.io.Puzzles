using System.Collections.Generic;

namespace EPI.LinkedLists
{
	/// <summary>
	/// The LinkedList generic class in .NET is a doubly linked list
	///  Use our own singly linked list object
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SingleLinkedList<T>
	{
		private SingleLinkedListNode<T> head;

		public SingleLinkedList()
		{
			head = new SingleLinkedListNode<T>();
		}

		public SingleLinkedList(SingleLinkedListNode<T> headNode)
		{
			head = headNode;
		}

		public SingleLinkedListNode<T> Head
		{
			get
			{
				return head;
			}
			set
			{
				head = value;
			}
		}

		public IList<T> ToList()
		{
			List<T> list = new List<T>();
			SingleLinkedListNode<T> node = Head;
			while (node != null)
			{
				list.Add(node.Data);
				node = node.Next;
			}
			return list;
		}
	}
}
