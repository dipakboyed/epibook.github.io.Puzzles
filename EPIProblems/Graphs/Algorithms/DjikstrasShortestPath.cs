using System.Collections.Generic;
using System.Linq;

namespace EPI.Graphs.Algorithms
{
	public static class DjikstrasShortestPath
	{
		public static int[] FindShortestPathBasic(AdjacencyListGraph graph, int fromVertex)
		{
			int[] distance = Enumerable.Repeat(int.MaxValue, graph.nodes.Count()).ToArray();
			HashSet<int> processednodes = new HashSet<int>();
			distance[fromVertex] = 0;

			while(processednodes.Count() < graph.nodes.Count())
			{
				int vertex = MinDistanceVertex(graph, processednodes, distance);
				processednodes.Add(vertex);

				foreach (var node in graph.nodes[vertex])
				{
					if (!processednodes.Contains(node.destNode) && 
						distance[vertex] != int.MaxValue &&
						distance[node.destNode] > distance[vertex] + node.weight)
					{
						distance[node.destNode] = distance[vertex] + node.weight;
					}
				}
			}

			return distance;
		}

		//public static int[] FindShortestPathUsingHeap(AdjacencyListGraph graph, int fromVertex)
		//{

		//}

		private static int MinDistanceVertex(AdjacencyListGraph graph, HashSet<int> processednodes, int[] distance)
		{
			int minDistance = int.MaxValue;
			int vertexToReturn = -1;
			for( int i = 0; i <graph.nodes.Count(); i++)
			{
				if (!processednodes.Contains(i) && distance[i] < minDistance)
				{
					minDistance = distance[i];
					vertexToReturn = i;
				}
			}
			return vertexToReturn;
		}

	}
}
