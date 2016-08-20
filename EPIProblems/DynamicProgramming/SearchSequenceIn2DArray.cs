using System;
using System.Collections.Generic;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// You are given a 2d array of integers, A and a sequence of integers, S.
	/// S occurs in A if you can start from any entry in A and traverse neighboring entries in A to
	/// find all elements in S. 
	/// Neighboring entries are top, down, left, right entries.
	/// It is acceptable to visit an entry in A more than once.
	/// </summary>
	public static class SearchSequenceIn2DArray
	{
		public static List<Tuple<int, int>> FindSequenceInMaze(int[,] maze, int[] sequence)
		{
			for (int i = 0; i < maze.GetLength(0); i++)
			{
				for (int j = 0; j < maze.GetLength(1); j++)
				{
					List<Tuple<int, int>> list = new List<Tuple<int, int>>();
					var result = MatchHelper(maze, sequence, i, j, 0, list);
					if (result.Item1)
					{
						return result.Item2;
					}
				}
			}
			return null;
		}

		private static Tuple<bool, List<Tuple<int, int>>> MatchHelper(int[,] maze, int[] sequence, int i, int j, int k, List<Tuple<int, int>> listSoFar)
		{
			// base case
			if ( k == sequence.Length)
			{
				return new Tuple<bool, List<Tuple<int, int>>>(true, listSoFar);
			}

			if ( i < 0 || i >= maze.GetLength(0) || j < 0 || j >= maze.GetLength(1))
			{
				return new Tuple<bool, List<Tuple<int, int>>>(false, null);
			}

			if (maze[i,j] == sequence[k])
			{
				List<Tuple<int, int>> updatedList = new List<Tuple<int, int>>();
				foreach (var item in listSoFar)
				{
					updatedList.Add(item);
				}
				updatedList.Add(new Tuple<int, int>(i, j));

				var result = MatchHelper(maze, sequence, i + 1, j, k + 1, updatedList);
				if (result.Item1)
				{
					return result;
				}
				result = MatchHelper(maze, sequence, i - 1, j, k + 1, updatedList);
				if (result.Item1)
				{
					return result;
				}
				result = MatchHelper(maze, sequence, i, j + 1, k + 1, updatedList);
				if (result.Item1)
				{
					return result;
				}
				result = MatchHelper(maze, sequence, i, j - 1, k + 1, updatedList);
				if (result.Item1)
				{
					return result;
				}
			}
			return new Tuple<bool, List<Tuple<int, int>>>(false, null);
		}
	}
}
