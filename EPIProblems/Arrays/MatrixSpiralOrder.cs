using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.Arrays
{
	public static class MatrixSpiralOrder
	{
		public static List<int> WriteSpiralOrder(int[,] matrix)
		{
			List<int> result = new List<int>();
			int length = matrix.GetLength(0);
			if (length < 1 || length != matrix.GetLength(1))
			{
				throw new ArgumentException("Invalid input");
			}

			for (int i = 0; i < length / 2; i++)
			{
				for (int j = i; j < length - 1 - i; j++)
				{
					result.Add(matrix[i, j]);
				}

				for (int k = i; k < length - 1 - i; k++)
				{
					result.Add(matrix[k, length - 1 - i]);
				}

				for (int j = length - 1 - i; j > i; j--)
				{
					result.Add(matrix[length -1 - i, j]);
				}

				for (int k = length -1 - i; k > i; k--)
				{
					result.Add(matrix[k, i]);
				}
			}

			if (length % 2 != 0)
			{
				result.Add(matrix[length / 2, length / 2]);
			}

			return result;
		}
	}
}
