namespace EPI.Graphs.Algorithms
{
    public class AdjacencyListGraphNode
	{
		public int destNode;
        public int weight;
		public AdjacencyListGraphNode(int node, int w)
		{
			destNode = node;
			weight = w;
		}
	}
}
