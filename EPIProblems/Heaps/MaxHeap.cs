using System;

namespace EPI.Heaps
{
	public class MaxHeap<T> where T : IComparable
	{
		int capacity;
		T[] array;
		int size;

		private MaxHeap() {}

		public MaxHeap(int cap)
		{
			capacity = cap;
			array = new T[capacity];
			size = 0;
		}

		public void Insert(T item)
		{
			if (size == capacity)
			{
				throw new InvalidOperationException("Heap is full, Pop elements before inserting");
			}
			array[size] = item;
			HeapifyUp();
			size++;
		}

		public T Pop()
		{
			if (size == 0)
			{
				throw new InvalidOperationException("Heap is empty");
			}
			// 1st element is the min, swap it with the last element
			Swap(array, 0, --size);
			HeapifyDown(0);
			return array[size];
		}

		private void HeapifyUp()
		{
			int current = size;
			int parent = (current + 1) / 2 - 1;
			while (parent >= 0)
			{
				int comparison = array[parent].CompareTo(array[current]);
				if (comparison >= 0) // A[parent] >= A[current]
				{
					break;
				}
				Swap(array, parent, current);
				current = parent;
				parent = (current + 1) / 2 - 1;
			}
		}

		private void HeapifyDown(int current)
		{
			int left = (2 * current) + 1;
			int right = (2 * current) + 2;
			int largest = current; //store the largest item b;ween the current and it's child

			if (left < size)
			{
				int leftComparison = array[left].CompareTo(array[largest]);
				if (leftComparison > 0)
				{
					largest = left;
				}
			}

			if (right < size)
			{
				int rightComparison = array[right].CompareTo(array[largest]);
				if (rightComparison > 0)
				{
					largest = right;
				}
			}

			if (largest != current)
			{
				Swap(array, largest, current);
				HeapifyDown(largest);
			}
		}

		private void Swap(T[] array, int a, int b)
		{
			if (a != b)
			{
				T temp = array[a];
				array[a] = array[b];
				array[b] = temp;
			}
		}


	}
}
