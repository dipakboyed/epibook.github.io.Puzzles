using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Count the number of ways to traverse a 2D array
	/// How many ways can you go from the top-left to the bottom-right in an n x m arrray?
	/// How would you count the number of ways in the presence of obstacles, specified by
	/// an n x m boolean 2D array B, where true represents an obstacle.
	/// </summary>
	public static class Number_Ways
	{
		/// <summary>
		/// Given the dimensons of A, n and m, return the number of ways from
		/// A[0][0] to A[n-1][m-1]
		/// </summary>
		/// <param name="n">row count</param>
		/// <param name="m">column count</param>
		/// <returns>Number of ways found</returns>
		public static int NumberOfWays(int n, int m)
		{
			if (n < m)
			{
				// swap n and m
				int temp = n;
				n = m;
				m = temp;
			}

			// initialize A[first row][0...m-1] with 1
			int[] A = Enumerable.Repeat(1, m).ToArray();
			for (int i = 1; i < n; i++)
			{
				int previous = 0;
				for (int j = 0; j < m; j++)
				{
					A[j] = A[j] + previous;
					previous = A[j];
				}
			}
			return A[m - 1];
		}

		/// <summary>
		/// Given the dimensons of A, n and m, and B return the number of ways from
		/// A[0][0] to A[n-1][m-1] considering obstacles
		/// </summary>
		/// <param name="n">row count</param>
		/// <param name="m">column count</param>
		/// <param name="B">obstacles represented as tre in 2D boolean array</param>
		/// <returns></returns>
		public static int NumberOfWaysWithObstacles(int n, int m, bool[,] B)
		{
			// initialize A[0..n-1][0...m-1] with 0
			int[,] A = new int[n, m];

			if (B[0, 0]) // No way to start from A[0,0] if B[0,0] == true
			{
				return 0;
			}

			A[0, 0] = 1;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (!B[i, j])
					{
						A[i, j] += (i < 1 ? 0 : A[i - 1, j]) + (j < 1 ? 0 : A[i, j - 1]);
					}
				}
			}
			return A[n - 1, m - 1];
		}
	}
}
