using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPI.Graphs.Algorithms;
using FluentAssertions;

namespace EPI.UnitTests.Graphs.Algorithms
{
    [TestClass]
    public class AdjacencyMatrixGraphUnitTest
    {
       [TestMethod]
        public void AdjacencyMatrixGraphTests()
        {
            AdjacencyMatrixGraph graph = new AdjacencyMatrixGraph(5);
            graph.AddEdge(0,1,1);
            graph.AddEdge(0,4,1);
            graph.AddEdge(1,0,1);
            graph.AddEdge(1,2,1);
            graph.AddEdge(1,3,1);
            graph.AddEdge(1,4,1);
            graph.AddEdge(2,1,1);
            graph.AddEdge(2,3,1);
            graph.AddEdge(3,1,1);
            graph.AddEdge(3,2,1);
            graph.AddEdge(3,4,1);
            graph.AddEdge(4,0,1);
            graph.AddEdge(4,1,1);
            graph.AddEdge(4,3,1);

            Assert.AreEqual(5, graph.nodes.GetLength(0), "matrix based graph has 5 nodes");
            Assert.AreEqual(5, graph.nodes.GetLength(1), "matrix based graph has 5 nodes");
            graph.nodes.ShouldBeEquivalentTo(new int[5,5]
            {
                {0,1,0,0,1},
                {1,0,1,1,1},
                {0,1,0,1,0},
                {0,1,1,0,1},
                {1,1,0,1,0}
            });
        }
    }
}