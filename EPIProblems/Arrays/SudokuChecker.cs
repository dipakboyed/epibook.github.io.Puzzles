using System;
using System.Linq;

namespace EPI.Arrays
{
	/// <summary>
	/// Check whether an n xn 2D array representing a partially completed Sudoku is valid.
	/// specifically check that no row, column or sqrt(n) X sqrt(n) 2D subarray contains duplicates.
	/// A 0 value in the 2D array indicates blank, every other entry is in [1,n]
	/// </summary>
	public static class SudokuChecker
	{
		public static bool IsValidSudoku(int[,] sudokuBoard)
		{
			int length = sudokuBoard.GetLength(0);

			for (int i = 0; i < length; i++)
			{
				if (HasDuplicates(i, i + 1, 0, length, sudokuBoard, length))
				{
					return false;
				}
			}

			for (int j = 0; j < length; j++)
			{
				if (HasDuplicates(0, length, j, j + 1, sudokuBoard, length))
				{
					return false;
				}
			}

			int subArrayLength = (int)Math.Sqrt(length);
			for (int i = 0; i < subArrayLength; i++)
			{
				for (int j = 0; j < subArrayLength; j++)
				{
					if (HasDuplicates(
						i * subArrayLength,
						(i * subArrayLength) + subArrayLength,
						j * subArrayLength,
						(j * subArrayLength) + subArrayLength,
						sudokuBoard,
						length))
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool HasDuplicates(int startRow, int endRow, int startCol, int endCol, int[,] sudokuBoard, int entryCount)
		{
			bool[] entryFound = Enumerable.Repeat(false, entryCount + 1).ToArray();
			for (int i = startRow; i < endRow; i++)
			{
				for (int j = startCol; j < endCol; j++)
				{
					int value = sudokuBoard[i, j];
					if (value != 0 && entryFound[value])
					{
						return true;
					}

					entryFound[value] = true;
				}
			}
			return false;
		}
	}
}
