using System;

namespace EPI.Sorting
{
	/// Merge sort is one of the most popular sorting algorithms that has a time complexity of O(nlogn)
	/// But it is not an in-place sort (requires additional memory). It is a stable sorting algorithm though.
	/// It employs divide and conquer technique by recursing on smaller subarrays and merging the result
	public static class MergeSort<T> where T : IComparable
	{
		public static void Sort(T[] array)
		{
			MergeSortHelper(array, 0, array.Length - 1);
		}

		private static void MergeSortHelper(T[] array, int left, int right)
		{
			if (left < right)
			{
				// divide and conquer: similar to binary search divide the array into two parts
				// run sort on both independently
				int mid = left + (right - left) / 2;
				MergeSortHelper(array, left, mid);
				MergeSortHelper(array, mid + 1, right);

				//merge the two sorted subarrays
				Merge(array, left, mid, right);
			}
		}

		private static void Merge(T[] array, int left, int mid, int right)
		{
			T[] result = new T[right-left+1];
			// we want to merge the results of two subarrays A[left...mid] and A[mid+1...right]
			// iterate each and write the smaller value to a new result array
			int writeIndex = 0;
			int i = left;
			int j = mid + 1;
			while (i <= mid && j <= right)
			{
				int comparison = array[i].CompareTo(array[j]);
				if (comparison <= 0) //A[i] <= A[j]
				{
					result[writeIndex++] = array[i++];
				}
				else
				{
					result[writeIndex++] = array[j++];
				}
			}

			// one of the array might still have elements left
			while (i <= mid)
			{
				result[writeIndex++] = array[i++];
			}

			while(j <= right)
			{
				result[writeIndex++] = array[j++];
			}

			// copy the result into the original array
			for (int k = 0; k < writeIndex; k++)
			{
				array[left + k] = result[k];
			}
		}
	}
}
