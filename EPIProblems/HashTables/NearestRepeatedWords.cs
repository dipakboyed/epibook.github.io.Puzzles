using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// People don't like reading text in which a word is repeated multiples times.
	/// Write a function which takes as input an array and finds the distance between a closest
	/// pair of equal entries.
	/// </summary>
	/// <exmaple>
	/// If array = {"All", "work", "and", "no", "play", "makes", "for", "no", "work", "no", "fun", "and", "no", "results"}
	/// then the 2nd and 3rd occurence of "no" is the closest pair.
	/// </exmaple>
	public static class NearestRepeatedWords
	{
		public static Tuple<int, int> FindNearestRepeatedEntries(string[] array)
		{
			Dictionary<string, int> wordToLatestIndex = new Dictionary<string, int>();
			Tuple<int, int> closestPairSoFar = new Tuple<int, int>(0, Int32.MaxValue);

			for (int i =0;i < array.Length; i++)
			{
				if (!wordToLatestIndex.ContainsKey(array[i]))
				{
					wordToLatestIndex.Add(array[i], i);
				}
				else
				{
					if (closestPairSoFar.Item2 - closestPairSoFar.Item1 > i - wordToLatestIndex[array[i]])
					{
						closestPairSoFar = new Tuple<int, int>(wordToLatestIndex[array[i]], i);
					}
					wordToLatestIndex[array[i]] = i;
				}
			}

			return closestPairSoFar;
		}
	}
}
