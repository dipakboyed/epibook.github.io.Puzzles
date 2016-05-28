using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// A palindrome is a word that reads the same forwards and backwards. e.g. "level", "radar".
	/// Write a program to test whether the letters forming a string can be permutted to form a
	/// palindrome.
	/// </summary>
	/// <example>
	/// "edified" can be permuted to form "deified" which is a palindrome.
	/// </example>
	public static class TestForPalindrome
	{
		public static bool CanWordBeAPalindrome(string word)
		{
			Dictionary<char, int> characterCount = new Dictionary<char, int>();
			foreach (char character in word)
			{
				if (!characterCount.ContainsKey(character))
				{
					characterCount.Add(character, 0);
				}
				characterCount[character]++;
			}

			int oddCounts = 0;
			foreach (int charCount in characterCount.Values)
			{
				if ((charCount % 2 != 0) && ++oddCounts > 1)
				{
					return false;
				}
			}
			return true;
		}
	}
}
