using System.Collections.Generic;
using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class Pascal_sTriangleUnitTest
	{

		[TestMethod]
		public void GenerateNRowsOfPascalsTriangle()
		{
			Pascal_sTriangle.GenerateFirstNRows(0).Should().BeNull();
			Pascal_sTriangle.GenerateFirstNRows(1).ShouldBeEquivalentTo(new List<List<int>>() { new List<int>() { 1 } });
			Pascal_sTriangle.GenerateFirstNRows(2).ShouldBeEquivalentTo(new List<List<int>>()
			{
				new List<int>() { 1 },
				new List<int>() { 1, 1 },
			});

			Pascal_sTriangle.GenerateFirstNRows(5).ShouldBeEquivalentTo(new List<List<int>>()
			{
				new List<int>() { 1 },
				new List<int>() { 1, 1 },
				new List<int>() { 1, 2, 1 },
				new List<int>() { 1, 3, 3, 1 },
				new List<int>() { 1, 4, 6, 4, 1 },
			});

			Pascal_sTriangle.GenerateNthRow(5).Should().ContainInOrder(1, 4, 6, 4, 1);
		}
	}
}
