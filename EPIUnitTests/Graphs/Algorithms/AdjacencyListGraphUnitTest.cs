using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPI.Graphs.Algorithms;
using FluentAssertions;

namespace EPI.UnitTests.Graphs.Algorithms
{
    [TestClass]
    public class AdjacencyListGraphUnitTest
    {
        [TestMethod]
        public void AdjacencyListGraphCreatedSuccessfully()
        {
            AdjacencyListGraph graph = new AdjacencyListGraph(5);
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

            Assert.AreEqual(5, graph.nodes.Length, "list based graph has 5 nodes");
            Assert.AreEqual(2, graph.nodes[0].Count);
            Assert.AreEqual(4, graph.nodes[1].Count);
            Assert.AreEqual(2, graph.nodes[2].Count);
            Assert.AreEqual(3, graph.nodes[3].Count);
            Assert.AreEqual(3, graph.nodes[4].Count);
        }

        [TestMethod]
        public void AdjacencyListUndirectedGraphCreatedSuccessfully()
        {
            AdjacencyListGraph graph = new AdjacencyListGraph(3, true);
            graph.AddEdge(0,1,1);
            graph.AddEdge(0,2,1);
            graph.AddEdge(1,2,1);

            Assert.AreEqual(3, graph.nodes.Length, "list based graph has 3 nodes");
            Assert.AreEqual(2, graph.nodes[0].Count);
            Assert.AreEqual(2, graph.nodes[1].Count);
            Assert.AreEqual(2, graph.nodes[2].Count);
        }

        [TestMethod]
        public void BFSTraversal()
        {
            AdjacencyListGraph graph = new AdjacencyListGraph(4);
            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 1);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 0, 1);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(3, 3, 1);
            graph.BFSTraverse(2).ShouldBeEquivalentTo(new int[] {2,0,3,1});
        }

        [TestMethod]
        public void DFSTraversal()
        {
            AdjacencyListGraph graph = new AdjacencyListGraph(4);
            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 1);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 0, 1);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(3, 3, 1);
            
            graph.DFSTraverse(2).ShouldBeEquivalentTo(new int[] {2,0,1,3});
        }
    }
}
