using System.Collections.Generic;

namespace EPI.GreedyAlgosAndInvariants
{
	/// <summary>
	/// Design an algorithm that takes as input an array A and a number t,
	/// and determines if A 3-creates t.
	/// Array A, k-creates-t if the sum of A[i] where i ranges from [0..k] equals t.
	/// The elements of A do not have to be distinct in this solution.
	/// </summary>
	public static class ThreeSumProblem
	{
		public static bool HasThreeSum(List<int>A, int t)
		{
			A.Sort(); // assume sorting function is available. (otherwise provide custom implementation e.g. quicksort)

			foreach(int a in A)
			{
				// Find if the sum of two numbers in A is t - a
				if (HasTwoSum(A, t - a))
				{
					return true;
				}
			}
			return false;
		}

		private static bool HasTwoSum(List<int> sortedA, int t)
		{
			int i = 0;
			int j = sortedA.Count - 1;

			while ( i<= j)
			{
				if (sortedA[i] + sortedA[j] == t)
				{
					return true;
				}
				else if (sortedA[i] + sortedA[j] < t)
				{
					++i;
				}
				else // sortedA[i] + sortedA[j] > t
				{
					--j;
				}
			}
			return false;
		}
	}
}
