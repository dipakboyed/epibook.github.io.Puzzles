using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given two strings, A and B(represented as array of characters), compute the 
	/// longest common subsequence (LCS) of characters.
	/// A subsequence unlike substring isn't required to occupy consecutive positions
	/// </summary>
	/// <example>
	/// LCS of "catamaoran" and "himoarea" is {m,a,r,a} or {m,o,r,a}
	/// </example>
	/// <remarks>
	/// LCS is useful to implement diff comparison utility and used in revision control systems like Git
	/// for merge.
	/// </remarks>
	public static class LongestCommonSubsequence
	{
		public static int ComputeLongestCommonSubsequenceLength(string a, string b)
		{
			// edge cases
			if (string.IsNullOrEmpty(a)) { return 0; }
			if (string.IsNullOrEmpty(b)) { return 0; }

			// LCS can be computed recursively from earlier prefixes:
			// LCS(Xi, Yj) = where Xi=0 or Yj=0, 0.
			//               where Xi == Yj, LCS(Xi-1,Yj-1) + Xi
			//               where Xi != Yj, Max(LCS(Xi-i,Yj), LCS(Xi, Yj-1)).
			//LCS can be represented as a matrix
			//   _ c a t
			// _ 0 0 0 0
			// c 0 1 1 1
			// a 0 1 2 2
			// p 0 1 2 2
			// We dont need to store the whole matrix, just the previous row and current row are sufficient
			// as Matrix[i,j] can be computed from M[i-1,j-1], M[i-1,j] and M[i, j-1].
			int[] previousRow = Enumerable.Repeat(0, a.Length + 1).ToArray();

			// iterate for each row 
			for (int j = 1; j <= b.Length; j++)
			{
				int[] currentRow = new int[a.Length + 1];
				currentRow[0] = 0;

				for (int i = 1; i <= a.Length; i++)
				{
					if (a[i - 1] == b[j - 1]) // current char at source/target is same
					{
						currentRow[i] = previousRow[i - 1] + 1;
					}
					else
					{

						currentRow[i] = Math.Max(previousRow[i], currentRow[i - 1]);
					}
				}
				// update for next iteration
				previousRow = currentRow;
			}

			return previousRow[a.Length];
		}

		[DebuggerDisplay("{Size}, {lcsSet.Count}")]
		private class LCS
		{
			public int Size;
			public HashSet<string> lcsSet;

			public LCS()
			{
				lcsSet = new HashSet<string>() { string.Empty };
				Size = 0;
			}

			public LCS(LCS l)
			{
				this.Size = l.Size;
				this.lcsSet = new HashSet<string>();
				foreach (var item in l.lcsSet)
				{
					lcsSet.Add(item);
				}
			}
			public LCS AppendtoLcsSet(char a)
			{
				var result = new LCS();
				result.lcsSet.Clear();
				for (int i = 0; i < this.lcsSet.Count; i++)
				{
					result.lcsSet.Add(this.lcsSet.ElementAt(i) + a);
				}
				result.Size = Size + 1;
				return result;
			}

			public static LCS Max(LCS a, LCS b)
			{
				if (a.Size > b.Size)
				{
					return new LCS(a);
				}
				else if (b.Size > a.Size)
				{
					return new LCS(b);
				}
				else
				{
					var result =  new LCS(a);
					foreach (var item in b.lcsSet)
					{
						if (!result.lcsSet.Contains(item))
						{
							result.lcsSet.Add(item);
						}
					}
					return result;
				}
			}
		};

		public static List<string> ListAllLongestCommonSubsequences(string a, string b)
		{
			// edge cases
			if (string.IsNullOrEmpty(a)) { return new LCS().lcsSet.ToList(); }
			if (string.IsNullOrEmpty(b)) { return new LCS().lcsSet.ToList(); }

			// LCS(Xi, Yj) = where Xi=0 or Yj=0, 0.
			//               where Xi == Yj, LCS(Xi-1,Yj-1) + Xi
			//               where Xi != Yj, Max(LCS(Xi-i,Yj), LCS(Xi, Yj-1)).
			//LCS can be represented as a matrix but this time we store the list of LCS so far in the matrix
			// We dont need to store the whole matrix, just the previous row and current row are sufficient
			// as M[i,j] can be computed from M[i-1,j-1], M[i-1,j] and M[i, j-1].
			LCS[] previousRow = new LCS[a.Length + 1];
			for (int i = 0; i < previousRow.Length; i++)
			{
				previousRow[i] = new LCS();
			}

			for (int j =1; j <= b.Length; j++)
			{
				LCS[] currentRow = new LCS[a.Length + 1];
				currentRow[0] = new LCS();

				for (int i =1; i <= a.Length; i++)
				{
					if (a[i-1] == b[j-1])
					{
						currentRow[i] = previousRow[i - 1].AppendtoLcsSet(a[i - 1]);
					}
					else
					{
						currentRow[i] = LCS.Max(previousRow[i], currentRow[i - 1]);
					}
				}

				previousRow = currentRow;
			}

			return previousRow[a.Length].lcsSet.ToList();
		}
	}
}
