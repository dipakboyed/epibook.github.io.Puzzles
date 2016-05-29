using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function that takes an array of strings and a set of strings and returns
	/// the indices of the starting and ending index of the shortest subarray that covers
	/// the set (i.e. contains all strings in the set)
	/// </summary>
	/// <example>
	/// {Let, us, save, the, union, because, the, union, we, have, to, save} for the set {"union", "save"}
	/// returns {2,4}
	/// </example>
	public static class SmallestSubarrayCoveringSet
	{
		public static Tuple<int, int> FindSmallestSubarrayOfKeywords(string[] paragraph, HashSet<string> keywords)
		{
			Dictionary<string, int> keywordsToCount = new Dictionary<string, int>();
			Tuple<int, int> smallestSubarraySoFar = new Tuple<int, int>(0, Int32.MaxValue);
			int left = 0, right = 0;
			// iterate till the end of the paragraph
			while (right < paragraph.Length)
			{
				// move from left forward until we either find all keywords or reach the end of the paragraph
				while (keywordsToCount.Count < keywords.Count && right < paragraph.Length)
				{
					if (keywords.Contains(paragraph[right]))
					{
						// we are at a keyword, add to our dictionary
						if (keywordsToCount.ContainsKey(paragraph[right]))
						{
							keywordsToCount[paragraph[right]]++;
						}
						else
						{
							keywordsToCount.Add(paragraph[right], 1);
						}
					}
					++right;
				}

				// If found all keywords, check if this is the smallest subarray
				if (keywordsToCount.Count == keywords.Count &&
					((smallestSubarraySoFar.Item2 - smallestSubarraySoFar.Item1) > (right - left - 1)))
				{
					smallestSubarraySoFar = new Tuple<int, int>(left, right - 1);
				}

				// Now increment left until we no longer have all keywords or reach the current right end
				while (left < right && keywordsToCount.Count == keywords.Count)
				{

					if (keywords.Contains(paragraph[left]))
					{
						// we are at a keyword, decrement from our dictionary
						--keywordsToCount[paragraph[left]];
						if (keywordsToCount[paragraph[left]] == 0)
						{
							// delete the current word from dictionary since we are at the latest instance
							keywordsToCount.Remove(paragraph[left]);

							// check if this is the smallest subarray
							if ((smallestSubarraySoFar.Item2 - smallestSubarraySoFar.Item1) > (right - left - 1))
							{
								smallestSubarraySoFar = new Tuple<int, int>(left, right - 1);
							}
						}
					}
					++left;
				}
			}

			return smallestSubarraySoFar;
		}
	}
}
