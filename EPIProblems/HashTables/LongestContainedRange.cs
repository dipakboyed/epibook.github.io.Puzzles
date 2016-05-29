using System;
using System.Collections.Generic;
using System.Linq;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function that takes an array of integers and returns the largest subset of integers
	/// in the array having the property that if two integers are in the subset, then so are all the integers
	/// between them.
	/// </summary>
	/// <example> 
	/// For {3,-2,7,9,8,1,2,0,-1,5,8}, the largest subset of contiguous numbers is {-2,-1,0,1,2,3} whose length is 6.
	/// Returns {-2,3}.
	/// </example>
	public static class LongestContainedRange
	{
		public static Tuple<int, int> FindLongestContainedRange(int[] array)
		{
			Tuple<int, int> longestRangeSoFar = new Tuple<int, int>(0, -1);
			HashSet<int> numbers = new HashSet<int>();
			// hash all distinct numbers in the array to a set
			foreach (int number in array)
			{
				if (!numbers.Contains(number))
				{
					numbers.Add(number);
				}
			}

			//process all numbers
			while(numbers.Count > 0)
			{
				int num = numbers.First();
				numbers.Remove(num);

				// look for lower and upper bound of the range containing current number in the hash
				int lower = num - 1;
				while (numbers.Contains(lower))
				{
					numbers.Remove(lower--);
				}

				int upper = num + 1;
				while(numbers.Contains(upper))
				{
					numbers.Remove(upper++);
				}

				// append longest range
				if (longestRangeSoFar.Item2 - longestRangeSoFar.Item1 + 1 < upper - lower + 1)
				{
					longestRangeSoFar = new Tuple<int, int>(lower + 1, upper - 1);
				}
			}
			return longestRangeSoFar;
		}
	}
}
