
namespace EPI.Strings
{
	/// <summary>
	/// Remove all instances of "b" and replace all instances of "a" with "dd"
	/// Assume string is stored in an array with sufficient capacity to handle final result
	/// and we cannot use any new string or data structure, the original array must be modified in-place
	/// </summary>
	public static class ReplaceAndRemove
	{
		private const char ToRemove = 'b';
		private const char ToReplace = 'a';
		private const char ReplaceWith = 'd'; // 'a' is replaced with 'dd'

		public static char[] ReplaceRemove(char[] source)
		{
			// assume the original char array is appended with ' ' slots to fit the size of the result

			int countOfAs = 0;
			int lengthWithoutBs = 0;
			// first pass: remove the character toRemove and also find count of character to replace
			for (int i = 0; i < source.Length && source[i] != ' '; i++)
			{
				if (source[i] != ToRemove)
				{
					source[lengthWithoutBs] = source[i];
					lengthWithoutBs++;
				}
				if (source[i] == ToReplace)
				{
					countOfAs++;
				}
			}
			// replace any remaining chars with empty slot
			for (int i = lengthWithoutBs; i < source.Length; i++ )
			{
				source[i] = new char();
			}

			// new length of array is length without toRemove + count of toReplace
			int writeIndex = lengthWithoutBs + countOfAs -1;
			// second pass: starting from end replace all instances of toReplace with 2
			// instances of the replaceWith char
			for (int i = lengthWithoutBs - 1; i >= 0; i--, writeIndex--)
			{
				if (source[i] == ToReplace)
				{
					source[writeIndex--] = ReplaceWith;
					source[writeIndex] = ReplaceWith;
				}
				else
				{
					source[writeIndex] = source[i];
				}
			}
				return source;
		}
	}
}
