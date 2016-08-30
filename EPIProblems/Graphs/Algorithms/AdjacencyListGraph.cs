using System.Linq;

namespace EPI.Graphs.Algorithms
{
	public class AdjacencyListGraph
	{
		public AdjacencyListGraph(int noOfVertices)
		{
			Vertices = new AdjacencyListGraphNode[noOfVertices];
			for (int i = 0; i < noOfVertices; i++)
			{
				Vertices[i] = new AdjacencyListGraphNode();
			}
		}
		public AdjacencyListGraphNode[] Vertices;

		public void AddEdge(int from, int to, int weight)
		{
			if (from >= 0 && from < Vertices.Count() && to >= 0 && to < Vertices.Count())
			{
				if (!Vertices[from].Edges.ContainsKey(to))
				{
					Vertices[from].Edges.Add(to, weight);
				}
			}
		}

		public bool HasEdge(int from, int to)
		{
			return Vertices[from].Edges.ContainsKey(to);
		}
	}
}
