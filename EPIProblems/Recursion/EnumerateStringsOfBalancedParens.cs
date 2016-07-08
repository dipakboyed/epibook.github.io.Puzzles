using System;
using System.Collections.Generic;

namespace EPI.Recursion
{
	/// <summary>
	/// Find the list of all strings that have k pairs of matched parenthesis
	/// </summary>
	/// <example>
	/// k=1, return {"()"}
	/// k=2, returns { "(())", "()()" }
	/// k=3, returns { "((()))", "(()())", "(())()", "()(())", "()()()" }
	/// </example>
	public static class EnumerateStringsOfBalancedParens
	{
		public static List<string> ListAllMatchedParens(int k)
		{
			List<string> result = new List<string>();
			string currentString = string.Empty;
			MatchedParensHelper(2 * k, 0, currentString, result);
			return result;

		}

		private static void MatchedParensHelper(int remainingChars, int leftParensCount, string currentString, List<string> result)
		{
			// base case: add current string to result when current index matches k
			if (remainingChars == 0)
			{
				result.Add(currentString);
			}
			else
			{
				if (leftParensCount < remainingChars)
				{
					MatchedParensHelper(remainingChars - 1, leftParensCount + 1, currentString + "(", result);
				}

				if (leftParensCount > 0)
				{
					MatchedParensHelper(remainingChars - 1, leftParensCount - 1, currentString + ")", result);
				}
			}
		}
	}
}
