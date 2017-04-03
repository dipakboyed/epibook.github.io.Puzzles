using System;
using System.Collections.Generic;

namespace EPI.Graphs.Algorithms
{
    public static class DetectCycle
    {
        public static bool IsDirectGraphCyclic(AdjacencyListGraph graph)
        {
             int n = graph.nodes.Length;
             bool[] visited = new bool[n];
             bool[] currPath = new bool[n];

             for(int i =0; i < n; i++)
             {
                 if (DSFUtil(i, visited, currPath, graph))
                 {
                     return true;
                 }
             }
            return false;
         }

        private static bool DSFUtil(int curr, bool[] visited, bool[] currPath, AdjacencyListGraph graph)
        {
            if (!visited[curr])
            {
               visited[curr] = true;
               currPath[curr] = true;

               foreach(var node in graph.nodes[curr])
               {
                   if (!visited[node.destNode] && DSFUtil(node.destNode, visited, currPath, graph))
                   {
                       return true;
                   }
                   if (currPath[node.destNode])
                   {
                       return true;
                   }
                }
            }
            currPath[curr] = false;
            return false;
        }
    }
}