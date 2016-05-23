using System;

namespace EPI.Searching
{
	/// <summary>
	/// Design an algorithm to find the k-th largest element in an array.
	/// Assume all elements are distinct
	/// </summary>
	public static class SearchKthLargest
	{
		/// <summary>
		/// Approaches:
		/// 1. Brute force: Iterate the array and store the k largest element seen so far O(n*k) time. bad. O(k) space.
		/// 2. Sort: We can sort the array first and then iterate to the find the k-th largest. O(nlogn) time, O(1) space.
		/// 2. Heap: We can use min-heap to keep k largest elements. O(nlogk) time but O(k) space.
		/// 3. Partition: Choose a random pivot p and partition the array such that all elements >p are to the left of p and
		/// all elements less than p are to the right of p. Now:
		/// If there are exactly k-1 elements >p: then p is the k-th largest.
		/// If there are more than k-1 elements >p, then k-th largest cannot be in the range less than equal to p. discard that partition.
		/// if there are less than k-1 elements >p, then k-th largest cannot be in the range more than equal tp p. discard that partition.
		/// O(n) time and O(1) space. Let's use this algorithm.
		/// </summary>
		public static int Search(int[] array, int k)
		{
			int left = 0;
			int right = array.Length - 1;
			Random rand = new Random();
			while (left <= right)
			{
				// generate a random pivot
				int pivot = rand.Next(left, right + 1 /* max value is not inclusive*/);
				int newPivot = PartitionAroundThePivot(array, left, right, pivot);

				if (newPivot == k - 1)
				{
					return array[newPivot];
				}
				else if (newPivot > k -1)
				{
					right = newPivot - 1; // kth largest element is in the left side of the partition
				}
				else
				{
					left = newPivot + 1; // k-th largest element is in the right side of the partition
				}
			}

			throw new IndexOutOfRangeException();
		}

		/// <summary>
		/// Partition array[left, right] around the array[pivot] value, V such that
		/// All elements > V, are to the left of the partition.
		/// All element < V, are to the right of the partition.
		/// Returns new partition index
		/// </summary>
		private static int PartitionAroundThePivot(int[] array, int left, int right, int pivot)
		{
			int partitionValue = array[pivot];
			int newPivot = left; // start the new pivot from the left
			Swap(array, pivot, right); // store the current pivot value in the right most index

			for (int i = left; i < right; i++)
			{
				if (array[i] > partitionValue)
				{
					Swap(array, i, newPivot);
					newPivot++;
				}
			}

			// now move the original pivot value to the new pivot index
			Swap(array, newPivot, right);

			return newPivot;
		}

		private static void Swap(int[] array, int pivot, int right)
		{
			// can also use XOR trick to swap instead of storing in a temp value
			int temp = array[pivot];
			array[pivot] = array[right];
			array[right] = temp;
		}
	}
}
