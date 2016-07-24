using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class ShortestPathInGraphUnitTest
	{
		[TestMethod]
		public void FindShortestPathFInGraphFrom1toN()
		{
			ShortestPathInGraph.Vertex[] graph = new[]
			{
				new ShortestPathInGraph.Vertex() { Value = 'a', Edges = new Dictionary<char, int>() { {'b', 1}, { 'c', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'b', Edges = new Dictionary<char, int>() { {'a', 1}, { 'd', 1 }, { 'e', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'c', Edges = new Dictionary<char, int>() { {'a', 1}, { 'd', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'd', Edges = new Dictionary<char, int>() { {'b', 1}, { 'c', 1 }, { 'e', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'e', Edges = new Dictionary<char, int>() { {'b', 1}, { 'd', 1 }, { 'f', 1 }, { 'h', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'f', Edges = new Dictionary<char, int>() { {'e', 1}, { 'g', 1 }, { 'i', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'g', Edges = new Dictionary<char, int>() { {'f', 1}, { 'h', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'h', Edges = new Dictionary<char, int>() { {'e', 1}, { 'g', 1 }, { 'i', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'i', Edges = new Dictionary<char, int>() { {'f', 1}, { 'h', 1 }, { 'j', 1 }, { 'l', 1 }, { 'm', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'j', Edges = new Dictionary<char, int>() { {'i', 1}, { 'k', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'k', Edges = new Dictionary<char, int>() { {'j', 1}, { 'l', 1 }, { 'm', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'l', Edges = new Dictionary<char, int>() { {'i', 1}, { 'k', 1 } }},
				new ShortestPathInGraph.Vertex() { Value = 'm', Edges = new Dictionary<char, int>() { {'i', 1}, { 'k', 1 } }},
			};

			ShortestPathInGraph.FindLengthOfShortestPathFrom1ToN(graph).Should().Be(5);
		}
	}
}
