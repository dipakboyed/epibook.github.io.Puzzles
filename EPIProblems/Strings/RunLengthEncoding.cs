using System;

namespace EPI.Strings
{
	/// <summary>
	/// Run Length Encoding (RLE) compression encodes successive repeated characters
	/// by the count. Implement encoding and decoding functions. Assume the input 
	/// strings contain valid characters only.
	/// </summary>
	/// <example>RLE of "aaaabcccaa" is "4a1b3c2a".
	/// The decoding of "3e4f2e" is "eeeffffee"</example>
	public static class RunLengthEncoding
	{
		public static string RleEncode(string input)
		{
			// assume input string contains valid charcters
			string encodedString = "";
			if (!string.IsNullOrEmpty(input))
			{
				char currentChar = input[0];
				int currentCharCount = 1;
				for (int i = 1; i < input.Length; i++)
				{
					if (input[i] != currentChar)
					{
						encodedString += Convert.ToString(currentCharCount) + Convert.ToString(currentChar);
						currentChar = input[i];
						currentCharCount = 1;
					}
					else
					{
						currentCharCount++;
					}
				}
				encodedString += Convert.ToString(currentCharCount) + Convert.ToString(currentChar);
			}
			return encodedString;
		}

		public static string RleDecode(string encodedString)
		{
			// assume encoded string is valid
			string decodedString = "";
			if (!string.IsNullOrEmpty(encodedString))
			{
				for (int i = 0; i < encodedString.Length; i = i + 2)
				{
					int repeatedCount = encodedString[i] - '0';
					char repeatedChar = encodedString[i + 1];
					for (int j = 0; j < repeatedCount; j++)
					{
						decodedString += Convert.ToString(repeatedChar);
					}
				}
			}
			return decodedString;
		}
	}
}
