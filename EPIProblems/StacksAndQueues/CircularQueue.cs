using System;

namespace EPI.StacksAndQueues
{
	/// <summary>
	/// A queue can be implemented using an array and a beginning (head) and end (tail)
	/// indices. This data structure is often referred to as a circular queue.
	/// Implement a circular queue class containing a constructor that takes the capacity,
	/// enqueue, dequeue and size function and implements dynamic resizing.
	/// </summary>
	public class CircularQueue<T>
	{
		private T[] array;
		private int head;
		private int tail;
		private int size;
		private const int resizeFactor = 2;

		public CircularQueue(int capacity)
		{
			array = new T[capacity];
			head = 0;
			tail = 0;
			size = 0;
		}

		public int Size
		{
			get
			{
				return size;
			}
		}

		public void Enqueue(T item)
		{
			if (Size == array.Length)
			{
				// array capacity is full, resize
				T[] newArray = new T[array.Length * resizeFactor];
				for (int i = 0; i < Size; i++)
				{
					newArray[i] = array[(head + i) % array.Length];
				}
				head = 0;
				tail = Size;
				array = newArray;
			}
			array[tail] = item;
			tail = (tail + 1) % array.Length;
			++size;
		}

		public T Dequeue()
		{
			if (size <= 0)
			{
				throw new InvalidOperationException("Queue is empty");
			}
			// return the item at head and increment the head
			int currentHead = head;
			head = (head + 1) % array.Length;
			--size;
			return array[currentHead];
		}
	}
}
