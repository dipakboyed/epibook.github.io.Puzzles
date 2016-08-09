using System;
using System.Collections.Generic;

namespace EPI.Graphs
{
	/// <summary>
	/// You are given a 2D char maze representing a puzzle and list fo words.
	/// Determine all the words present in the puzzle and if yes, the word's starting point and direction.
	/// Words can be present in any of the following directions: Top, bottom, left, right, diagonally in all four ways
	/// </summary>
	public static class WordPuzzle
	{
		private static int[,] near = new int[8, 2]
		{
			{-1, 0 },	// N
			{1, 0 },	// S
			{0, 1 },	// E
			{0, -1 },	// W
			{-1, -1 },	// NW
			{-1, 1 },	// NE
			{1, 1 },	// SE
			{1, -1 }	// SW
		};

		public class Position
		{
			public int X;
			public int Y;
			public int dir;
			public Position()
			{
				X = -1;
				Y = -1;
				dir = -1;
			}
		}

		public class Node
		{
			public char c;
			public Node[] next = new Node[8];
		}

		public class Graph
		{
			public Node[,] nodes;
			public Dictionary<char, List<Tuple<int, int>>> start;

			public Graph(char[,] maze)
			{
				int x = maze.GetLength(0);
				int y = maze.GetLength(1);
				nodes = new Node[x, y];
				start = new Dictionary<char, List<Tuple<int, int>>>();
				for (int i = 0; i < x; i++)
				{
					for (int j = 0; j < y; j++)
					{
						nodes[i, j] = new Node() { c = maze[i, j] };
						if (!start.ContainsKey(maze[i,j]))
						{
							start.Add(maze[i, j], new List<Tuple<int, int>>());
						}
						start[maze[i, j]].Add(new Tuple<int, int>(i, j));
					}
				}

				for (int i = 0; i < x; i++)
				{
					for (int j = 0; j < y; j++)
					{
						for (int n = 0; n < near.GetLength(0); n++)
						{
							int newX = i + near[n,0];
							int newY = j + near[n, 1];
							if (IsValidIndex(newX, newY, x, y))
							{
								nodes[i, j].next[n] = nodes[newX, newY];
							}
						}
					}
				}
			}
		}

		public static List<Position> FindAllWords(char[,] maze, List<string> words)
		{
			List<Position> result = new List<Position>();
			Graph graph = new Graph(maze);
			foreach (string word in words)
			{
				Position pos = new Position();
				if (!string.IsNullOrWhiteSpace(word) && word.Length > 0)
				{
					if (graph.start.ContainsKey(word[0]))
					{
						foreach (var startPos in graph.start[word[0]])
						{
							bool foundWord = false;
							if (word.Length == 1)
							{
								pos = new Position() { X = startPos.Item1, Y = startPos.Item2 };
								break;
							}
							else
							{
								List<int> directions = FindDirections(word, startPos.Item1, startPos.Item2, graph.nodes);
								foreach (int dir in directions)
								{
									int x = startPos.Item1;
									int y = startPos.Item2;
									for (int i = 1; i < word.Length; i++)
									{
										if (!IsValidIndex(x,y, maze.GetLength(0), maze.GetLength(1)) || 
											word[i-1] != graph.nodes[x,y].c || 
											graph.nodes[x,y].next[dir] == null ||
											word[i] != graph.nodes[x,y].next[dir].c)
										{
											break;
										}
										x = UpdateX(x, dir);
										y = UpdateY(y, dir);
										foundWord = (i == word.Length - 1);
									}
									if (foundWord)
									{
										pos = new Position() { X = startPos.Item1, Y = startPos.Item2, dir = dir };
										break;
									}
								}
							}
							if (foundWord)
							{
								break;
							}
						}
					}
				}
				result.Add(pos);
			}
			return result;
		}

		private static int UpdateY(int y, int dir)
		{
			return y + near[dir, 1];
		}

		private static int UpdateX(int x, int dir)
		{
			return x + near[dir, 0];
		}

		private static List<int> FindDirections(string word, int x, int y, Node[,] nodes)
		{
			List<int> dirs = new List<int>();
			if (nodes[x,y].c == word[0])
			{
				for(int n =0; n < nodes[x,y].next.Length; n++)
				{
					if (null != nodes[x,y].next[n] && nodes[x,y].next[n].c == word[1])
					{
						dirs.Add(n);
					}
				}
			}
			return dirs;
		}

		private static bool IsValidIndex(int i, int j, int x, int y)
		{
			return i >= 0 && j >= 0 && i < x && j < y;
		}
	}
}
