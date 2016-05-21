using System;

namespace EPI.Searching
{
	/// <summary>
	/// DEesign an algorithm that takes a sorted array whose length is unknown and a key and returns an index of an array
	/// element which matches the key. 
	/// Assume that an out of bounds access throws an exception
	/// </summary>
	public static class BinarySearchArrayOfUnknownLength
	{
		public static int Search(int[] arrayOfUnknownLength, int key)
		{
			// since we dont know the length, lets determine the upper bound for our search
			int i = 0;
			while (true)
			{
				int upperBoundIndex = (1 << i) - 1;
				try
				{
					if (arrayOfUnknownLength[upperBoundIndex] == key)
					{
						return upperBoundIndex;
					}

					if (arrayOfUnknownLength[upperBoundIndex] > key)
					{
						break; // we found our upper bound
					}
					++i;
				}
				catch (IndexOutOfRangeException)
				{
					// out of bounds, use last known upper bound
					break;
				}
			}

			// key was greater than index A[2^(i - 1)] but smaller than index A[2^(i) - 1]
			int left = 1 << (i - 1);
			int right = (1 << i) - 2;
			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				try
				{
					if (arrayOfUnknownLength[mid] == key)
					{
						return mid;
					}
					else if (arrayOfUnknownLength[mid] > key)
					{
						right = mid - 1;
					}
					else // A[mid] < key
					{
						left = mid + 1;
					}
				}
				catch (IndexOutOfRangeException)
				{
					right = mid - 1; // search the left part
				}
			}

			return -1;
		}
	}
}
