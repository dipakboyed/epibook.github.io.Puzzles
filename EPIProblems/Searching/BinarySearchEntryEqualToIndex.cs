using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.Searching
{
	/// <summary>
	/// Assume you have a sorted array, A of distinct integers, return an index i such that A[i] == i
	/// </summary>
	public static class BinarySearchEntryEqualToIndex
	{
		public static int SearchEntryEqualToItsIndex(int[] sortedArrayWithDistinctValues)
		{
			int low = 0;
			int high = sortedArrayWithDistinctValues.Length - 1;
			while (low <= high)
			{
				int mid = low + (high - low)/2;
				int delta = sortedArrayWithDistinctValues[mid] - mid;
				if (delta == 0) // A[i] == i
				{
					return mid;
				}
				else if (delta > 0) // A[i] > i
				{
					high = mid - 1;
				}
				else // A[i] < i
				{
					low = mid + 1;
				}
			}
			return -1;
		}
	}
}
