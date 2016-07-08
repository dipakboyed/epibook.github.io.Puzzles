using System.Collections.Generic;

namespace EPI.Recursion
{
	/// <summary>
	/// Compute all possible palindromic decompositions of a string
	/// </summary>
	public static class PalindromicDecompositions
	{
		public static List<List<string>> FindAllPalindromicDecompositions(string s)
		{
			List<List<string>> result = new List<List<string>>();
			List<string> currentDecomposition = new List<string>();
			PalindromicDecompositionHelper(s, 0, currentDecomposition, result);
			return result;
		}

		private static void PalindromicDecompositionHelper(string s, int index, List<string> currentDecomposition, List<List<string>> result)
		{
			if (index == s.Length) // base case
			{
				result.Add(currentDecomposition);
			}
			else
			{
				for (int i = index; i < s.Length; i++)
				{
					string substring = s.Substring(index, i - index + 1);
					if(IsPalindrome(substring))
					{
						List<string> newDecomposition = new List<string>(currentDecomposition);
						newDecomposition.Add(substring);
						PalindromicDecompositionHelper(s, i + 1, newDecomposition, result);
					}
				}
			}
		}

		private static bool IsPalindrome(string substring)
		{
			for (int i = 0, j = substring.Length - 1; i < j; i++, j--)
			{
				if (substring[i] != substring[j])
				{
					return false;
				}
			}
			return true;
		}
	}
}
