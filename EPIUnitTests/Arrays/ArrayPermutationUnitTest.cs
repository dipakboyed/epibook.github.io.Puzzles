using System.Collections.Generic;
using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class ArrayPermutationUnitTest
	{

		[TestMethod]
		public void ApplyPermutation()
		{
			List<char> array = new List<char> { 'a', 'b', 'c', 'd'};
			ArrayPermutation<char>.ApplyPermutation(array, new List<int> { 3, 2, 1, 0 });
			array.Should().ContainInOrder('d', 'c', 'b', 'a');

			array = new List<char> { 'a', 'b', 'c', 'd' };
			ArrayPermutation<char>.ApplyPermutation(array, new List<int> { 2, 3, 1, 0 });
			array.Should().ContainInOrder('d', 'c', 'a', 'b');
		}
	}
}
