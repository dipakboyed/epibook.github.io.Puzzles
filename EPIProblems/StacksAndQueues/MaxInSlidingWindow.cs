using System;
using System.Collections.Generic;

namespace EPI.StacksAndQueues
{
	/// <summary>
	/// You are given traffic at various times and a window length.
	/// Compute for each time, the maximum traffic over the window length time interval which ends at that time.
	/// Assume the input is specified by an array where each entry is a timestamp and corresponding amount of traffic.
	/// </summary>
	/// <example>
	/// For window length of 3 and input array:
	///	{Timespan, Traffic amount},
	///	{{0, 1.3}, {1, 0}, {2, 2.5}, {3, 3.7}, {4, 0}, {5, 1.4}, {6, 2.6}, {7, 0}, {8, 2.2}, {9, 1.7}, {10, 0}, {11, 0}, {12, 0}, {13, 0} ,{14, 1.7}}
	/// The result should be:
	/// { {0, 1.3}, {1, 1.3}, {2, 2.5}, {3, 3.7}, {4, 3.7}, {5, 3.7}, {6, 3.7}, {7, 2.6}, {8, 2.6}, {9, 2.6}, {10, 2.2}, {11, 2.2}, {12, 1.7}, {13, 0}, {14, 1.7}}
	/// </example>
	public static class MaxInSlidingWindow
	{
		public struct TrafficElement: IComparable
		{
			public int Time;
			public double TrafficAmount;

			public int CompareTo(object obj)
			{
				if (obj is TrafficElement)
				{
					return TrafficAmount.CompareTo(((TrafficElement)obj).TrafficAmount);
				}
				else
				{
					throw new ArgumentException();
				}
			}
		};

		public static TrafficElement[] CalculateMaxTrafficAmount(TrafficElement[] array, int windowLength)
		{
			QueueWithMax<TrafficElement> slidingWindow = new QueueWithMax<TrafficElement>();
			List<TrafficElement> maxTraffic = new List<TrafficElement>();

			foreach (TrafficElement item in array)
			{
				slidingWindow.Enqueue(item);
				while(item.Time - slidingWindow.Peek().Time > windowLength)
				{
					slidingWindow.Dequeue();
				}

				maxTraffic.Add(new TrafficElement() { Time = item.Time, TrafficAmount = slidingWindow.Max().TrafficAmount });
			}

			return maxTraffic.ToArray();
		}
	}
}
