namespace EPI.Searching
{
	/// <summary>
	/// Design an O(logn) algorithm for finding the smallest element position in a
	/// cyclically sorted array.
	/// Build a solution that also works for non-distinct elements
	/// </summary>
	public static class BinarySearchCyclicSortedArray
	{
		public static int SearchSmallest(int[] cyclicSortedArray)
		{
			return SearchSmallestHelper(cyclicSortedArray, 0, cyclicSortedArray.Length - 1);
		}

		private static int SearchSmallestHelper(int[] cyclicSortedArray, int left, int right)
		{
			if (left == right)
			{
				return left;
			}

			int mid = left + (right - left) / 2;
			if (cyclicSortedArray[mid] > cyclicSortedArray[right])
			{
				// smallest element must be in array[mid+1, high]
				return SearchSmallestHelper(cyclicSortedArray, mid + 1, right);
			}
			else if (cyclicSortedArray[mid] < cyclicSortedArray[right])
			{
				// smallest element must be in array[low, mid]
				return SearchSmallestHelper(cyclicSortedArray, left, mid);
			}
			else
			{
				//array[mid] == array[high]
				// smallest element could be on either side
				int rightSideResult = SearchSmallestHelper(cyclicSortedArray, mid + 1, right);
				int leftSideResult = SearchSmallestHelper(cyclicSortedArray, left, mid);
				return cyclicSortedArray[leftSideResult] <= cyclicSortedArray[rightSideResult] ? leftSideResult : rightSideResult;
			}
		}
	}
}
