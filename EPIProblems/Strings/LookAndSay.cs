using System;
using System.Globalization;

namespace EPI.Strings
{
	/// <summary>
	/// Find the nth number in the look and say sequence
	/// 1, 11, 21, 1211, 111221, 312211, 13112221, 1113213211, ...
	/// </summary>
	public static class LookAndSay
	{
		public static int FindNthNumber(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("Must specify n > 0");
			}

			int number = 1;
			for(int i = 2; i <= n; i++)
			{
				number = FindNextNumber(number);
			}
			return number;
		}

		private static int FindNextNumber(int number)
		{
			string nextNumber = "";
			string numberAsString = number.ToString(CultureInfo.CurrentCulture);
			char currentDigit = numberAsString[0];
			int currentDigitCount = 1;
			for(int i = 1; i < numberAsString.Length; i++)
			{
				if (numberAsString[i] == currentDigit)
				{
					currentDigitCount++;
				}
				else
				{
					nextNumber += currentDigitCount.ToString() + currentDigit;
					currentDigitCount = 1;
					currentDigit = numberAsString[i];
				}
			}
			nextNumber += currentDigitCount.ToString() + currentDigit;
			return Convert.ToInt32(nextNumber);
		}
	}
}
