using System.Collections.Generic;

namespace EPI.Graphs.Algorithms
{
	public class AdjacencyListGraphNode
	{
		public AdjacencyListGraphNode()
		{
			Edges = new Dictionary<int, int>();
		}

		// key: destination vertex index, value: weight of edge
		public Dictionary<int, int> Edges;
	}
}
