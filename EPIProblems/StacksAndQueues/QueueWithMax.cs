using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.StacksAndQueues
{
	public class QueueWithMax<T> where T: IComparable
	{
		private StackWithMax<T> stack1, stack2;

		public QueueWithMax()
		{
			stack1 = new StackWithMax<T>();
			stack2 = new StackWithMax<T>();
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

		public void Clear()
		{
			stack1.Clear();
			stack2.Clear();
		}

		public T Max()
		{
			if (stack1.Count > 0)
			{
				if (stack2.Count > 0)
				{
					var comparison = stack1.Max().CompareTo(stack2.Max());
					if (comparison >= 0)
					{
						return stack1.Max();
					}
					else
					{
						return stack2.Max();
					}
				}
				else
				{
					return stack1.Max();
				}
			}
			else
			{
				return stack2.Max();
			}
		}
	}
}
