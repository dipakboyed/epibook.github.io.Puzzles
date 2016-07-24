using System;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// A sequence of numbers is called a zig-zag sequence if the differences between 
	/// successive numbers strictly alternate between positive and negative. 
	/// The first difference (if one exists) may be either positive or negative. 
	/// Given an array of integers, return the length of the longest subsequence
	/// that is a zig-zag sequence.
	/// </summary>
	public static class ZigZag
	{
		public enum Order
		{
			Unknown,
			Increasing,
			Decreasing
		}

		public static int LongestZigZagSubsequence(int[] array)
		{
			Tuple<int, Order>[] longest = new Tuple<int, Order>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				longest[i] = new Tuple<int, Order>(int.MinValue, Order.Unknown);
			}
			longest[0] = new Tuple<int, Order>(1, Order.Unknown);

			for (int i = 1; i < array.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					int newLength = longest[j].Item1 + 1;
					if (newLength > longest[i].Item1)
					{
						Order order = Order.Unknown;
						if (longest[j].Item2 == Order.Unknown && array[j] != array[i])
						{
							order = array[j] < array[i] ? Order.Increasing : Order.Decreasing;
						}
						if (longest[j].Item2 == Order.Increasing && array[j] > array[i])
						{
							order = Order.Decreasing;
						}
						if (longest[j].Item2 == Order.Decreasing && array[j] < array[i])
						{
							order = Order.Increasing;
						}

						if (order != Order.Unknown)
						{
							longest[i] = new Tuple<int, Order>(newLength, order);
						}
					}
				}
			}


			int max = 0;
			for (int i = 0; i < longest.Length; i++)
			{
				if (longest[i].Item1 > max)
				{
					max = longest[i].Item1;
				}
			}
			return max;
		}
	}
}
