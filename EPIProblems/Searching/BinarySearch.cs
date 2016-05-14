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
			int low = 0;
			int high = sortedArray.Length - 1;
			while (low <= high)
			{
				int mid = low + (high - low)/2;
				if (sortedArray[mid] == valueToSearch)
				{
					return mid;
				}
				else if (sortedArray[mid] > valueToSearch)
				{
					high = mid - 1;
				}
				else // sortedArray[mid] < valueToSearch
				{
					low = mid + 1;
				}
			}
			return -1; // not found
		}

		/// <summary>
		/// Return the first occurence of the given key, k in the sorted array
		/// </summary>
		public static int SearchFirstOccurenceOfK(int k, int[] sortedArray)
		{
			int low = 0;
			int high = sortedArray.Length - 1;
			int result = -1;
			while (low <= high)
			{
				int mid = low + (high - low) / 2;
				if (sortedArray[mid] == k)
				{
					result = mid; // found an occurence of k
					// continue checking to the left for earlier occurences
					high = mid - 1;
				}
				else if (sortedArray[mid] > k)
				{
					high = mid - 1;
				}
				else // sortedArray[mid] < valueToSearch
				{
					low = mid + 1;
				}
			}
			return result;
		}
	}
}
