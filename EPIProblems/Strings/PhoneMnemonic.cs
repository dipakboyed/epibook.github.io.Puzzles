using System;
using System.Collections.Generic;
using System.Linq;

namespace EPI.Strings
{
	/// <summary>
	/// Compute all mnemonics for a phone number
	/// Return all possible character sequences that correspond to a phone number
	/// </summary>
	public static class PhoneMnemonic
	{
		// phone number keypad mapping of digits to one or more letters
		static readonly string[] DigitsToLettersMapping = {
				"0",	// 0
				"1",	// 1
				"ABC",	// 2
				"DEF",	// 3
				"GHI",	// 4
				"JKL",	// 5
				"MNO",	// 6
				"PQRS",	// 7
				"TUV",	// 8
				"WXYZ"	// 9
			};

		public static IList<string> ComputeMnemonic(string phoneNumber)
		{
			List<string> mnemonics = new List<string>();
			if (null != phoneNumber)
			{
				char[] digitsParsedSoFar = Enumerable.Repeat(' ', phoneNumber.Length).ToArray();
				MnemonicHelper(phoneNumber, 0, digitsParsedSoFar, mnemonics);
			}
			return mnemonics;
		}

		private static void MnemonicHelper(string phoneNumber, int digit, char[] digitsParsedSoFar, List<string> mnemonics)
		{
			// recursion termination case : computed all digits, so add digits parsed so far to results list
			if (digit == phoneNumber.Length)
			{
				mnemonics.Add(new string(digitsParsedSoFar));
			}
			else
			{
				int currentDigit = phoneNumber[digit] - '0';
				if (currentDigit < 0 || currentDigit > 9)
				{
					throw new InvalidOperationException("Invalid phone number");
				}

				// find all possible letters mapping to current digit
				foreach (char letter in DigitsToLettersMapping[currentDigit])
				{
					// for each matching letter, compute the mnemonic
					digitsParsedSoFar[digit] = letter;
					MnemonicHelper(phoneNumber, digit + 1, digitsParsedSoFar, mnemonics);
				}
			}
		}
	}
}
