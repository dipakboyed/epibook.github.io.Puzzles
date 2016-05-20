using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class RemoveArrayElementUnitTest
	{
		[TestMethod]
		public void RemoveElementFromArray()
		{
			int[] array = new[] {5, 3, 7, 11, 2, 3, 13, 5, 7};
			RemoveArrayElement.RemoveElement(array, 3).Should().Be(7);
			array.Should().ContainInOrder(5, 7, 11, 2, 13, 5, 7, 0, 0);
		}
	}
}
