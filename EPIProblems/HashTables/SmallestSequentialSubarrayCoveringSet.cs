using System;
using System.Collections.Generic;
using System.Linq;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function that takes two array of strings and returns the indices of the starting and ending
	/// index of the shortest subarray that sequentially covers the set (i.e. contains all strings in the set
	/// in the right order).
	/// Assume all keywords are distinct
	/// </summary>
	/// <example>
	/// {Let, us, save, the, union, because, the, union, we, have, to, save} for the set {"union", "save"}
	/// returns {7,11}
	/// </example>
	public static class SmallestSequentialSubarrayCoveringSet
	{
		public static Tuple<int, int> FindSmallestSequentialSubarrayOfKeywords(string[] paragraph, string[] keywords)
		{
			//First: record the order of the keyword sequence
			Dictionary<string, int> keywordsOrder = new Dictionary<string, int>();
			for(int i = 0; i < keywords.Length; i++)
			{
				keywordsOrder.Add(keywords[i], i);
			}

			// store the latest occurence of each keyword
			// use the keyword order as the index in this array
			int[] latestKeywordOccurence = Enumerable.Repeat(-1, keywords.Length).ToArray();

			// For each keyword (indexed by the keyword order), store the length of the shortest sequential subarray
			// upto that keyword that ends at the keyword's latest occurence
			// e.g. keywords: {a, b} have order {0,1}
			// a[0] contains shortest subarray matching {a} at latest occurence of 'a'
			// a[1] contains shortest subarray matching {a, b} at latest occurence of 'b'
			// intiailize values with int max
			int[] shortestSubarrayLength = Enumerable.Repeat(Int32.MaxValue, keywords.Length).ToArray();

			Tuple<int, int> smallestSubarraySoFar = new Tuple<int, int>(0, Int32.MaxValue);
			for (int i = 0; i < paragraph.Length; i++)
			{
				if (keywordsOrder.ContainsKey(paragraph[i]))
				{
					// we found a keyword
					int keyIndex = keywordsOrder[paragraph[i]];
					if (keyIndex == 0) // first keyword
					{
						shortestSubarrayLength[keyIndex] = 1;
					}
					//keyword but not the first one
					else if (shortestSubarrayLength[keyIndex - 1] != Int32.MaxValue)
					{
						// we have found the all previous keywords 
						int distanceFromPreviousKeyword = i - latestKeywordOccurence[keyIndex - 1];
						shortestSubarrayLength[keyIndex] = shortestSubarrayLength[keyIndex - 1] + distanceFromPreviousKeyword;
					}

					latestKeywordOccurence[keyIndex] = i;

					// if at the last keyword in the order, check for the
					// smallest subarray
					if (keyIndex == keywords.Length - 1 && 
						(smallestSubarraySoFar.Item2 - smallestSubarraySoFar.Item1) > shortestSubarrayLength[keyIndex] - 1)
					{
						smallestSubarraySoFar = new Tuple<int, int>(i - shortestSubarrayLength[keyIndex] + 1 , i);
					}
				}
			}
			return smallestSubarraySoFar;
		}
	}
}
