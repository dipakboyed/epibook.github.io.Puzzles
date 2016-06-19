using System;

namespace EPI.PrimitiveTypes
{
	/// <summary>
	/// Write a function that takes a non-negative number, x as input and
	/// returns y <> x such that y has the same weight as x and the difference
	/// between x and y is minimzed. Assume x is not 0 or all 1s
	/// </summary>
	/// <remarks> Two numbers have the same weight if they have the same number of 1s</remarks>
	public static class ClosestIntSameWeight
	{
		public static Int64 FindClosestNumberWithSameWeight(Int64 number)
		{
			for (int i = 1; i < 64; i++)
			{
				if (((number >> i-1) & 1) != ((number >> i) & 1))
				{
					number ^= (1 << i - 1) | (1 << i);
					return number;
				}
			}
			throw new InvalidOperationException("all bits are equal");
		}
	}
}
