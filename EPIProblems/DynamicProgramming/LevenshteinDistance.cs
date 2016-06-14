using System;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given two strings, A and B(represented as array of characters), compute the 
	/// minimum number of edits needed from transform A into B.
	/// An edit operation can be a character insertion, deletion or substitution
	/// </summary>
	/// <example>
	/// "cat" can be transformed into "cats" with 1 edit (insert 's' at end).
	/// "cats" can be transformed into "cat" with 1 edit (delete 's' at end).
	/// "cat" can be transformed into "cap" with 1 substitution (replcae 't' with 'p').
	/// </example>
	/// <remarks>
	/// Levenshtein Distance is useful in spell checker programs
	/// </remarks>
	public static class LevenshteinDistance
	{
		public static int ComputeMinimumEdits(string source, string target)
		{
			// edge cases
			if (string.IsNullOrEmpty(source)) { return target != null ? target.Length : 0; }
			if (string.IsNullOrEmpty(target)) { return source != null ? source.Length : 0; }

			// Levenshtein distance can be computed recursively from earlier prefixes:
			// LD(Xi, Yj) = Min( LD(Xi-1,Yj) + 1 /* ith char was deleted from X */
			//                   LD(Xi, Yj-1) + 1 /* ith char was inserted into X */
			//                   LD(Xi-1, Yj-1) + subsitutionCost) /* ith char was substituted in X */
			//                    if Xi == Yj, substitutionCost = 0, otherwise it is 1.
			//Levenshtein distance can be represented as a matrix
			//   _ c a t
			// _ 0 1 2 3
			// c 1 0 1 2
			// a 2 1 0 1
			// p 3 2 1 1
			// We dont need to store the whole matrix, just the previous row and current row are sufficient
			// as Matrix[i,i] can be computed from M[i-1,j-1], M[i-1,j] and M[i, j-1].
			int[] previousRow = new int[source.Length + 1];
			// initialize first row
			for (int a = 0; a < previousRow.Length; a++)
			{
				previousRow[a] = a;
			}

			// iterate for each row 
			for (int j = 1; j <= target.Length; j++)
			{
				int[] currentRow = new int[source.Length + 1];
				currentRow[0] = j;

				for (int i = 1; i <= source.Length; i++)
				{
					int substitutionCost = 1;
					if (source[i - 1] == target[j - 1]) // current char at source/target is same, there is no replacement cost
					{
						substitutionCost = 0;
					}

					currentRow[i] = Math.Min(previousRow[i - 1] + substitutionCost, /* substitute last char*/
									Math.Min(previousRow[i] + 1, /*delete last char */
											 currentRow[i - 1] + 1 /*insert last char */));
				}
				// update for next iteration
				previousRow = currentRow;
			}

			return previousRow[source.Length];
		}
	}
}
