using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPI.Graphs.Algorithms;
using FluentAssertions;

namespace EPI.UnitTests.Graphs.Algorithms
{
    [TestClass]
    public class DetectCycleUnitTest
    {
        [TestMethod]
        public void IsGraphCyclic()
        {
            AdjacencyListGraph graph = new AdjacencyListGraph(4);
            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 1);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 0, 1);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(3, 3, 1);
            DetectCycle.IsDirectGraphCyclic(graph).Should().BeTrue();
        }
    }
}