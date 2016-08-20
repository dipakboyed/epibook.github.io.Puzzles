using System;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// n-choose-k is n!/(k! * (n-k)!). It is the number of ways to choose k-elements subset from an n-element set.
	/// Design an efficient algorithm for computing n-Choose-k which never overflows if n-choose-k is less than int.Max
	/// </summary>
	// 
	public static class BinomialCoefficients
	{
		public static int ComputeNChooseK(int n, int k)
		{
			// (n choose k) = (n-1 choose k) + (n-1 choose k-1)
			// (5 choose 2) = 5!/2!*3! = (5*4)/2=10
			// (4 choose 2) = 4!/2!*2! = 6
			// (4 choose 1) = 4!/1!*3! = 4

			int[] result = Enumerable.Repeat(0, k + 1).ToArray();
			result[0] = 1; // (0 choose 0)

			// iterate i from 1 to n and store (i choose k) in result
			for (int i = 1; i <= n; i++)
			{
				// iterate j from k to 1 
				for (int j = Math.Min(k, i); j >= 1; j--)
				{
					result[j] = result[j] /* (n-1 choose k) */ + result[j - 1] /* (n-1 choose k-1) */;
				}

				result[0] = 1; // (i choose 0)
			}

			return result[k];
		}

	}
}
