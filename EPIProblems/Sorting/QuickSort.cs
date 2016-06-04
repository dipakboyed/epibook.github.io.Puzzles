using System;

namespace EPI.Sorting
{
	/// <summary>
	/// Quick sort is one of the most popular sorting algorithms that on average has time complexity of O(nlogn)
	/// But in worst-case, it can perform O(n^2) [e.g. when array is already sorted, all elements are the same].
	/// It employs divide and conquer technique by partitioning the array around a pivot.
	/// </summary>
	public static class QuickSort<T> where T : IComparable
	{
		public static void Sort(T[] array)
		{
			QuickSortHelper(array, 0, array.Length - 1);
		}

		private static void QuickSortHelper(T[] array, int left, int right)
		{
			if (left < right)
			{
				int pivot = Partition(array, left, right);
				QuickSortHelper(array, left, pivot - 1);
				QuickSortHelper(array, pivot + 1, right);
			}
		}

		private static int Partition(T[] array, int left, int right)
		{
			T pivot = array[right]; // take the last element as pivot
			int i = left;
			// swap all elements <= the pivot from i onwards
			for (int j = i; j < right; j++)
			{
				int comparison = array[j].CompareTo(pivot);
				if (comparison <= 0) // array[j] <= pivot
				{
					Swap(array, i, j);
					i++;
				}
			}
			// everything <i has elements <= pivot, move the pivot to i
			// so that everything >i has elements > pivot.
			Swap(array, right, i);
			return i;
		}

		private static void Swap(T[] array, int i, int j)
		{
			if (i != j)
			{
				T temp = array[i];
				array[i] = array[j];
				array[j] = temp;
			}
		}
	}
}
