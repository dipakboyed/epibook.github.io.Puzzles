using System.Collections.Generic;
using System.Linq;

namespace EPI.Graphs.Algorithms
{
    public enum Color
    {
        White = 0, //not visited
        Grey = 1, // in progress
        Black = 2 // done visiting entire subtree
    };

    public class GraphWithNodeColor
    {
        public int nodeCount;
        public Color[] colors;

        public LinkedList<int>[] nodes;
        public GraphWithNodeColor(int noOfVertices)
        {
            nodeCount = noOfVertices;
            colors = Enumerable.Repeat<Color>(Color.White, nodeCount).ToArray();
            nodes = new LinkedList<int>[nodeCount];
            for (int i =0; i < nodeCount; i++)
            {
                nodes[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            nodes[from].AddLast(to);
        }

    }
     public class DetectCycleWithColors
     {
         public bool HasCycle(GraphWithNodeColor graph)
         {
             for (int i =0; i < graph.nodeCount; i++)
             {
                 if (HasCycleHelper(i, graph))
                 {
                     return true;
                 }
             }
             return false;
         }

        private bool HasCycleHelper(int curr, GraphWithNodeColor graph)
        {
            if (graph.colors[curr] != Color.Black) // already visited
            {
                graph.colors[curr] = Color.Grey; // in-progress
                foreach(int destNode in graph.nodes[curr])
                {
                    if (graph.colors[destNode] == Color.Grey || HasCycleHelper(destNode, graph))
                    {
                        return true;
                    }
                }
            }
            graph.colors[curr] = Color.Black; // done
            return false;
        }
    }
}