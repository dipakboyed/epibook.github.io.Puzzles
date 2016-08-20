using System;
using System.Linq;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// A thief's knapsack can hold at most w ounces and he breaks into a clock store. Each
	/// clock weights i ounces and retails for v dollars. the theif must take or leave a clock.
	/// What subset of clocks should the theif pick up to maximize the retail prices and hold up to
	/// w ounces
	/// </summary>
	public static class KnapsackProblem
	{
		public struct Clock
		{
			public int Price;
			public int Weight;
		};

		public static int Maximize(Clock[] store, int bagCapacity)
		{
			int[] result = Enumerable.Repeat(0, bagCapacity + 1).ToArray();

			foreach (Clock clock in store)
			{
				for (int i = bagCapacity; i >= clock.Weight; i--)
				{
					result[i] = Math.Max(result[i], result[i - clock.Weight] + clock.Price);
				}
			}

			return result[bagCapacity];
		}
	}
}
