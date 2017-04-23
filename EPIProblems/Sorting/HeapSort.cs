using System;

namespace EPI.Sorting
{
	/// Heap sort is one of the most popular sorting algorithms that has a time complexity of O(nlogn)
	/// It is an in-place sort (doesn't requires additional memory). But it is not a stable sorting algorithm.
	/// It employs using a maxHeap.
	/// On an average, quickSort performs better but HeapSort guarantees a better worst case performance and lower memory usage
	public static class HeapSort<T> where T: IComparable
	{
		public static void Sort(T[] array)
		{
			int size = array.Length;
			// first iterate the array and ensure it satisfies the max heap criteria
			// largest element moves to the top
			BuildMaxHeap(array);

			// next pop top element by pushing it to the end of the array
			while(size> 0)
			{
				Swap(array, 0, --size);
				HeapifyDown(array, 0, size);
			}
		}

		private static void HeapifyDown(T[] array, int current, int size)
		{
			int left = 2 * current + 1;
			int right = 2 * current + 2;
			int largest = current;
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
				HeapifyDown(array, largest, size);
			}
		}

		private static void BuildMaxHeap(T[] array)
		{
			for (int i = array.Length - 1; i > 0; i--)
			{
				HeapifyUp(array, i);
			}
		}

		private static void HeapifyUp(T[] array, int current)
		{
			int parent = (current - 1) / 2;
			while (parent >= 0)
			{
				int comparison = array[parent].CompareTo(array[current]);
				if (comparison >= 0) //A[parent] >= A[current]
				{
					break;
				}
				Swap(array, parent, current);
				current = parent;
				parent = (current + 1) / 2 - 1;
			}
		}

		private static void Swap(T[] array, int a, int b)
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
