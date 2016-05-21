using System;
using System.Collections.Generic;
using EPI.Searching;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Searching
{
	[TestClass]
	public class BinarySearchArrayOfUnknownLengthUnitTest
	{
		private Random rand;
		private int[] largeArray;

		public BinarySearchArrayOfUnknownLengthUnitTest()
		{
			rand = new Random();
			List<int> numbers = new List<int>();
			for (int i =0; i < 10000; i++)
			{
				numbers.Add(rand.Next());
			}
			numbers.Sort();
			largeArray = numbers.ToArray();
		}

		[TestMethod]
		public void BinarySearchElementInArrayOfUnknownLength()
		{
			int index = rand.Next(10000);
			int valueToSearch = largeArray[index];
			BinarySearchArrayOfUnknownLength.Search(largeArray, valueToSearch).Should().Be(index);
		}
	}
}
