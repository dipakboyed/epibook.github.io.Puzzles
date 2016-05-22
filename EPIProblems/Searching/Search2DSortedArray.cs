 namespace EPI.Searching
{
	/// <summary>
	/// Design an algorithm that checks whether a number appears in a 2D sorted array or not.
	/// A 2D array is considered sorted if all rows and columns are sorted.
	/// </summary>
	public static class Search2DSortedArray
	{
		public static bool Search(int[,] array, int valueToSearch)
		{
			int row = array.GetLength(0) - 1;
			int column = 0;
			while (row >= 0 && column < array.GetLength(1))
			{
				if (array[row, column] == valueToSearch)
				{
					return true;
				}
				else if (array[row, column] < valueToSearch)
				{
					// value is not present in current column, increment column
					column++;
				}
				else
				{
					// value might be in current column, decrement row
					row--;
				}
			}

			return false;
		}
	}
}
