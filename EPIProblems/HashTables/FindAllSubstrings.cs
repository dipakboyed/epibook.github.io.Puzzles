using System.Collections.Generic;
using System.Linq;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function that takes as input a string ("sentence") and a list of strings ("words")
	/// and returns all substrings of the sentence which are a concatenation of all the words.
	/// Assume all words have equal length. Each word must appear only once and the ordering doesnt matter
	/// </summary>
	/// <example>
	/// sentence: "amanaplanacanal" and words: {"can", "apl", "ana"} returns "aplanacan"
	/// </example>
	public static class FindAllSubstrings
	{
		public static string[] FindAllSubstringsMatchingWords(string sentence, string[] words)
		{
			List<string> result = new List<string>();
			HashSet<string> dictionary = new HashSet<string>(words);
			int numberOfWords = words.Length;
			int wordLength = dictionary.First().Length; //assume all words are same length

			for (int i = 0; i + (numberOfWords * wordLength) <= sentence.Length; i++)
			{
				if (MatchesAllWords(sentence, i, dictionary, numberOfWords, wordLength))
				{
					result.Add(sentence.Substring(i, numberOfWords * wordLength));
				}
			}
			return result.ToArray();
		}

		private static bool MatchesAllWords(string sentence, int startIndex, HashSet<string> dictionary, int numberOfWords, int wordLength)
		{
			HashSet<string> wordsFoundSoFar = new HashSet<string>();
			for (int i = 0; i < numberOfWords; i++)
			{
				string currentWord = sentence.Substring(startIndex + (i * wordLength), wordLength);
				if (!dictionary.Contains(currentWord))
				{
					// current word not in dictionary, so we didnt match all words
					return false;
				}
				else // current word is in dictionary
				{
					if (!wordsFoundSoFar.Contains(currentWord))
					{
						// we havent seen this word yet
						wordsFoundSoFar.Add(currentWord);
					}
					else //we've already seen this word
					{
						return false;
					}
				}
			}
			return wordsFoundSoFar.Count == dictionary.Count;
		}
	}
}
