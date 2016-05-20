namespace EPI.Searching
{
	/// <summary>
	/// Implement binry searching for a given value in an already
	/// sorted array of integers.
	/// </summary>
	public static class BinarySearch
	{
		/// <summary>
		/// Vanilla binary search algorithm
		/// If found, return any of the possible matching index.
		/// Otherwise return -1.
		/// </summary>
		public static int Binary_Search(int valueToSearch, int[] sortedArray)
		{
			int left = 0;
			int right = sortedArray.Length - 1;
			while (left <= right)
			{
				int mid = left + (right - left)/2;
				if (sortedArray[mid] == valueToSearch)
				{
					return mid;
				}
				else if (sortedArray[mid] > valueToSearch)
				{
					right = mid - 1;
				}
				else // sortedArray[mid] < valueToSearch
				{
					left = mid + 1;
				}
			}
			return -1; // not found
		}

		/// <summary>
		/// Return the first occurence of the given key, k in the sorted array
		/// </summary>
		public static int SearchFirstOccurenceOfK(int k, int[] sortedArray)
		{
			int left = 0;
			int right = sortedArray.Length - 1;
			int result = -1;
			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				if (sortedArray[mid] == k)
				{
					result = mid; // found an occurence of k
					// continue checking to the left for earlier occurences
					right = mid - 1;
				}
				else if (sortedArray[mid] > k)
				{
					right = mid - 1;
				}
				else // sortedArray[mid] < valueToSearch
				{
					left = mid + 1;
				}
			}
			return result;
		}

		/// <summary>
		/// Return the first occurence of an element greater than the given key, k in the sorted array.
		/// If k is not present in the sorted array, return the first index larger than k.
		/// If all indices have value less than equal to k, return -1
		/// </summary>
		public static int SearchFirstValueLargerThanK(int k, int[] sortedArray)
		{
			int left = 0;
			int right = sortedArray.Length - 1;
			int result = -1;
			while (left <= right)
			{
				int mid = left + (right - left) / 2;
				if (sortedArray[mid] > k)
				{
					result = mid;
					right = mid - 1;
				}
				else // sortedArray[mid] <= valueToSearch
				{
					left = mid + 1;
				}
			}
			return result;
		}
	}
}
