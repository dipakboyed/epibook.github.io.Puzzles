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
			Tuple<int, int> smallestSubarraySoFar = new Tuple<int, int>(0, Int32.MaxValue);
			//First: record the order of the keyword sequence
			Dictionary<string, int> keyIndex = new Dictionary<string, int>();
			for(int i = 0; i < keywords.Length; i++)
			{
				keyIndex.Add(keywords[i], i);
			}

			// store the latest occurence of each keyword (initialize to Max)
			// use the key index as the index in this array
			int[] latestKeyIndex = Enumerable.Repeat(Int32.MaxValue, keywords.Length).ToArray();

			for (int i = 0; i < paragraph.Length; i++)
			{
				if (keyIndex.ContainsKey(paragraph[i]))
				{
					// at a keyword
					int keyNumber = keyIndex[paragraph[i]];
					if (keyNumber == 0) //first key
					{
						latestKeyIndex[keyNumber] = i;
					}
					else if (latestKeyIndex[keyNumber -1] <  Int32.MaxValue) //for all other key, set only if previous keys have been found
					{
						latestKeyIndex[keyNumber] = i;
					}

					if (keyNumber == keyIndex.Count -1  &&			//at the last keyword
						latestKeyIndex[keyNumber] < Int32.MaxValue) // and have found all keys
					{
						if (smallestSubarraySoFar.Item2 - smallestSubarraySoFar.Item1 >  (i - latestKeyIndex[0]))
						{
							smallestSubarraySoFar = new Tuple<int, int>(latestKeyIndex[0], i);
						}
					}
				}
			}
			return smallestSubarraySoFar;
		}
	}
}
