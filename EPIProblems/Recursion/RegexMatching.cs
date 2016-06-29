using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.Recursion
{
	/// <summary>
	/// Design an algorithm that takes a string s and a string (assumed to be a well-formed
	/// ESRE {Extended Simple Regular Expression}) and checks if r matches s.
	/// </summary>
	/// <remarks>
	/// ESRE can contain alphanumeric character, dot character, * character, ^ and $ characters.
	/// </remarks>
	public static class RegexMatching
	{
		public static bool IsMatch(string s, string regex)
		{
			// regex starts with ^
			if (regex.StartsWith("^"))
			{
				return IsMatchSubstring(s, 0, regex, 1);
			}

			for (int i = 0; i < s.Length; i++)
			{
				if (IsMatchSubstring(s, i, regex, 0))
				{
					return true;
				}
			}

			return false;
		}

		private static bool IsMatchSubstring(string s, int sIndex, string regex, int regexIndex)
		{
			// base case
			// we've reached the end of the regex string and not failed so far, success
			if (regexIndex == regex.Length)
			{
				return true;
			}

			// regex endswith $
			// success if we've also reached the end of the string, false otherwise
			if (regexIndex == regex.Length -1 && regex[regexIndex] == '$')
			{
				return sIndex == s.Length;
			}

			// regex at current index begins with (char)*
			if (regexIndex + 2 <= regex.Length && regex[regexIndex + 1] == '*')
			{
				// check zero occurence of (char)*
				if (IsMatchSubstring(s, sIndex, regex, regexIndex + 2))
				{
					return true;
				}

				// check for one of more occurence of (char)*
				while (sIndex < s.Length && (regex[regexIndex] == '.' || regex[regexIndex] == s[sIndex]))
				{
					if (IsMatchSubstring(s, ++sIndex, regex, regexIndex + 2))
					{
						return true;
					}
				}
			}

			// regex at current index begins with an alphanumeric char or .
			return sIndex < s.Length && (regex[regexIndex] == '.' || regex[regexIndex] == s[sIndex]) && IsMatchSubstring(s, sIndex + 1, regex, regexIndex + 1);
		}
	}
}
