using System;

namespace EPI.Searching
{
	/// <summary>
	/// Given two sorted arrays and a positive integer k, find the 
	/// k-th smallest element in the array consisting of the union 
	/// of the two arrays.
	/// Assume duplicate elements can exist in the two arrays
	/// </summary>
	public static class BinarySearchInTwoSortedArrays
	{
		public static int SearchKthElement(int[] sortedArrayA, int[] sortedArrayB, int k)
		{
			// Assume in the union array of k smallest elements, x elements come from A, so k - x elements come from B.
			// Now the problem can be focused on finding that x value
			// Use binary search to find that x index in array A

			// set bounds to find x in A
			// if k > B's size, then best case (when all B's elements are < any A element), A's lower bound is k - B.size
			int left = Math.Max(0, k - sortedArrayB.Length); 
			// if k < A's size, then best case (when all A's element are < any B element), A's upper bound  is k
			int right = Math.Min(k, sortedArrayA.Length);

			// binary search to find x within [left, right] bounds
			while (left < right)
			{
				int x = left + (right - left) / 2;

				int A_x = (x >= sortedArrayA.Length) ? int.MaxValue : sortedArrayA[x];
				int A_x_1 = (x <= 0) ? int.MinValue : sortedArrayA[x - 1];
				int B_k_x = (k - x >= sortedArrayB.Length) ? int.MaxValue : sortedArrayB[k - x];
				int B_k_x_1 = (k - x <= 0) ? int.MinValue : sortedArrayB[k - x - 1];

				if (A_x < B_k_x_1) // next element in A is smaller than last element in B, increment lower bound
				{
					left = x + 1;
				}
				else if (A_x_1 > B_k_x) // mext element in B is smaller than last element in A, decrement upper bound
				{
					right = x - 1;
				}
				else
				{
					return Math.Max(A_x_1, B_k_x_1);
				}
			}

			int A_left_1 = (left <= 0) ? int.MinValue : sortedArrayA[left - 1];
			int B_k_left_1 = (k - left <= 0) ? int.MinValue : sortedArrayB[k - left - 1];
			return Math.Max(A_left_1, B_k_left_1);
		}
	}
}
