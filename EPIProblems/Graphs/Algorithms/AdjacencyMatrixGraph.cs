namespace EPI.Graphs.Algorithms
{
    public class AdjacencyMatrixGraph
    {
        public int[,] nodes;
        public bool isUndirectedGraph;

        public AdjacencyMatrixGraph(int noOfNodes, bool isUndirected = false)
        {
            nodes = new int[noOfNodes, noOfNodes];
            isUndirectedGraph = isUndirected;
        }

        public void AddEdge(int source, int dest, int weight)
        {
            if(source >= 0 && source < nodes.GetLength(0) &&
                dest >= 0 && dest < nodes.GetLength(0))
                {
                    nodes[source, dest] = weight;
                    if (isUndirectedGraph)
                    {
                        nodes[dest, source] =  weight;
                    }
                }
        }
    }
}