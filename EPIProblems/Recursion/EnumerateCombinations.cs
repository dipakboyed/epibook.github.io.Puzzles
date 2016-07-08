using System;
using System.Collections.Generic;

namespace EPI.Recursion
{
	/// <summary>
	/// Enumerate all possible combinations of a subset of length k from an array with distinct elements.
	/// Order does not matter in the combinations.
	/// </summary>
	/// <example>
	/// size 1 for {1,2,3} results in { {1}, {2}, {3} }
	/// size 2 for {1,2,3} results in { {1,2}, {1,3}, {2,3} }
	/// size 3 for {1,2,3} results in { {1,2,3} }
	/// </example>
	public static class EnumerateCombinations
	{
		public static List<int[]> NChooseK(int[] array, int k)
		{
			if (k <= 0 || k > array.Length)
			{
				throw new ArgumentException("k must be within the range of array length");
			}

			List<int[]> result = new List<int[]>();
			List<int> currentSet = new List<int>();
			CombinationsHelper(array, k, 0, currentSet, result);
			return result;
		}

		private static void CombinationsHelper(int[] array, int k, int index, List<int> currentSet, List<int[]> result)
		{
			// base case: add current set to result when it's size is k
			if (k == currentSet.Count)
			{
				result.Add(currentSet.ToArray());
			}
			else
			{
				for (int i = index; i < array.Length; i++)
				{
					List<int> newSet = new List<int>(currentSet);
					newSet.Add(array[i]);
					CombinationsHelper(array, k, i + 1, newSet, result);
				}
			}
		}
	}
}
