using EPI.StacksAndQueues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static EPI.StacksAndQueues.MaxInSlidingWindow;

namespace EPI.UnitTests.StacksAndQueues
{
	[TestClass]
	public class MaxSlidingWindowUnitTest
	{
		[TestMethod]
		public void MaxTrafficAmountInSlidingWindow()
		{
			TrafficElement[] array = new TrafficElement[]
			{
				new TrafficElement() {Time = 0, TrafficAmount = 1.3 },
				new TrafficElement() {Time = 1, TrafficAmount = 0 },
				new TrafficElement() {Time = 2, TrafficAmount = 2.5 },
				new TrafficElement() {Time = 3, TrafficAmount = 3.7 },
				new TrafficElement() {Time = 4, TrafficAmount = 0 },
				new TrafficElement() {Time = 5, TrafficAmount = 1.4 },
				new TrafficElement() {Time = 6, TrafficAmount = 2.6 },
				new TrafficElement() {Time = 7, TrafficAmount = 0 },
				new TrafficElement() {Time = 8, TrafficAmount = 2.2 },
				new TrafficElement() {Time = 9, TrafficAmount = 1.7 },
				new TrafficElement() {Time = 10, TrafficAmount = 0 },
				new TrafficElement() {Time = 11, TrafficAmount = 0 },
				new TrafficElement() {Time = 12, TrafficAmount = 0 },
				new TrafficElement() {Time = 13, TrafficAmount = 0 },
				new TrafficElement() {Time = 14, TrafficAmount = 1.7 }
			};


			TrafficElement[] expectedResult = new TrafficElement[]
			{
				new TrafficElement() {Time = 0, TrafficAmount = 1.3 },
				new TrafficElement() {Time = 1, TrafficAmount = 1.3 },
				new TrafficElement() {Time = 2, TrafficAmount = 2.5 },
				new TrafficElement() {Time = 3, TrafficAmount = 3.7 },
				new TrafficElement() {Time = 4, TrafficAmount = 3.7 },
				new TrafficElement() {Time = 5, TrafficAmount = 3.7 },
				new TrafficElement() {Time = 6, TrafficAmount = 3.7 },
				new TrafficElement() {Time = 7, TrafficAmount = 2.6 },
				new TrafficElement() {Time = 8, TrafficAmount = 2.6 },
				new TrafficElement() {Time = 9, TrafficAmount = 2.6 },
				new TrafficElement() {Time = 10, TrafficAmount = 2.2 },
				new TrafficElement() {Time = 11, TrafficAmount = 2.2 },
				new TrafficElement() {Time = 12, TrafficAmount = 1.7 },
				new TrafficElement() {Time = 13, TrafficAmount = 0 },
				new TrafficElement() {Time = 14, TrafficAmount = 1.7 }
			};
			MaxInSlidingWindow.CalculateMaxTrafficAmount(array, 3).Should().BeEquivalentTo(expectedResult);
		}
	}
}
