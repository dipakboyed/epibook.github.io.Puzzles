using System;

namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes an array A og length n and an index i into A,
	/// and rearranges the elements such that all elements less than A[i] appear first,
	/// followed by elements equal to A[i], followed by elements greater than A[i]
	/// </summary>
	public static class DutchFlagPartition
	{
		public static void Partition(int[] array, int indexToPartition)
		{
			if (indexToPartition < 0 || indexToPartition >= array.Length)
			{
				throw new ArgumentException("indexToPartition must be valid");
			}

			// items between array[0, low - 1]				: denote items that are less than A[i]
			// items between array[low, medium - 1]			: denote items that are == A[i]
			// items between array[high + 1, A.Length - 1]	: denote items that are greater than A[i]
			// items between array[medium, high]			: denote unprocessed items
			int low = 0;
			int high = array.Length - 1;
			int medium = 0;

			int partitionValue = array[indexToPartition];
			// iterate until we have unprocessed items
			while (medium <= high)
			{
				if (array[medium] < partitionValue)
				{
					// Current item is less than partition pivot
					Swap(array, low++, medium++);
				}
				else if (array[medium] > partitionValue)
				{
					// Current item is greater than partition pivot
					Swap(array, medium, high--);
				}
				else
				{
					// Current item is == to partition pivot
					medium++;
				}
			}
		}

		private static void Swap(int[] array, int i, int j)
		{
			if (i != j && i >= 0 && j >= 0 && i < array.Length && j < array.Length)
			{
				int temp = array[i];
				array[i] = array[j];
				array[j] = temp;
			}
		}
	}
}
