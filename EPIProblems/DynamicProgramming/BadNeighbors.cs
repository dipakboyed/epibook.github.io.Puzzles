using System;
using System.Collections.Generic;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Every resident hates his next-door neighbors on both sides in a given town that has been arranged in a big circle around a well.
	/// Unfortunately, the town's well is in disrepair and needs to be restored. Each of the town's residents is willing to donate a certain amount 
	/// which is listed in clockwise order around the well. However, nobody is willing to contribute to a fund to which his neighbor
	/// has also contributed. 
	/// Next-door neighbors are always listed consecutively in donations, except that the first and last entries in donations are also for next-door neighbors.
	///  Find the maximum amount of donations that can be collected.
	/// </summary>
	public static class BadNeighbors
	{
		public static int FindMaxDonations(int[] donations)
		{
			List<int> l1 = new List<int>();
			List<int> l2 = new List<int>();
			int n = donations.Length;
			for (int i = 0; i < n; i++)
			{
				if (i == 0)
				{
					l1.Add(donations[i]);
				}
				else if (i == n - 1)
				{
					l2.Add(donations[i]);
				}
				else
				{
					l1.Add(donations[i]);
					l2.Add(donations[i]);
				}
			}
			return Math.Max(findMax(l1), findMax(l2));
		}

		private static int findMax(List<int> list)
		{
			if (list.Count == 1)
				return list[0];
			if (list.Count == 2)
				return Math.Max(list[0], list[1]);
			if (list.Count == 3)
				return Math.Max(list[0] + list[2], list[1]);
			int[] dp = new int[list.Count];
			dp[0] = list[0];
			dp[1] = Math.Max(list[0], list[1]);
			dp[2] = Math.Max(list[0] + list[2], list[1]);
			int i;
			for (i = 3; i < list.Count; i++)
			{
				dp[i] = Math.Max(list[i] + dp[i - 2], list[i - 1] + dp[i - 3]);
			}
			return dp[list.Count - 1];
		}
	}
}
