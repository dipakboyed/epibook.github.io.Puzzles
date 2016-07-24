using System;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given a list of N coins, their values (V1, V2, … , VN), and the total sum S. 
	/// Find the minimum number of coins the sum of which is S (we can use as many coins of one type as we want),
	/// or report that it’s not possible to select coins in such a way that they sum up to S.
	/// </summary>
	public static class CoinSum
	{
		public static int FindMinimumCoinsForSumN(int[] coins, int N)
		{
			// maintain a rolling sum of 0 to N values
			// initialize the sum to max int value
			int[] sum = Enumerable.Repeat(int.MaxValue, N + 1).ToArray();
			// base case: set sum 0 to 0
			sum[0] = 0;

			for (int i = 1; i <= N; i++) // now iterate sum[i] for i 1 to N
			{
				for (int j = 0; j < coins.Length; j++) // iterate each coin
				{
					if (coins[j] <= i)
					{
						sum[i] = Math.Min(sum[i], sum[i - coins[j]] + 1);
					}
				}
			}

			return sum[N];
		}
	}
}
