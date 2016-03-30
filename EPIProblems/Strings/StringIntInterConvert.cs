using System;

namespace EPI.Strings
{
	public static class StringIntInterConvert
	{
		/// <summary>
		/// Implement string/integer interconversion functions
		/// Should be able to handle negative numbers
		/// Cannot use built-in parse/ToString functions
		/// </summary>
		public static int StringToInt(string value)
		{
			int result = 0;
			if (!string.IsNullOrEmpty(value))
			{
				int index = 0;
				bool isNegativeNumber = false;
				if (value[0] == '-')
				{
					isNegativeNumber = true;
					index++;
				}

				for (; index < value.Length; index++)
				{
					int digit = value[index] - '0';
					if (digit < 0  || digit > 9)
					{
						throw new ArgumentException(value + " is NaN", "value");
					}
					result = (10 * result) + digit;
				}

				if (isNegativeNumber)
				{
					result = -1 * result;
				}
			}
			return result;
		}

		public static string IntToString(int number)
		{
			bool isNegativeNumber = false;
			if (number == 0) return "0";
			else if (number < 0)
			{
				isNegativeNumber = true;
				number = -number;
				if (number < 0)
				{
					throw new OverflowException();
				}
			}
			string result = "";

			while (number > 0)
			{
				int digit = number % 10;
				result = (char)('0' + digit) + result;
				number = (number - digit) / 10;
			}

			return isNegativeNumber ? '-' + result :  result;
		}
	}
}
