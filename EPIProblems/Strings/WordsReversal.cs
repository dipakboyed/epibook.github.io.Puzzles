namespace EPI.Strings
{
	/// <summary>
	/// Reverse all words in a sentence
	/// e.g. "Alice likes Bob" transforms to "Bob likes Alice"
	/// Preserve the sequence of whitespaces from the original string
	/// e.g. " Hello  World " transforms to " World  Hello "
	/// </summary>
	public static class WordsReversal
	{
		public static string ReverseWords(string input)
		{
			if (null != input)
			{
				// use char[] to modify values at specific indices
				char[] inputCharArray = input.ToCharArray();

				// first pass: let reverse the entire string
				Reverse(inputCharArray, 0, input.Length - 1);

				// second pass : traverse the string and reverse each word
				const char wordDelimiter = ' ';
				int wordStart = 0;
				for (int i = 0; i < inputCharArray.Length; i++)
				{
					if (inputCharArray[i] == wordDelimiter)
					{
						Reverse(inputCharArray, wordStart, i - 1);
						wordStart = i + 1;
					}
				}

				// the string may not have ended with a delimiter, so reverse the last remaining word
				Reverse(inputCharArray, wordStart, inputCharArray.Length - 1);

				input = new string(inputCharArray);
			}

			return input;
		}

		private static void Reverse(char[] input, int start, int end)
		{
			while (start < end)
			{
				Swap(input, start, end);
				start++;
				end--;
			}
		}

		// Use XOR trick to swap in-place without additional storage
		private static void Swap(char[] input, int i, int j)
		{
			input[i] ^= input[j];
			input[j] ^= input[i];
			input[i] ^= input[j];
		}
	}
}
