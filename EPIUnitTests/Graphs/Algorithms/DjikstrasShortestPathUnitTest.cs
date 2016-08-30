using EPI.Graphs.Algorithms;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Graphs.Algorithms
{
	/// <summary>
	/// Summary description for DjikstrasShortestPathUnitTest
	/// </summary>
	[TestClass]
	public class DjikstrasShortestPathUnitTest
	{

		[TestMethod]
		public void DjikstraFindShortestPath()
		{
			AdjacencyListGraph graph = new AdjacencyListGraph(9);
			graph.AddEdge(0, 1, 4);
			graph.AddEdge(0, 7, 8);
			graph.AddEdge(7, 1, 11);
			graph.AddEdge(1, 2, 8);
			graph.AddEdge(7, 8, 7);
			graph.AddEdge(7, 6, 1);
			graph.AddEdge(2, 8, 2);
			graph.AddEdge(6, 8, 6);
			graph.AddEdge(2, 5, 4);
			graph.AddEdge(6, 5, 2);
			graph.AddEdge(2, 3, 7);
			graph.AddEdge(3, 5, 14);
			graph.AddEdge(3, 4, 9);
			graph.AddEdge(5, 4, 10);

			graph.AddEdge(1, 0, 4);
			graph.AddEdge(7, 0, 8);
			graph.AddEdge(1, 7, 11);
			graph.AddEdge(2, 1, 8);
			graph.AddEdge(8, 7, 7);
			graph.AddEdge(6, 7, 1);
			graph.AddEdge(8, 2, 2);
			graph.AddEdge(8, 6, 6);
			graph.AddEdge(5, 2, 4);
			graph.AddEdge(5, 6, 2);
			graph.AddEdge(3, 2, 7);
			graph.AddEdge(5, 3, 14);
			graph.AddEdge(4, 3, 9);
			graph.AddEdge(4, 5, 10);

			var r = DjikstrasShortestPath.FindShortestPathBasic(graph, 0);
		}
	}
}
