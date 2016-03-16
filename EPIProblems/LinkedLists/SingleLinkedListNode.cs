namespace EPI.LinkedLists
{
	/// <summary>
	/// Represents a node in a singly linked list
	/// Contains data and the next node
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SingleLinkedListNode<T>
	{
		#region private fields

		private T data;
		private SingleLinkedListNode<T> next;

		#endregion

		#region ctor

		public SingleLinkedListNode()
		{
			data = default(T);
			next = null;
		}

		public SingleLinkedListNode(T Data, SingleLinkedListNode<T> nextNode)
		{
			data = Data;
			next = nextNode;
		}

		#endregion

		#region public Accessors

		public T Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}

		public SingleLinkedListNode<T> Next
		{
			get
			{
				return next;
			}
			set
			{
				next = value;
			}
		}

		#endregion
	}
}
