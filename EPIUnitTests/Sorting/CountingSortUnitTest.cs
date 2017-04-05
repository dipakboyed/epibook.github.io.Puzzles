using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
    [TestClass]
	public class CountingSortUnitTest
	{
		[TestMethod]
		public void ReorderElementsWithSameKey()
		{
			CountingSort.Element[] array = new CountingSort.Element[] 
			{
				new CountingSort.Element() { key = 7, name = "D" },
				new CountingSort.Element() { key = 7, name = "B" },
				new CountingSort.Element() { key = 20, name = "A" },
				new CountingSort.Element() { key = 3, name = "C" },
				new CountingSort.Element() { key = 1, name = "B" },
				new CountingSort.Element() { key = 7, name = "E" },
				new CountingSort.Element() { key = 20, name = "D" }
			};
			CountingSort.ReOrderArrayByElementKeys(array);

			array.ShouldBeEquivalentTo( new CountingSort.Element[]
			{
				new CountingSort.Element() { key = 7, name = "D" },
				new CountingSort.Element() { key = 7, name = "B" },
				new CountingSort.Element() { key = 7, name = "E" },
				new CountingSort.Element() { key = 20, name = "A" },
				new CountingSort.Element() { key = 20, name = "D" },
				new CountingSort.Element() { key = 3, name = "C" },
				new CountingSort.Element() { key = 1, name = "B" }
			});
		}
	}
}
