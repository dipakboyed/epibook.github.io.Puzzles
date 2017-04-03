using System.Collections.Generic;

namespace EPI.Graphs.Algorithms
{
    public static class TopologicalSort
    {
        public static int[] GetTopologicalSortOrder(AdjacencyListGraph graph)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[graph.nodes.Length];
            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < graph.nodes.Length; i++)
            {
                if (!visited[i])
                {
                    DSFUtil(i, visited, stack, graph);
                }
            }

            while(stack.Count > 0)
            {
                result.Add(stack.Pop());
            }
            return result.ToArray();
        }

        private static void DSFUtil(int curr, bool[] visited, Stack<int> stack, AdjacencyListGraph graph)
        {
            visited[curr] = true;

            foreach(var node in graph.nodes[curr])
            {
                if (!visited[node.destNode])
                {
                    DSFUtil(node.destNode, visited, stack, graph);
                }
            }
            stack.Push(curr);
        }
    }
}