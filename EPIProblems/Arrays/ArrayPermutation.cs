using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.Arrays
{
	/// <summary>
	/// Given an array of n elements and a permutation P, apply P to A
	/// using only constant storage.
	/// Retunr the result in the original array itself
	/// </summary>
	/// <example> Permutation [3,2,1,0] on [a,b,c,d] will result in [d,c,b,a]</example>
	public static class ArrayPermutation<T>
	{
		public static void ApplyPermutation(List<T> array, List<int> permutation) 
		{
			int size = permutation.Count;
			// iterate each element in the array
			for(int i = 0; i < array.Count; i++)
			{
				// if permutation has already been applied to the current position, it's Permutation value will be < 0
				if (permutation[i] >= 0)
				{
					// keep shifting until the cycle is broken
					int currentIndex = i;
					T tempValue = array[currentIndex];
					do
					{
						int nextIndex = permutation[currentIndex];
						T nextValue = array[nextIndex];
						array[nextIndex] = tempValue;

						// mark as visited
						permutation[currentIndex] -= size;

						currentIndex = nextIndex;
						tempValue = nextValue;
					}
					while (currentIndex != i);
				}
			}

			// restore permutation (if we want to keep all input values unchanged)
			for(int i = 0; i < permutation.Count; i++)
			{
				permutation[i] += size;
			}
		}
	}
}
