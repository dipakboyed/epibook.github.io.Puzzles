using System.Collections.Generic;
using System.Linq;

namespace EPI.HashTables
{

	/// <summary>
	/// Write a function that takes as input a set of words and returns groups of anagrams
	/// for those words
	/// </summary>
	/// <example>
	/// Input: { "debitcard", "elvis", "silent", "badcredit", "lives", "freedom", listen", "levis"}
	/// returns 3 anagram groups: {{"debitcard", "badcredit"}, {"elvis", "lives", "levis"}, {"silent", "listen"}}
	/// </example>
	public static class PartitionAnagrams
	{
		public static List<List<string>> FindAnagrams(string[] words)
		{
			Dictionary<string, List<string>> sortedWordsToAnagrams = new Dictionary<string, List<string>>();
			//Iterate all words, sort them and add to the dictionary
			// O(nmlogm) where n is word count and m is largest word length
			foreach (string word in words)
			{
				string sortedWord = Sort(word);
				if (!sortedWordsToAnagrams.ContainsKey(sortedWord))
				{
					sortedWordsToAnagrams.Add(sortedWord, new List<string>());
				}
				sortedWordsToAnagrams[sortedWord].Add(word);
			}

			// look for any values in the dictionary with count >= 2
			List<List<string>> anagramGroups = new List<List<string>>();
			foreach (var item in sortedWordsToAnagrams.Values)
			{
				if (item.Count >= 2)
				{
					anagramGroups.Add(item);
				}
			}
			return anagramGroups;
		}

		private static string Sort(string word)
		{
			List<char> charList = word.ToList<char>();
			charList.Sort();
			return new string(charList.ToArray());
		}
	}
}
