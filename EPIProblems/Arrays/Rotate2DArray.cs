using System;

namespace EPI.Arrays
{
	/// <summary>
	/// Rotate an n x n 2D array by 90 degress clockwise.
	/// Assume that n= 2^k for k >0.
	/// </summary>
	public static class Rotate2DArray
	{
		public static void Rotate(int[,] matrix)
		{
			int length = matrix.GetLength(0);
			if (length < 1 || length != matrix.GetLength(1))
			{
				throw new ArgumentException("Invalid input");
			}

			for (int i = 0; i < length/2; i++)
			{
				for (int j = i; j < length - 1 - i; j++)
				{
					int temp = matrix[i, j];
					matrix[i, j] = matrix[length - 1 - j, i];
					matrix[length - 1 - j, i] = matrix[length - 1 - i, length - 1 - j];
					matrix[length - 1 - i, length - 1 - j] = matrix[j, length - 1 - i];
					matrix[j, length - 1 - i] = temp;
				}
			}
		}
	}
}
