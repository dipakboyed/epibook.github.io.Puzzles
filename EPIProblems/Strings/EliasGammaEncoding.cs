
using System;
using System.Collections.Generic;

namespace EPI.Strings
{
	/// <summary>
	/// Elias Gamma code of a positive integer ( > 0), n is computed as:
	/// - Write n in binary to form a string b
	/// - Subtract 1 from the number of bits and add that many zeros to the beginning of b.
	/// Implement encode and decode functions and assume input always contains valid characters
	/// </summary>
	/// <example>Elias gamma code of 13 (1101 in binary) is 0001101</example>
	public static class EliasGammaEncoding
	{
		public static string EliasGammaEncode(int[] inputNumbers)
		{
			string encodedResult = "";
			foreach (int number in inputNumbers)
			{
				string binary = ConvertToBinary(number);
				// append leading 0s
				encodedResult += new string('0', binary.Length - 1) + binary;
			}
			return encodedResult;
		}

		public static int[] EliasGammaDecode(string encodedString)
		{
			// NOTE: Because 0 in binary is represented by a single digit,
			// it has (1 -1 = 0) no leading '0's and hence cannot be decoded correctly by the below implementation
			// assume only valid positive numbers are provided
			List<int> decodedResult = new List<int>();
			int currentNumberStartIndex = 0;
			int currentNumberLength = 0;

			while (currentNumberStartIndex < encodedString.Length)
			{
				if (encodedString[currentNumberStartIndex + currentNumberLength] == '0')
				{
					// count consecutive leading 0s
					currentNumberLength++;
				}
				else
				{
					int number = ConvertToInt(encodedString.Substring(currentNumberStartIndex + currentNumberLength, currentNumberLength + 1));
					decodedResult.Add(number);

					currentNumberStartIndex += (2*currentNumberLength) + 1;
					currentNumberLength = 0;
				}
			}
			return decodedResult.ToArray();
		}

		private static string ConvertToBinary(int number)
		{
			string result = "";
			do
			{
				result = (number & 1) + result;
				number >>= 1;
			} while (number > 0);
			return result;
		}

		private static int ConvertToInt(string binary)
		{
			int result = 0;
			for (int i = 0; i < binary.Length; i++)
			{
				result = (2*result) + (binary[i] - '0');
			}
			return result;
		}
	}
}
