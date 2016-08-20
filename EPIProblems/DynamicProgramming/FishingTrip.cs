using System;

namespace EPI.DynamicProgramming
{
	/// <summary>
	/// A fisherman is in a rectangular sea. The value of fish at point (i,j) in the sea is specified
	/// in an n*m 2D array. Find the maximum value of fishes a fisherman can catch by only moving down or right
	/// starting from 0,0 to the lower rightmost point.
	/// </summary>
	public static class FishingTrip
	{
		public static int MaximumFishValue(int[,] sea)
		{
			for (int i = 0; i < sea.GetLength(0); i++)
			{
				for (int j = 0; j < sea.GetLength(1); j++)
				{
					sea[i, j] += Math.Max(i > 0 ? sea[i - 1, j] : 0, j > 0 ? sea[i, j - 1] : 0);
				}
			}
			return sea[sea.GetLength(0) - 1, sea.GetLength(1) - 1];
		}
	}
}
