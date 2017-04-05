using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
    /// <summary>
    /// Write a function that returns the result of dividing two natural numbers but
    /// surrounds any repeated patterns in parenthesis
    /// </summary>
    /// <example>
    /// 4 divided by 2 returns 2.(0)
    /// 8 divided by 3 returns 2.(6)
    /// 22 divided by 7 returns 3.(142857)
    /// </example>
    public static class DivideAndMarkRepeats
	{
		public static string DivideXbyY(int x, int y)
		{
			if (y == 0) return "NaN";
			if (x  == 0) return "0";
			string result = string.Empty;
			if ((x < 0) ^ (y < 0)) //only one of the numbers is negative
			{
				result = "-"; //result will be negative
			}
			x = Math.Abs(x);
			y = Math.Abs(y);
			result += (x/y) + ".";

			Dictionary<int, int> previousRemaindersToResultIndex = new Dictionary<int, int>();
			x = (x % y)*10; // x holds the remainder
			while (true)
			{
				if (previousRemaindersToResultIndex.ContainsKey(x))
				{
					//we've already seen this remainder before, so we detected a circular pattern
					int repeatedPatternStartIndex = previousRemaindersToResultIndex[x];
					result = result.Insert(repeatedPatternStartIndex, "(");
					result = result.Insert(result.Length, ")");
					return result;
				}
				else
				{
					previousRemaindersToResultIndex.Add(x, result.Length);
					result += x/y;
					x = (x%y)*10;
				}
			}
		}
	}
}
