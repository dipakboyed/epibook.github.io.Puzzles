using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a program which takes text for an anonymous letter and text for a magazine.
	/// Then determines if its possible to write the letter using the text from the magazine.
	/// Returns true if for each character, the number of times it appears in the letter is less
	/// than equal to the number of times it appears in the magazine
	/// </summary>
	public static class AnonymousLetterConstruction
	{
		public static bool IsLetterConstructibleFromMagazine(string letter, string magazine)
		{
			Dictionary<char, int> letterCharacterCount = new Dictionary<char, int>();
			foreach (char character in letter)
			{
				if (!letterCharacterCount.ContainsKey(character))
				{
					letterCharacterCount.Add(character, 0);
				}
				letterCharacterCount[character]++;
			}

			foreach (char character in magazine)
			{
				if (letterCharacterCount.ContainsKey(character))
				{
					if (--letterCharacterCount[character] == 0)
					{
						letterCharacterCount.Remove(character);
						if (letterCharacterCount.Keys.Count == 0)
						{
							return true;
						}
					}
				}
			}

			return letterCharacterCount.Keys.Count == 0;
		}
	}
}
