namespace EPI.Arrays
{
	/// <summary>
	/// Write a function that takes as input two strings representing integers
	/// and returns their product as a string
	/// </summary>
	/// <example>
	/// "123" x "-456" returns "-56088"
	/// </example>
	public static class MultiplyBigInt
	{
		public static string Multiply(string number1, string number2)
		{
			int[] productDigits = new int[number1.Length + number2.Length];
			bool isNumber1Negative = false;
			if (number1.Length > 1 && number1[0] == '-')
			{
				isNumber1Negative = true;
				number1 = number1.Substring(1);
			}
			bool isNumber2Negative = false;
			if (number2.Length > 1 && number2[0] == '-')
			{
				isNumber2Negative = true;
				number2 = number2.Substring(1);
			}

			number1 = new string(Reverse<char>(number1.ToCharArray(), 0, number1.Length - 1));
			number2 = new string(Reverse<char>(number2.ToCharArray(), 0, number2.Length - 1));
			for (int i = 0; i < number1.Length; i++)
			{
				for (int j = 0; j < number2.Length; j++)
				{
					int product = (number1[i] - '0') * (number2[j] - '0');
					productDigits[i + j] += product;
					productDigits[i + j + 1] += (productDigits[i + j]/10);
					productDigits[i + j] = productDigits[i + j] % 10;
				}
			}

			int zeros = productDigits.Length - 1;
			while (productDigits[zeros] == 0)
			{
				zeros--;
			}

			int returnStringLength = zeros + 1;
			bool answerIsNegative = false;
			if (isNumber1Negative ^ isNumber2Negative)
			{
				returnStringLength++;
				answerIsNegative = true;
			}
			char[] returnArray = new char[returnStringLength];
			if (answerIsNegative)
			{
				returnArray[0] = '-';
			}
			for (int i = answerIsNegative ? 1 : 0; i < returnStringLength; i++)
			{
				returnArray[i] = (char) ('0' + productDigits[zeros--]);
			}
			return new string(returnArray);
		}

		private static T[] Reverse<T>(T[] input, int start, int end)
		{
			while (start < end)
			{
				T temp = input[start];
				input[start] = input[end];
				input[end] = temp;
				start++;
				end--;
			}
			return input;
		}
	}
}
