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
			int start = 0;

			for (int i = 0; i < paragraph.Length; i++)
			{
				if (keywords.Contains(paragraph[i]))
				{
					// found a keyword

					if (!keywordsToCount.ContainsKey(paragraph[i]))
					{
						keywordsToCount.Add(paragraph[i], 1);
					}
					else
					{
						keywordsToCount[paragraph[i]]++;
					}

					if (keywordsToCount.Count == keywords.Count)
					{
						// found all keywords
						// now increment start index until we still have all keywords
						while (start < i && keywordsToCount.Count == keywords.Count)
						{
							if (keywordsToCount.ContainsKey(paragraph[start]))
							{
								--keywordsToCount[paragraph[start]];
								if (keywordsToCount[paragraph[start]] == 0)
								{
									keywordsToCount.Remove(paragraph[start]);
									if ((smallestSubarraySoFar.Item2 - smallestSubarraySoFar.Item1) > (i - start))
									{
										smallestSubarraySoFar = new Tuple<int, int>(start, i);
									}
								}
							}
							start++;
						}
					}
				}
			}
			return smallestSubarraySoFar;
		}
	}
}
