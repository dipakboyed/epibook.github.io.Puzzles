using System;
using System.Collections.Generic;

namespace EPI.Sorting
{
	/// <summary>
	/// Design an efficient algorithm for removing all duplicates from an array.
	/// It's ok for the final result to have the array elements not present in their original order
	/// </summary>
	/// <example>
	/// {1,2,6,6,0,0,-1} updates the array to {-1,0,1,2,6}
	/// </example>
	public static class RemoveDuplicates<T> where T: IComparable
	{
		public static void SortAndRemoveDuplicates(ref List<T> input)
		{
			T[] array = input.ToArray();
			QuickSort<T>.Sort(array);

			int writeIndex = 0;
			for (int i = 1; i < array.Length; i++)
			{
				int comparison = array[i].CompareTo(array[i - 1]);
				if (comparison != 0) // A[i] != A[i-1]
				{
					array[writeIndex++] = array[i - 1];
				}
				//if A[i] == A[i - 1], skip writing A[i-1]
			}
			array[writeIndex] = array[array.Length - 1];
			input = new List<T>();
			for (int i = 0; i <= writeIndex; i++)
			{
				input.Add(array[i]);
			}
		}
	}
}
