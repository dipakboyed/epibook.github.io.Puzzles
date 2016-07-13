using System;
namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given an array A of n integers, find the interval indices a and b such that the
	/// sum of A[i] between a and b is maximized.
	/// </summary>
	public static class MaxSubarray
	{
		public static Tuple<int, int> FindMaximumSubarray(int[] array)
		{
			// result will return range i,j such that A[i...j-1] has the max sum
			// i is inclusive, j is not.
			// excluding j allows returning (k,k) to represent an empty subarray
			Tuple<int, int> result = new Tuple<int, int>(0, 0);
			int minIndex = -1, sum = 0, minSum = 0, maxSum = int.MinValue;
			for (int i = 0; i < array.Length; i++)
			{
				sum += array[i];
				if (sum < minSum)
				{
					minSum = sum;
					minIndex = i;
				}
				if (sum - minSum >= maxSum)
				{
					maxSum = sum - minSum;
					result = new Tuple<int, int>(minIndex + 1, i + 1);
				}
			}

			return result;
		}
	}
}
