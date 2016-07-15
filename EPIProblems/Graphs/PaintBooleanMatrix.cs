using System;
using System.Collections.Generic;

namespace EPI.Graphs
{
	/// <summary>
	/// Paint a Boolean Matrix
	/// Implement a routine that takes a n x m Boolean array A together with
	/// an entry (x,y) and flips the color of the region associated with (x,y)
	/// </summary>
	public static class PaintBooleanMatrix
	{
		/// <summary>
		/// Uses BFS (breadth-first search) to find the region around x,y (i.e. all neighbors with same color)
		/// and flips their color
		/// </summary>
		/// <param name="maze">2D array (n x m size)</param>
		/// <param name="x">x coordinates of start point</param>
		/// <param name="y">y coordinates of start point</param>
		public static void FlipColor(bool[,] A, int x, int y)
		{
			bool color = A[x, y];
			Queue<Tuple<int, int>> q = new Queue<Tuple<int,int>>();
			q.Enqueue(new Tuple<int,int>(x, y));
			A[x,y] = !A[x,y]; // flip the color

			int[,] neighbors = new int[4, 2] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

			while (q.Count > 0)
			{
				var current = q.Peek();
				for (int i = 0; i < neighbors.GetLength(0); i++)
				{
					Tuple<int, int> next = new Tuple<int, int>(current.Item1 + neighbors[i, 0], current.Item2 + neighbors[i, 1]);
					if (next.Item1 >= 0 && next.Item1 < A.GetLength(0)
					 && next.Item2 >= 0 && next.Item2 < A.GetLength(1)
					 && A[next.Item1, next.Item2] == color)
					{
						q.Enqueue(next);
						A[next.Item1, next.Item2] = !A[next.Item1, next.Item2]; // flip
					}
				}
				q.Dequeue();
			}
		}

		/// <summary>
		/// Uses DFS (depth-first search) to recursively find the region around x,y (i.e. all neighbors with same color)
		/// and flips their color
		/// </summary>
		/// <param name="maze">2D array (n x m size)</param>
		/// <param name="x">x coordinates of start point</param>
		/// <param name="y">y coordinates of start point</param>
		public static void FlipColorDFS(bool[,] A, int x, int y)
		{
			bool color = A[x, y];
			A[x, y] = !A[x, y]; // flip the color

			int[,] neighbors = new int[4, 2] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

			for (int i = 0; i < neighbors.GetLength(0); i++)
			{
				Tuple<int, int> next = new Tuple<int, int>(x + neighbors[i, 0], y + neighbors[i, 1]);
				if (next.Item1 >= 0 && next.Item1 < A.GetLength(0)
				 && next.Item2 >= 0 && next.Item2 < A.GetLength(1)
				 && A[next.Item1, next.Item2] == color)
				{
					FlipColorDFS(A, next.Item1, next.Item2);
				}
			}
		}
	}
}
