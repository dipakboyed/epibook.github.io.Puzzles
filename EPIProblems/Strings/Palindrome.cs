namespace EPI.Strings
{
	/// <summary>
	/// Find whether a string is palindromic or not.
	/// A palindromic string is one which when all non-alphanumeric chars are removed, reads the same front to back 
	/// ignoring case
	/// </summary>
	public static class Palindrome
	{
		public static bool IsPalindrome(string input)
		{
			if (null != input)
			{
				// traverse from both ends of the string
				int leftIndex = 0;
				int rightIndex = input.Length - 1;

				// traverse until both iterators have crossed
				while (leftIndex < rightIndex)
				{
					// skip non-alphanumeric characters
					// while loop to account for consecutive non-alphanumeric chars
					while (!IsAlphaNumeric(input[leftIndex]) && leftIndex < rightIndex)
					{
						leftIndex++;
					}
					while (!IsAlphaNumeric(input[rightIndex]) && leftIndex < rightIndex)
					{
						rightIndex--;
					}

					// if the chars from both ends do not match, the input is not palindromic
					if (char.ToLowerInvariant(input[leftIndex]) != char.ToLowerInvariant(input[rightIndex]))
					{
						return false;
					}

					leftIndex++;
					rightIndex--;
				}
			}

			// traversal completed and we did not encounter any mismatch
			return true;
		}

		private static bool IsAlphaNumeric(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
		}
	}
}
