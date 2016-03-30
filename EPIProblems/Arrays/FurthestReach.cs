using System;

namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes an array of n integers, where A[i] denotes
	/// the maximum you can advance from index i, and returns whether it is possible
	/// to advance to the last index starting from the beginning of the array
	/// </summary>
	public static class FurthestReach
	{
		public static bool CanReachEnd(int[] array)
		{
			int furthestReach = 0;
			for (int i = 0; i <= furthestReach && furthestReach < array.Length - 1; i++)
			{
				furthestReach = Math.Max(furthestReach, i + array[i]);
			}

			return furthestReach >= array.Length - 1;
		}
	}
}
