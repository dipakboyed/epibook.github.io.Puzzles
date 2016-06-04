namespace EPI.Sorting
{
	/// <summary>
	/// Give a string, print in alphabetical order each character that appears in the string and the number of times in appears
	/// </summary>
	/// <example>
	/// "bcdacebe" outputs: "(a,1)(b,2)(c,2)(d,1)(e,2)"
	/// </example>
	public static class CountOccurence
	{
		public static string CountCharacterOccurenceInSortOrder(string input)
		{
			char[] array = input.ToCharArray();
			QuickSort<char>.Sort(array);

			string result = string.Empty;
			int currentCharCount = 1;
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] == array[i-1])
				{
					++currentCharCount;
				}
				else
				{
					result += "(" + array[i - 1] + "," + currentCharCount + ")";
					currentCharCount = 1;
				}
			}
			result += "(" + array[array.Length - 1] + "," + currentCharCount + ")";
			return result;
		}
	}
}
