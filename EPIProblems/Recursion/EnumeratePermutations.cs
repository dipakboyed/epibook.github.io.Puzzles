using System;
using System.Collections.Generic;

namespace EPI.Recursion
{
	/// <summary>
	/// Enumerate all possible permutations of an array with distinct elements
	/// </summary>
	/// <example>
	/// {1,2,3} results in { {1,2,3}, {1,3,2}, {2,1,3}, {2,3,1}, {3,1,2}, {3,2,1} }
	/// </example>
	public static class EnumeratePermutations
	{
		public static List<int[]> ListAllPermutations(int[] array)
		{
			List<int[]> result = new List<int[]>();
			List<int> currentSet = new List<int>();
			PermutationHelper(array, 0, currentSet, result);
			return result;
		}

		private static void PermutationHelper(int[] array, int index, List<int> currentSet, List<int[]> result)
		{
			// base case: if we've reached the end of the array, add current set to result list
			if (index == array.Length)
			{
				result.Add(currentSet.ToArray());
			}
			else
			{
				for (int i = index; i < array.Length; i++)
				{
					int[] newArray = Swap(array, index, i);
					List<int> newSet = new List<int>(currentSet);
					newSet.Add(newArray[index]);
					PermutationHelper(newArray, index + 1, newSet, result);
				}
			}
		}

		private static int[] Swap(int[] array, int from, int to)
		{
			int[] result = new int[array.Length];
			array.CopyTo(result, 0);
			if (from != to)
			{
				int temp = result[from];
				result[from] = result[to];
				result[to] = temp;
			}
			return result;
		}


		/// <summary>
		/// Enumerate all permutations of a specific size
		/// </summary>
		/// <example>
		/// size 1 for {1,2,3} results in { {1}, {2}, {3} }
		/// size 2 for {1,2,3} results in { {1,2}, {1,3}, {2,1}, {2,3}, {3,1}, {3,2} }
		/// size 3 for {1,2,3} results in { {1,2,3}, {1,3,2}, {2,1,3}, {2,3,1}, {3,1,2}, {3,2,1} }
		/// </example>
		public static List<int[]> ListAllPermutationsOfSizeK(int[] array, int k)
		{
			if ( k <= 0 || k > array.Length)
			{
				throw new ArgumentException("k must be within the range of array length");
			}

			List<int[]> result = new List<int[]>();
			List<int> currentSet = new List<int>();
			PermutationKHelper(array, k, 0, currentSet, result);
			return result;
		}

		private static void PermutationKHelper(int[] array, int k, int index, List<int> currentSet, List<int[]> result)
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
					int[] newArray = Swap(array, index, i);
					List<int> newSet = new List<int>(currentSet);
					newSet.Add(newArray[index]);
					PermutationKHelper(newArray, k, index + 1, newSet, result);
				}
			}
		}
	}
}
