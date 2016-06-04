using System;
using System.Collections.Generic;

namespace EPI.Sorting
{
	/// <summary>
	/// Given two sorted arrays, return a new array containing elements common to the two arrays.
	/// Assume the imput arrays are free of duplicates and the new array should be free of duplicates too
	/// </summary>
	public static class IntersectSortedArrays<T> where T: IComparable
	{
		public static T[] IntersectionOfTwoSortedArrays(T[] A, T[] B)
		{
			List<T> result = new List<T>();
			int i = 0;
			int j = 0;
			while (i < A.Length && j < B.Length)
			{
				int comparison = A[i].CompareTo(B[j]);
				if (comparison == 0)
				{
					result.Add(A[i]);
					++i;
					++j;
				}
				else if (comparison > 0) // A[i] > B[j]
				{
					++j;
				}
				else // A[i] < B[j]
				{
					++i;
				}
			}

			return result.ToArray();
		}
	}
}
