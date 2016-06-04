namespace EPI.Sorting
{
	/// <summary>
	/// Write a function that takes two input sorted arrays and updates the first to the combined
	/// entries of the two arrays in sorted order.
	/// Assume the first array has enough empty entries at the end to hold the final result
	/// </summary>
	/// <example>
	/// {5,13,17, , , , , } and {3,7,11,19} updates the first array to {3,5,7,11,13,19, }
	/// </example>
	public static class InPlaceMergeSort
	{
		public static void Sort(int?[] A, int?[] B)
		{
			// calculate non-empty entries in A
			// empty entries are denoted as null
			int i = 0;
			while (A[i] != null)
			{
				i++;
			}
			int j = B.Length;
			int writeIndex = i + j - 1;
			--i;
			--j;
			while (i >= 0 && j >= 0)
			{
				if(A[i] > B[j])
				{
					A[writeIndex--] = A[i--];
				}
				else
				{
					A[writeIndex--] = B[j--];
				}
			}

			// if A has remaining items, they are already sorted in the right place
			// add any remaining items in B
			while (j >= 0)
			{
				A[writeIndex--] = B[j--];
			}
		}
	}
}
