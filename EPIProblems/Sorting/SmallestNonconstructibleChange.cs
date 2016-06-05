namespace EPI.Sorting
{
	/// <summary>
	/// Write a function which takes an array of positive integers and returns the smallest
	/// number which is not the sum of a subset of elements in the array
	/// </summary>
	/// <example>
	/// You have an array of coins {1,1,1,1,1,5,10,25}
	/// The smallest amount of change that is not possible to construct from this array is 21
	/// </example>
	public static class SmallestNonconstructibleChange
	{
		public static int FindSmallestNonconstructibleChange(int[] array)
		{
			// sort the array
			QuickSort<int>.Sort(array);

			// Let S be the sum of all the elements in the array
			// we definitely cannot create a change for S+1

			// apply this same rule iteratively by comparing the next sorted
			// element against the sum of all elements so far (Si + 1)
			// If next sorted element An is > Sum(A[0..n-1]), then we found our answer
			int sumOfChange = 0;
			foreach (int item in array)
			{
				if (item > sumOfChange + 1)
				{
					break;
				}
				sumOfChange += item;
			}
			return sumOfChange + 1;
		}
	}
}
