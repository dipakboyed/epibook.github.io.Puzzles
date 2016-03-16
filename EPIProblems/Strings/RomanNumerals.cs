using System;
using System.Collections.Generic;

namespace EPI.Strings
{
	/// <summary>
	/// Convert roman numerals to their decimal values
	/// </summary>
	public static class RomanNumerals
	{
		// Mapping of roman numerals to their decimal values
		private static readonly Dictionary<char, int> RomanToDecimalMap = new Dictionary<char, int> 
		{
			{'I', 1},
			{'V', 5},
			{'X', 10},
			{'L', 50},
			{'C', 100},
			{'D', 500},
			{'M', 1000},
		};

		// Only certain smaller numerals are allowed to be written before larger numerals
		// e.g. IV is 4, IX is 9 but 99 is XCIX not IC.
		private static readonly Dictionary<int, char> AllowedSubtractions = new Dictionary<int, char>
		{
			{5, 'I'},	// 'I before V (5)' is allowed
			{10, 'I'},	// 'I before X (10)' is allowed
			{50, 'X'},	// 'X before L (50)' is allowed
			{100, 'X'},	// 'X before C (100)' is allowed
			{500, 'C'},	// 'C before D (500)' is allowed
			{1000, 'C'}	// 'C before M (1000)' is allowed
			// any other combination of smaller value before a larger value is not allowed
		};

		public static int ConvertToDecimal(string romanNumeral)
		{
			if (string.IsNullOrEmpty(romanNumeral))
			{
				throw new ArgumentException("romanNumeral cannot be null or empty");
			}
			int total = 0;
			int largestNumeralYet = 0;
			// traverse from right to left for ease of use
			for (int i = romanNumeral.Length - 1; i >= 0; i--)
			{
				int currentNumber = RomanToDecimalMap[char.ToUpperInvariant(romanNumeral[i])];
				if (currentNumber < largestNumeralYet)
				{
					if (AllowedSubtractions.ContainsKey(largestNumeralYet) && AllowedSubtractions[largestNumeralYet] == char.ToUpperInvariant(romanNumeral[i]))
					{
						total -= currentNumber;
					}
					else
					{
						throw new ArgumentException("Invalid roman numeral");
					}
				}
				else
				{
					total += currentNumber;
					if(largestNumeralYet < currentNumber)
					{
						largestNumeralYet = currentNumber;
					}
				}
			}
			return total;
		}
	}
}
