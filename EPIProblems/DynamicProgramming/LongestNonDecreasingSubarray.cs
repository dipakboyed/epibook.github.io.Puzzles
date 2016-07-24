using System;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given a sequence of N numbers – A[1] , A[2] , …, A[N] .
	/// Find the length of the longest non-decreasing sequence.
	/// </summary>
	public static class LongestNonDecreasingSubarray
	{
		public static int FindLengthOfLongestNonDecreasingSubarray(int[] array)
		{
			int[] result = Enumerable.Repeat(1, array.Length).ToArray();

			for (int i = 1; i < array.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (array[j] <= array[i])
					{
						result[i] = Math.Max(result[i], result[j] + 1);
					}
				}
			}

			return result[array.Length - 1];
		}
	}
}
