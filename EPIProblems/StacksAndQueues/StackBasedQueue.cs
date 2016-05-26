using System.Collections.Generic;

namespace EPI.StacksAndQueues
{
	/// <summary>
	/// Implement a queue based on a Stack library
	/// </summary>
	public class StackBasedQueue<T>
	{
		private Stack<T> stack1, stack2;

		public StackBasedQueue()
		{
			stack1 = new Stack<T>();
			stack2 = new Stack<T>();
		}

		public void Enqueue(T entry)
		{
			stack1.Push(entry);
		}

		public T Dequeue()
		{
			if (stack2.Count == 0)
			{
				// Transfer all element from first stack to the second
				// but in reverse order
				while (stack1.Count != 0)
				{
					stack2.Push(stack1.Pop());
				}
			}

			return stack2.Pop();
		}

		public T Peek()
		{
			if (stack2.Count == 0)
			{
				// Transfer all element from first stack to the second
				// but in reverse order
				while (stack1.Count != 0)
				{
					stack2.Push(stack1.Pop());
				}
			}

			return stack2.Peek();
		}

		public void	Clear()
		{
			stack1.Clear();
			stack2.Clear();
		}
	}
}
