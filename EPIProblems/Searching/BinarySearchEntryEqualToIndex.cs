namespace EPI.Searching
{
	/// <summary>
	/// Assume you have a sorted array, A of distinct integers, return an index i such that A[i] == i
	/// </summary>
	public static class BinarySearchEntryEqualToIndex
	{
		public static int SearchEntryEqualToItsIndex(int[] sortedArrayWithDistinctValues)
		{
			int left = 0;
			int right = sortedArrayWithDistinctValues.Length - 1;
			while (left <= right)
			{
				int mid = left + (right - left)/2;
				int delta = sortedArrayWithDistinctValues[mid] - mid;
				if (delta == 0) // A[i] == i
				{
					return mid;
				}
				else if (delta > 0) // A[i] > i
				{
					right = mid - 1;
				}
				else // A[i] < i
				{
					left = mid + 1;
				}
			}
			return -1;
		}
	}
}
