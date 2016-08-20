using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class SearchSequenceIn2DArrayUnitTest
	{
		[TestMethod]
		public void FindSequenceIn2DArray()
		{
			int[,] maze = new int[3, 3]
			{
				{1,2,3},
				{3,4,5},
				{5,6,7}
			};
			SearchSequenceIn2DArray.FindSequenceInMaze(maze, new[] { 1, 3, 4, 6 }).ShouldBeEquivalentTo(new List<Tuple<int, int>>()
			{
				new Tuple<int, int>(0,0),
				new Tuple<int, int>(1,0),
				new Tuple<int, int>(1,1),
				new Tuple<int, int>(2,1)
			});

			SearchSequenceIn2DArray.FindSequenceInMaze(maze, new[] { 1, 2, 3, 4 }).Should().BeNull();
		}
	}
}
