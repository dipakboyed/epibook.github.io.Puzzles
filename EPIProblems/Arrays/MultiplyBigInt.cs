using System.Linq;

namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes as input two strings representing integers
	/// and returns an integer representing the product
	/// </summary>
	/// <example>
	/// For "193707721" x "-761838257287", return "-147573952589676412927"
	/// </example>
	public static class MultiplyBigInt
	{
		public static string Multiply(string number1, string number2)
		{
			string result = string.Empty;
			int[] productDigits = new int[number1.Length + number2.Length];
			bool num1IsNegative = false;
			if (number1.Length > 1 && number1[0] == '-')
			{
				num1IsNegative = true;
				number1 = number1.Substring(1);
			}
			bool num2IsNegative = false;
			if (number2.Length > 1 && number2[0] == '-')
			{
				num2IsNegative = true;
				number2 = number2.Substring(1);
			}

			number1 = number1.Reverse().ToString();
			number2 = number2.Reverse().ToString();
			for (int j = 0; j < number2.Length; j++)
			{
				for(int i = 0; i < number1.Length; i++)
				{
					int product = (number2[j] - '0') * (number1[i] - '0');
					productDigits[i + j] += product;
					productDigits[i + j] = productDigits[i + j] % 10;
					// carryover
					productDigits[i + j + 1] += product / 10;
				}
			}

			for (int i = productDigits.Length - 1; i >= 0; i--)
			{
				result += ('0' + productDigits[i]);
			}

			if ((num1IsNegative || num2IsNegative) && !(num1IsNegative && num2IsNegative))
			{
				result = "-" + result;
			}
			return result;
		}
	}
}
