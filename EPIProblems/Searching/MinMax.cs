using System;

namespace EPI.Searching
{
	/// <summary>
	/// Design an algorithm to find the min and max elements in an array
	/// using less than 2(n-1) comparisons.
	/// </summary>
	public static class MinMax
	{
		public class Pair
		{
			internal int min;
			internal int max;

			public Pair(int v1, int v2)
			{
				this.min = v1;
				this.max = v2;
			}
		}

		public static Pair FindMinMax(int[] array)
		{
			if (null == array || array.Length == 0)
			{
				return null;
			}
			else if (array.Length == 1)
			{
				return new Pair(array[0], array[0]);
			}

			Pair globalMinMax = ArrangeMinMax(array[0], array[1]);
			for (int i =2; i + 1 < array.Length; i +=2)
			{
				Pair localMinMax = ArrangeMinMax(array[i], array[i + 1]);

				globalMinMax.min = Math.Min(globalMinMax.min, localMinMax.min);
				globalMinMax.max = Math.Max(globalMinMax.max, localMinMax.max);
			}

			if (array.Length % 2 != 0) // array has odd no. of elements
			{
				globalMinMax.min = Math.Min(globalMinMax.min, array[array.Length - 1]);
				globalMinMax.max = Math.Max(globalMinMax.max, array[array.Length - 1]);
			}

			return globalMinMax;
		}

		private static Pair ArrangeMinMax(int a, int b)
		{
			if ( a <= b)
			{
				return new Pair(a, b);
			}
			else
			{
				return new Pair(b, a);
			}
		}
	}
}
