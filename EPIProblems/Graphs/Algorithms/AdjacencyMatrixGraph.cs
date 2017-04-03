using System;

namespace EPI.Graphs.Algorithms
{
    public class AdjacencyMatrixGraph
    {
        public int[,] nodes;

        public AdjacencyMatrixGraph(int noOfNodes)
        {
            nodes = new int[noOfNodes, noOfNodes];
        }

        public void AddEdge(int source, int dest, int weight)
        {
            if(source >= 0 && source < nodes.GetLength(0) &&
                dest >= 0 && dest < nodes.GetLength(0))
                {
                    nodes[source, dest] = weight;
                }
        }
    }
}