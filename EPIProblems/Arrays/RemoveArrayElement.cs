namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes as input an array A of integers and index k and updates A so that
	/// all occurences of k have been removed and the remaining elements shifted left in A.
	/// Return the number of remaining elements.
	/// </summary>
	/// <example>
	/// A= [5,3,7,11,2,3,13,5,7] and k=3, then A is updated to [5,7,11,2,13,5,7,0,0] and we return 7
	/// </example>
	public static class RemoveArrayElement
	{
		public static int RemoveElement(int[] array, int itemToRemove)
		{
			int writeIndex = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != itemToRemove)
				{
					array[writeIndex++] = array[i];
				}
			}

			// right-pad any remaining slots in the array to 0
			for (int i = writeIndex; i < array.Length; i++)
			{
				array[i] = 0;
			}
			return writeIndex;
		}
	}
}
