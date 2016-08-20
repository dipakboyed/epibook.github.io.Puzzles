using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given an aggregate score s and W which specifies the points that can be scored in a play, how
	/// would you find the number of combinations of plays that result in the score s?
	/// How would you compute the number of distinct sequences (permutations) of plays that result in score s?
	/// </summary>
	/// <example>
	///  W = {2,3,7} and s = 12 returns 4
	///  6 safeties ( 6 x 2 = 12)
	///  3 safeties and 2 field goals ( 3 x 2  + 2 x 3 = 12)
	///  1 safety, 1 field goal and 1 touchdown ( 1 x 2 + 1 x 3 + 1 x 7 = 12) and
	///  4 field goals (4 x 3 = 12)
	/// </example>
	public static class ScoreCombinations
	{
		public static int Combinations(int finalScore, int[] plays)
		{
			int[] score = Enumerable.Repeat(0, finalScore + 1).ToArray();
			score[0] = 1;

			for (int i = 0; i < plays.Length; i++)
			{
				for (int j = 1; j < score.Length; j++)
				{
					int playScore = plays[i];
					if (j >= playScore)
					{
						score[j] += score[j - playScore];
					}
				}
			}
			return score[finalScore];
		}

		public static int Permutations(int finalScore, int[] plays)
		{
			int[] score = Enumerable.Repeat(0, finalScore + 1).ToArray();
			score[0] = 1;

			for (int i = 1; i < score.Length; i++)
			{
				for (int j = 0; j < plays.Length; j++)
				{
					int playScore = plays[j];
					if (i >= playScore)
					{
						score[i] += score[i - playScore];
					}
				}
			}

			return score[finalScore];
		}
	}
}
