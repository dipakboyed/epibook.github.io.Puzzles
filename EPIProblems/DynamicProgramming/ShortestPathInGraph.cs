using System;
using System.Collections.Generic;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// Given an undirected graph G having N vertices and positive weights.
	/// Find the shortest path from vertex 1 to vertex N, or state that such path doesn’t exist.
	/// </summary>
	public static class ShortestPathInGraph
	{
		public struct Vertex
		{
			public char Value;
			public Dictionary<char, int> Edges;
		};

		public static int FindLengthOfShortestPathFrom1ToN( Vertex[] graph)
		{
			int[] shortestPath = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
			shortestPath[0] = 0;

			for (int i = 1; i < graph.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (graph[j].Edges.ContainsKey(graph[i].Value))
					{
						shortestPath[i] = Math.Min(shortestPath[i], shortestPath[j] + graph[j].Edges[graph[i].Value]);
					}
				}
			}

			return shortestPath[graph.Length - 1];
		}
	}
}
