using System;
using System.Collections.Generic;
using System.Linq;

namespace EPI.Arrays
{
	/// <summary>
	/// 
	/// </summary>
	public static class Pascal_sTriangle
	{
		public static List<List<int>> GenerateFirstNRows(int n)
		{
			if (n < 1)
			{
				return null;
			}

			List<List<int>> pascalsTriangle = new List<List<int>>();
			for (int i = 0; i < n; i++)
			{
				List<int> newRow = Enumerable.Repeat(1, i + 1).ToList();
				int previousRow = pascalsTriangle.Count - 1;
				for (int j = 1; j < i; j++)
				{
					newRow[j] = pascalsTriangle[previousRow][j - 1] + pascalsTriangle[previousRow][j];
				}
				pascalsTriangle.Add(newRow);
			}

			return pascalsTriangle;
		}


		public static List<int> GenerateNthRow(int n)
		{
			if (n < 1)
			{
				return null;
			}
			List<int> row = new List<int>();
			for (int i = 0; i < n; i++)
			{
				List<int> newRow = Enumerable.Repeat(1, i + 1).ToList();
				for (int j = 1; j < i; j++)
				{
					newRow[j] = row[j - 1] + row[j];
				}
				row = newRow;
			}

			return row;
		}
	}
}
