using System.Collections.Generic;
using System.Diagnostics;

namespace EPI.Graphs
{
	/// <summary>
	/// Search a Maze
	/// Given a 2D array of black and white entries representing a maze with
	/// designated entrance and exit points, find a path from the entrance to
	/// the exit, if one exists.
	/// </summary>
	public static class SearchAMaze
	{
		[DebuggerDisplay("{X}, {Y}")]
		public struct Coordinate
		{
			public int X, Y;
		}

		#region DFS implementation

		/// <summary>
		/// Uses DFS (depth-first search) to find * a path* (not guaranteed to be the shortest path)
		/// in the maze from start to end
		/// </summary>
		/// <param name="maze">2D array (n x m size)representing a maze. Value of 0 implies white pixel</param>
		/// <param name="start">x, y coordinates of starting point</param>
		/// <param name="end">x, y coordinates of ending point</param>
		/// <returns>list of path coordinates, empty path means to solutions exists</returns>
		public static IList<Coordinate> SearchDfs(int[,] maze, Coordinate start, Coordinate end)
		{
			List<Coordinate> path = new List<Coordinate>();
			maze[start.X, start.Y] = 1;
			path.Add(start);
			if (!SearchMazeHelper(start, end, maze, path))
			{
				path.RemoveAt(path.Count - 1);
			}

			return path;
		}

		private static bool SearchMazeHelper(Coordinate current, Coordinate end, int[,] maze, List<Coordinate> path)
		{
			if (Equals(current, end)) // base case
				return true;

			int[,] neighbors = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
			for (int i = 0; i < neighbors.GetLength(0); i++)
			{
				Coordinate next = new Coordinate(){ X = current.X + neighbors[i, 0], Y = current.Y + neighbors[i, 1]};
				if (IsFeasible(next, maze))
				{
					maze[next.X, next.Y] = 1;
					path.Add(next);
					if (SearchMazeHelper(next, end, maze, path))
					{
						return true;
					}
					path.RemoveAt(path.Count - 1);
				}
			}
			return false;
		}

		#endregion

		/// <summary>
		/// Checks if current coordinate is within the maze and a white pixel
		/// </summary>
		/// <param name="current">Coordinate to check</param>
		/// <param name="maze">2d array maze</param>
		/// <returns>true upon success, false otherwise</returns>
		private static bool IsFeasible(Coordinate current, int[,] maze)
		{
			return current.X >= 0 && current.X < maze.GetLength(0)
				&& current.Y >= 0 && current.Y < maze.GetLength(1)
				&& maze[current.X, current.Y] == 0; // white pixel
		}

		#region BFS implementation

		/// <summary>
		/// Uses BFS (breadth-first search) to find the shortest path in the maze from start to end
		/// </summary>
		/// <param name="maze">2D array (n x m size)representing a maze. Value of 0 implies open area</param>
		/// <param name="start">x, y coordinates of starting point</param>
		/// <param name="end">x, y coordinates of ending point</param>
		/// <returns>list of path coordinates, empty path means to solutions exists</returns>
		public static IList<Coordinate> SearchBfs(int[,] maze, Coordinate start, Coordinate end)
		{
			// BFS will use a queue to *visit* coordinate
			// queue stores the (x,y) coord + the path from start leading upto (x, y)
			Queue<KeyValuePair<Coordinate, IList<Coordinate>>> queue = new Queue<KeyValuePair<Coordinate, IList<Coordinate>>>();
			queue.Enqueue(new KeyValuePair<Coordinate, IList<Coordinate>>(start, new List<Coordinate>()));

			// mark the coordinate as visited (re-use 1 here for simplicity)
			maze[start.X, start.Y] = 1;

			while (queue.Count > 0)
			{
				var c = queue.Dequeue();
				Coordinate current = c.Key;
				IList<Coordinate> currentPath = new List<Coordinate>(c.Value);
				currentPath.Add(current);

				// termination case
				if (current.X == end.X && current.Y == end.Y)
				{
					return currentPath;
				}

				int[,] neighbors = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
				for (int i = 0; i < neighbors.GetLength(0); i++)
				{
					Coordinate next = new Coordinate() { X = current.X + neighbors[i, 0], Y = current.Y + neighbors[i, 1] };
					if (IsFeasible(next, maze))
					{
						maze[next.X, next.Y] = 1;
						queue.Enqueue(new KeyValuePair<Coordinate, IList<Coordinate>>(next, currentPath));
					}
				}
			}

			return new List<Coordinate>();
		}

		#endregion

	}
}
