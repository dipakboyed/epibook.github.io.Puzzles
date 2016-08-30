using System.Collections.Generic;
using System.Linq;

namespace EPI.Graphs.Algorithms
{
	public static class DjikstrasShortestPath
	{
		public static int[] FindShortestPathBasic(AdjacencyListGraph graph, int fromVertex)
		{
			int[] distance = Enumerable.Repeat(int.MaxValue, graph.Vertices.Count()).ToArray();
			HashSet<int> processedVertices = new HashSet<int>();
			distance[fromVertex] = 0;

			while(processedVertices.Count() < graph.Vertices.Count())
			{
				int vertex = MinDistanceVertex(graph, processedVertices, distance);
				processedVertices.Add(vertex);

				foreach (var edgeTo in graph.Vertices[vertex].Edges.Keys)
				{
					if (!processedVertices.Contains(edgeTo) && 
						distance[vertex] != int.MaxValue &&
						distance[edgeTo] > distance[vertex] + graph.Vertices[vertex].Edges[edgeTo])
					{
						distance[edgeTo] = distance[vertex] + graph.Vertices[vertex].Edges[edgeTo];
					}
				}
			}

			return distance;
		}

		//public static int[] FindShortestPathUsingHeap(AdjacencyListGraph graph, int fromVertex)
		//{

		//}

		private static int MinDistanceVertex(AdjacencyListGraph graph, HashSet<int> processedVertices, int[] distance)
		{
			int minDistance = int.MaxValue;
			int vertexToReturn = -1;
			for( int i = 0; i <graph.Vertices.Count(); i++)
			{
				if (!processedVertices.Contains(i) && distance[i] < minDistance)
				{
					minDistance = distance[i];
					vertexToReturn = i;
				}
			}
			return vertexToReturn;
		}

	}
}
