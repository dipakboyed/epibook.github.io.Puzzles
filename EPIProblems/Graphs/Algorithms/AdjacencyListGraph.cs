using System.Collections.Generic;

namespace EPI.Graphs.Algorithms
{
    public class AdjacencyListGraph
{
        public LinkedList<AdjacencyListGraphNode>[] nodes;
        private bool isUndirectedGraph;
        public AdjacencyListGraph(int noOfNodes, bool isUndirected = false)
        {
            nodes = new LinkedList<AdjacencyListGraphNode>[noOfNodes];
            for(int i=0; i< noOfNodes; i++)
            {
                nodes[i] = new LinkedList<AdjacencyListGraphNode>();
            }
            isUndirectedGraph = isUndirected;
        }

        public void AddEdge(int source, int dest, int weight)
        {
            if (source >= 0 && source < nodes.Length &&
                dest >= 0 && dest < nodes.Length)
                {
                    nodes[source].AddLast(new AdjacencyListGraphNode(dest, weight));
                    if (isUndirectedGraph)
                    {
                        nodes[dest].AddLast(new AdjacencyListGraphNode(source,weight));
                    }
                }
        }

        public int[] BFSTraverse(int startingNode)
        {
            List<int> traversalOrder = new List<int>();
            if (startingNode >= 0 && startingNode < nodes.Length)
            {
                bool[] visited = new bool[nodes.Length];
                visited[startingNode] = true;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(startingNode);

                while(queue.Count > 0)
                {
                    int curr = queue.Dequeue();
                    traversalOrder.Add(curr);

                    foreach(var node in nodes[curr])
                    {
                        if (! visited[node.destNode])
                        {
                            visited[node.destNode] = true;
                            queue.Enqueue(node.destNode);
                        }
                    }
                }
            }
            return traversalOrder.ToArray();
        }

        public int[] DFSTraverse(int startingNode)
        {
            List<int> traverseOrder = new List<int>();
            bool[] visited = new bool[nodes.Length];
            if (startingNode >= 0 && startingNode < nodes.Length)
            {
                visited[startingNode] = true;
                traverseOrder.Add(startingNode);
                DFSHelper(startingNode, visited, traverseOrder);
            }
            return traverseOrder.ToArray();
        }

        private void DFSHelper(int curr, bool[] visited, List<int> traverseOrder)
        {
            foreach(var node in nodes[curr])
            {
                if (!visited[node.destNode])
                {
                    visited[node.destNode] = true;
                    traverseOrder.Add(node.destNode);
                    DFSHelper(node.destNode, visited, traverseOrder);
                }
            }
        }
    }
}
