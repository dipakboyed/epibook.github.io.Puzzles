using System;
using System.Collections.Generic;

namespace EPI.StacksAndQueues
{
	/// <summary>
	/// Design a stack that supports a max operation that returns the maximum value
	/// currently stored in the stack
	/// </summary>
	public class StackWithMax<T> where T : IComparable
	{
		private struct Pair<U> where U: IComparable
		{
			public U Entry;
			public int Count;
			public Pair(U entry, int count)
			{
				Entry = entry;
				Count = count;
			}
		};

		private Stack<T> stack;
		private Stack<Pair<T>> maxElementInStackWithCount;

		public StackWithMax()
		{
			stack = new Stack<T>();
			maxElementInStackWithCount = new Stack<Pair<T>>();
		}

		public void Push(T value)
		{
			stack.Push(value);
			if (maxElementInStackWithCount.Count == 0 /* is Empty */)
			{
				maxElementInStackWithCount.Push(new Pair<T>(value, 1));
			}
			else
			{
				var currentMaxElement = maxElementInStackWithCount.Peek();
				int comparison = value.CompareTo(currentMaxElement.Entry);
				if (comparison > 0 /* new value > current max*/)
				{
					maxElementInStackWithCount.Push(new Pair<T>(value, 1));
				}
				else if (comparison == 0) /* new value == current max */
				{
					maxElementInStackWithCount.Pop();
					maxElementInStackWithCount.Push(new Pair<T>(currentMaxElement.Entry, currentMaxElement.Count + 1));
				}
				else /* new value < current max */
				{
					// no need to update maxElement
				}
			}
		}

		public T Pop()
		{
			var currentMaxElement = maxElementInStackWithCount.Peek();
			if (currentMaxElement.Entry.Equals(stack.Peek()))
			{
				maxElementInStackWithCount.Pop();
				if (currentMaxElement.Count > 1)
				{
					maxElementInStackWithCount.Push(new Pair<T>(currentMaxElement.Entry, currentMaxElement.Count - 1));
				}
			}
			return stack.Pop();
		}

		public T Peek()
		{
			return stack.Peek();
		}

		public void Clear()
		{
			stack.Clear();
			maxElementInStackWithCount.Clear();
		}

		public T Max()
		{
			return maxElementInStackWithCount.Peek().Entry;
		}
	}
}
