using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class DutchFlagPartitionUnitTest
	{
		[TestMethod]
		public void DutchFlagPartitioning()
		{
			int[] array = new int[] { 9, 2, 8, 1, 6, 4, 7, 3, 0, 5, 5 };
			DutchFlagPartition.Partition(array, 10);

			array.Should().ContainInOrder(2, 1, 0, 4, 3, 5, 5, 7, 6, 8, 9);
		}
	}
}
