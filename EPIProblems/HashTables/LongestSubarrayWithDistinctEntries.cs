using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function that takes an array and returns the longest
	/// subarray with the property that all elements are distinct.
	/// </summary>
	/// <example>
	/// array {f,s,f,e,t,w,e,n,w,e} returns {1,5} for the subarray {s,f,e,t,w}
	/// </example>
	public static class LongestSubarrayWithDistinctEntries
	{
		public static Tuple<int, int> FindLongestSubarrayWithDistinctEntries(char[] array)
		{
			// store the latest occurence of each entry in a dictionary
			Dictionary<char, int> latestEntryOccurence = new Dictionary<char, int>();
			Tuple<int, int> longestSubarraySoFar = new Tuple<int, int>(Int32.MinValue, 0);
			int start = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (!latestEntryOccurence.ContainsKey(array[i]))
				{
					//found distinct entry
					latestEntryOccurence.Add(array[i], i);

					// check if we have a larger result
					if ((longestSubarraySoFar.Item2 - longestSubarraySoFar.Item1) <
						(i - start))
					{
						longestSubarraySoFar = new Tuple<int, int>(start, i);
					}
				}
				else
				{
					// not a distinct entry
					//update start
					start = latestEntryOccurence[array[i]] + 1;
					latestEntryOccurence[array[i]] = i;
				}
			}
			return longestSubarraySoFar;
		}
	}
}
