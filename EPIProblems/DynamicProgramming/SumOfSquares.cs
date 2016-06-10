using System;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// For a given positive number n, find the minimum number of numbers whose squares sum up to n
	/// </summary>
	/// <example>
	/// (n=16) == 4^2 returns 1
	/// (n=17) == 4^2 + 1^2 returns 2
	/// (n=18) == 3^2 + 3^2 returns 2
	/// </example>
	public static class SumOfSquares
	{
		public static int MinimizeSumOfSquares(int n)
		{
			if (n < 0)
				return -1;

			// initialize results with int max
			int[] array = Enumerable.Repeat(Int32.MaxValue, n + 1).ToArray();
			// base case: 0 
			array[0] = 0;

			// iterate each number from 1 to n
			for (int i = 1; i <= n; i++)
			{
				// look for results less than current value
				// for any given j, where j*j == i, answer will be 1 + array[i-j*j]
				for (int j = 1; j * j <= i; j++)
				{
					array[i] = Math.Min(array[i], array[i - (j * j)] + 1);
				}
			}

			return array[n];
		}
	}
}
