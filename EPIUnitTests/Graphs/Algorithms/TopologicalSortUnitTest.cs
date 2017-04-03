using EPI.Graphs.Algorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Graphs.Algorithms
{
    [TestClass]
    public class TopologicalSortUnitTest
    {
        private AdjacencyListGraph graph;

        [TestInitialize]
        public void Setup()
        {
            graph = new AdjacencyListGraph(6);
            graph.AddEdge(5, 0, 1);
            graph.AddEdge(4, 0, 1);
            graph.AddEdge(4, 1, 1);
            graph.AddEdge(5, 2, 1);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(3, 1, 1);
        }

        [TestMethod]
        public void GetTopologicalSort()
        {
            TopologicalSort.GetTopologicalSortOrder(graph).ShouldBeEquivalentTo(new int[] {5,4,2,3,1,0});
        }
    }
}