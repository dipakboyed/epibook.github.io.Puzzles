using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class ISBNCacheUnitTest
	{
		[TestMethod]
		public void ISBNLruCache()
		{
			ISBNCache cache = new ISBNCache();
			cache.Lookup(1).Should().Be(-1);
			cache.Insert(1, 10);
			cache.Insert(2, 20);
			cache.Insert(3, 30);
			cache.Insert(4, 40);
			cache.Insert(5, 50);
			cache.Insert(6, 60);
			cache.Lookup(1).Should().Be(-1, because: "LRU item was evicted");
			cache.Lookup(2).Should().Be(20, because: "non LRU item is found");
			cache.Erase(5).Should().BeTrue();
			cache.Insert(7, 70);
			cache.Insert(8, 80);
			cache.Insert(3, 30);
			cache.Lookup(4).Should().Be(-1, because: " LRU item was evicted");
		}
	}
}
