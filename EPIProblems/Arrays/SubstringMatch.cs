namespace EPI.Arrays
{
	/// <summary>
	/// Give two strings, s (the search string) and t (the text), find the first
	/// occurence of s in t
	/// </summary>
	public static class SubstringMatch
	{
		// 1. Brute force: O(n^2) where compare t against s's substring of same length at all possible indices.
		// 2. There are some well-known O(n) string search algorithms: KMP, Boyer-Moore, RabinKarp
		// RabinKarp uses a hash function of t and makes sure it's a rolling hash, so as we iterate through s
		// the substring hash computation doesn't need to start from scratch

		public static int RabinKarp(string searchQuery, string FullText)
		{
			if (searchQuery.Length > FullText.Length)
			{
				return -1;
			}

			const int multiplier = 26;
			const int slotSize = 1000;
			//compute the hash for searchQuery and text substring starting at 0.
			// use modulo to ensure hash value is within range.
			// How rolling hash works?
			// Forget about the modulo for a second.
			// example: the hash for "cat" is computed at each step like:
			// 'c': hash = 'c'
			// 'a': hash = 'c' * 26 + 'a'
			// 't': hash = 'c' * 26 * 26 + 'a' * 26 + 't'
			// cat_hash = ((c)*26 + a)*26 + t
			// Now let's say we want to use this rolling hash to compute hash for 'ate'
			// where prefix 'c' is removed and suffix 'e' is added.
			// subtract prefix: A = cat_hash - c*26*26 = a*26 + t
			// add suffix: A * 26 + 'e' = a*26*26+ t*26 + e
			// ate = ((a)*26 + t)*26 + e
			// Now remember to use modulo in rolling hash steps (subtract prefix, append suffix) above
			int searchHash = 0, textHash = 0;
			int order = 0;
			for (int i = 0; i < searchQuery.Length; i++)
			{
				order = (i == 0) ? 1 : order * multiplier % slotSize;
				searchHash = (searchHash * multiplier + searchQuery[i]) % slotSize;
				textHash = (textHash * multiplier + FullText[i]) % slotSize;
			}

			// now iterate through fullText comparing hash of substring of same length as searchQuery
			for (int i = searchQuery.Length; i < FullText.Length; i++)
			{
				if (searchHash == textHash && // hashes match but could also match due to collision
					searchQuery.Equals(FullText.Substring(i-searchQuery.Length, searchQuery.Length)))
				{
					return i - searchQuery.Length; //found match
				}

				//substring didnt match
				// use rolling hash and compute new hash code
				textHash -= (FullText[i - searchQuery.Length] * order) % slotSize;
				if (textHash < 0)
				{
					textHash += slotSize;
				}
				textHash = (textHash * multiplier + FullText[i]) % slotSize;
			}

			// check last substring 
			if (searchHash == textHash && // hashes match but could also match due to collision
					searchQuery.Equals(FullText.Substring(FullText.Length - searchQuery.Length, searchQuery.Length)))
			{
				return FullText.Length - searchQuery.Length; //found match
			}

			// if we havent returned yet, we didnt find any match
			return -1;
		}
	}
}
