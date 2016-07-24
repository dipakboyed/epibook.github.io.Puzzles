using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class ZigZagUnitTest
	{
		[TestMethod]
		public void FindLongestZigZagSubsequenceLength()
		{
			ZigZag.LongestZigZagSubsequence(new[] { 1, 7, 4, 9, 2, 5 }).Should().Be(6);
			ZigZag.LongestZigZagSubsequence(new[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }).Should().Be(7);
			ZigZag.LongestZigZagSubsequence(new[] { 44}).Should().Be(1);
			ZigZag.LongestZigZagSubsequence(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Should().Be(2);
			ZigZag.LongestZigZagSubsequence(new[] { 70, 55, 13, 2, 99, 2, 80, 80, 80, 80, 100, 19, 7, 5, 5, 5, 1000, 32, 32 }).Should().Be(8);
			ZigZag.LongestZigZagSubsequence(new[]
			{
				374, 40, 854, 203, 203, 156, 362, 279, 812, 955,
				600, 947, 978, 46, 100, 953, 670, 862, 568, 188,
				67, 669, 810, 704, 52, 861, 49, 640, 370, 908,
				477, 245, 413, 109, 659, 401, 483, 308, 609, 120,
				249, 22, 176, 279, 23, 22, 617, 462, 459, 244
			}).Should().Be(36);
		}
	}
}
